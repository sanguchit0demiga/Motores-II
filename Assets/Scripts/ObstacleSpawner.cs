using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnDistanceZ;
    public float timeBetweenSpawnsType1;
    public float timeBetweenSpawnsType2;
    public float obstacleSpeed;

    private float[] lanes = new float[] { -3.380129f, 0.2198715f, 3.51f };

    private float nextSpawnTimeType1;
    private float nextSpawnTimeType2;

    void Update()
    {
        if (Time.time >= nextSpawnTimeType1)
        {
            SpawnObstacles(0);
            nextSpawnTimeType1 = Time.time + timeBetweenSpawnsType1;
        }

        if (Time.time >= nextSpawnTimeType2)
        {
            SpawnObstacles(1);
            nextSpawnTimeType2 = Time.time + timeBetweenSpawnsType2;
        }
    }

    void SpawnObstacles(int obstacleType)
    {
        int totalObstacles = Random.Range(1, 4);
        int type1Count = obstacleType == 0 ? Mathf.Min(2, totalObstacles) : 0;
        int type2Count = totalObstacles - type1Count;

        bool[] lanesOccupied = new bool[lanes.Length];
        float currentZ = transform.position.z + spawnDistanceZ;

        for (int i = 0; i < type1Count; i++)
        {
            int laneIndex = GetAvailableLane(lanesOccupied);
            lanesOccupied[laneIndex] = true;
            SpawnObstacle(0, laneIndex, currentZ);
            currentZ += spawnDistanceZ;
        }

        for (int i = 0; i < type2Count; i++)
        {
            int laneIndex = GetAvailableLane(lanesOccupied);
            lanesOccupied[laneIndex] = true;
            SpawnObstacle(1, laneIndex, currentZ);
            currentZ += spawnDistanceZ;
        }
    }

    void SpawnObstacle(int obstacleType, int laneIndex, float spawnZ)
    {
        float spawnHeight = (obstacleType == 0) ? 1.3f : 0.5f;
        float x = lanes[laneIndex];
        Vector3 spawnPos = new Vector3(x, spawnHeight, spawnZ);

        GameObject selectedObstacle = obstaclePrefabs[obstacleType];
        GameObject newObstacle = Instantiate(selectedObstacle, spawnPos, Quaternion.identity);

        if (newObstacle.GetComponent<ObstacleMover>() == null)
        {
            var mover = newObstacle.AddComponent<ObstacleMover>();
            mover.speed = obstacleSpeed;
        }
    }

    int GetAvailableLane(bool[] lanesOccupied)
    {
        int laneIndex;
        do
        {
            laneIndex = Random.Range(0, lanes.Length);
        } while (lanesOccupied[laneIndex]);
        return laneIndex;
    }

    public class ObstacleMover : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
    }
}
