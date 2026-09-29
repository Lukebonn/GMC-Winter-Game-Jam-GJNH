using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private string GameScene;
    [SerializeField] private string NextScene;
    private void OnEnable()
    {
        PetManager.OnTutorialFinished += TutorialFinished;
    }

    private void OnDisable()
    {
        PetManager.OnTutorialFinished -= TutorialFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(NextScene);
        }
    }

    private void TutorialFinished()
    {
        SceneManager.LoadScene(NextScene);
    }
}
