using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; 
    public float spawnDistanceZ = 30f;   
    public float timeBetweenSpawns = 3f; 
    public float obstacleSpeed = 5f;    

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacleBlock();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }

    void SpawnObstacleBlock()
    {
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length); 
        GameObject selectedBlock = obstaclePrefabs[prefabIndex];

        
        Vector3 spawnPos = new Vector3(1.12f, 3.583211f, transform.position.z + spawnDistanceZ);
        GameObject newBlock = Instantiate(selectedBlock, spawnPos, Quaternion.identity);

         if (newBlock.GetComponent<ObstacleMover>() == null)
        {
            ObstacleMover mover = newBlock.AddComponent<ObstacleMover>();
            mover.speed = obstacleSpeed;
        }
    }
}
