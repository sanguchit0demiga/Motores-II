using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private Player player;

    private void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.playerDeath += SetMenuActive;
    }
    private void SetMenuActive(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }   
    
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
