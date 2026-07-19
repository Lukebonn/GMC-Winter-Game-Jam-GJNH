using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive2 : MonoBehaviour
{
    public static event Action OnCosmetic2Found;
    public void Found1()
    {
        OnCosmetic2Found?.Invoke();
    }
}
