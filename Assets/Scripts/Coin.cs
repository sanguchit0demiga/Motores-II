using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject objScore;
    public float value;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objScore.GetComponent<ScoreManager>().score += value;
            Destroy(gameObject);
        }
    }
}
