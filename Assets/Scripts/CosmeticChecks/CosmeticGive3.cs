using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive3 : MonoBehaviour
{
    public static event Action OnCosmetic3Found;
    public void Found2()
    {
        OnCosmetic3Found?.Invoke();
    }
}
