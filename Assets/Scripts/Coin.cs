using UnityEngine;

public class Coin : MonoBehaviour
{
    public float value = 1f;
    public int speed = 5;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && scoreManager != null)
        {
            scoreManager.score += value;
            Destroy(gameObject);
        }
        else {
            
            {
                if (other.CompareTag("Destroyer"))
                {
                    Destroy(gameObject);
                }
            }
}
    }
}
