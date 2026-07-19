using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class CosmeticGive : MonoBehaviour
{
    public static event Action OnCosmetic0Found;
    public void Found()
    {
        OnCosmetic0Found?.Invoke();
    }
}
