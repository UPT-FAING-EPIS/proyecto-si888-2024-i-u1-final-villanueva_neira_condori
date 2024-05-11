using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winMenu; 

    private GameObject player; 
    
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void gameWinUI() 
    {
        winMenu.SetActive(true);
    }

    public void restart()
    {
        
        RestartLevel();
    }

    public void QuitGame()
    {
    Debug.Log("Quit button clicked!");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
}
    public void Retry()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
        
        Time.timeScale = 1f;
    }
}
