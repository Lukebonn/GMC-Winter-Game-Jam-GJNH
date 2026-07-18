using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private string tutorialSceneName;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
