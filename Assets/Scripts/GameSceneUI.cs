using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject resumeCanvas;
    [SerializeField] GameObject restartCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Spawn spawn;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(true);
        scoreText.gameObject.SetActive(true);
        resumeCanvas.SetActive(false);
        Debug.Log("GSU started");
        restartCanvas.gameObject.SetActive(false); 
        spawn = GameObject.Find("spawn1").GetComponent<Spawn>();
        spawn.SetGameActive();
        Debug.Log(spawn.isGameActive);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameOver) {
        //    GameOver();
        //}
    }

    public void Pausegame()
    {
        Time.timeScale = 0.0f;
        pauseCanvas.SetActive(false);
        resumeCanvas.SetActive(true );
        restartCanvas.gameObject.SetActive(true );  
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        resumeCanvas.SetActive(false);
        pauseCanvas.SetActive(true );
        restartCanvas.gameObject.SetActive (false );
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("UIScene");
         
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1.0f;
        //this.enabled = false;
        //this.enabled = true;
        restartCanvas.SetActive(false );
        resumeCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        spawn.SetGameActive();
    }

    public void GameOver()
    {
        Debug.Log("GS detected");
        restartCanvas.SetActive(true);
        resumeCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        //opAllCoroutines();
        spawn.EndGame();
        //this.enabled = false;
        
    }
}
