using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCheck5 : MonoBehaviour
{
    [SerializeField] List<Sprite> Cosmetics;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Cosmetics[0];
    }

    void OnEnable()
    {
        CosmeticGive5.OnCosmetic5Found += ShowCosmetic;
    }
    void OnDisable()
    {
        CosmeticGive5.OnCosmetic5Found -= ShowCosmetic;
    }
    private void ShowCosmetic()
    {
        sr.sprite = Cosmetics[1];
    }
}
