using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float speed;
    public GameObject obstaclePrefab;

    void Start()
    {
        
        
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    
}