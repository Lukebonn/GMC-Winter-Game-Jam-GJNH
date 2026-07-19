using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive1 : MonoBehaviour
{
    public static event Action OnCosmetic1Found;
    public void Found0()
    {
        OnCosmetic1Found?.Invoke();
    }
}
