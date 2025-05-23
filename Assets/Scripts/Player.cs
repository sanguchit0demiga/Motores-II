using UnityEngine;
using TMPro;
using System;
public class Player : MonoBehaviour
{
    public event EventHandler playerDeath;
    [SerializeField] private int health;
    public float laneDistance = 2f; 
    public float laneChangeSpeed = 5f; 
    public float jumpForce;
    private int currentLane = 1;
 
    private Rigidbody rb;
    private Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            currentLane++;
        }

        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);

        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneChangeSpeed);
        rb.MovePosition(new Vector3(newPosition.x, transform.position.y, transform.position.z));

       
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    public void TakeDamage(int cantDamage)
    {
        health-= cantDamage;
        if (health <= 0)
        {
            playerDeath?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);
        }
    }
   
    }
    
