using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCheck3 : MonoBehaviour
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
        CosmeticGive3.OnCosmetic3Found += ShowCosmetic;
    }
    void OnDisable()
    {
        CosmeticGive3.OnCosmetic3Found -= ShowCosmetic;
    }
    private void ShowCosmetic()
    {
        sr.sprite = Cosmetics[1];
    }
}
