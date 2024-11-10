using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject resumeCanvas;
    [SerializeField] GameObject activeCanvas;
    Spawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        activeCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        //spawn = GameObject.Find("spawn1").GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
    public void StartGame()
    {
        //spawn.SetGameActive();
        activeCanvas.SetActive(true);
        startCanvas.SetActive(false);
        Debug.Log("Start button detected");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;  
        

    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }
}
