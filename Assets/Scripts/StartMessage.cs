using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    public Text startMessage;
    private bool gameStarted = false;

    void Start()
    {
        startMessage.gameObject.SetActive(true);
        Time.timeScale = 0f; 
    }

    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            startMessage.gameObject.SetActive(false);
            gameStarted = true;
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f; 
        Debug.Log("Juego iniciado");
    }
}
