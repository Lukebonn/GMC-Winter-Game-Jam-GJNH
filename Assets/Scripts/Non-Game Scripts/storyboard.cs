using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class storyboard : MonoBehaviour
{ 
    [SerializeField] private string NextScene;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
