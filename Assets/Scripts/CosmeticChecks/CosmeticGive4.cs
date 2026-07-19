using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive4 : MonoBehaviour
{
    public static event Action OnCosmetic4Found;
    public void Found3()
    {
        OnCosmetic4Found?.Invoke();
    }
}
