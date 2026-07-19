using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive5 : MonoBehaviour
{
    public static event Action OnCosmetic5Found;
    public void Found4()
    {
        OnCosmetic5Found?.Invoke();
    }
}
