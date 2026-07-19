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
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
