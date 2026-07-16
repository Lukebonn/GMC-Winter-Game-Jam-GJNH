using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private KeyCode[] triggerKeys;
    public static bool spawning = false;
    void Start()
    {
        spawning = true;
    }

    //public UnityEvent onKeyPressed;

    //void Update()
    //{
    //    foreach (KeyCode key in triggerKeys)
    //    {
    //        if (Input.GetKeyDown(key))
    //        {
    //            onKeyPressed?.Invoke();
    //            return;
    //        }
    //    }
    //}
}
