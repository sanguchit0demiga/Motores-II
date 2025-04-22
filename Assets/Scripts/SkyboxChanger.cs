using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material newSkyboxMaterial; 
    public float scoreto = 200f;

    private bool skyboxChanged = false;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (!skyboxChanged && scoreManager != null && scoreManager.score >= scoreto)
        {
            RenderSettings.skybox = newSkyboxMaterial;
          
            skyboxChanged = true;
        }
    }
}
