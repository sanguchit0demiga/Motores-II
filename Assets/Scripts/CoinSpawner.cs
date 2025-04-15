using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject coinPrefab;
    public float spawnInterval = 1.5f;
    public float spawnZDistance = 20f;
    public float yPosition = 1f;
    public float[] lanes = { -3.38f, 0.22f, 3.51f };

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        float x = lanes[laneIndex];
        float z = player.position.z + spawnZDistance;

        Vector3 spawnPos = new Vector3(x, yPosition, z);
        GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);

        Coin coinScript = coin.GetComponent<Coin>();
        if (coinScript != null)
        {
            coinScript.speed = 5; 
        }
    }
}
