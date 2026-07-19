using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCheck1 : MonoBehaviour
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
        CosmeticGive1.OnCosmetic1Found += ShowCosmetic;
    }
    void OnDisable()
    {
        CosmeticGive1.OnCosmetic1Found -= ShowCosmetic;
    }
    private void ShowCosmetic()
    {
        sr.sprite = Cosmetics[1];
    }
}
