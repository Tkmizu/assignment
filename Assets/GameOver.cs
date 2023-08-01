using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameoverUI;
    public GameObject pauseGame;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameover()
    {
        gameoverUI.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseGame.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseGame.SetActive(false);
    }
}
