using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCheck4 : MonoBehaviour
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
        CosmeticGive4.OnCosmetic4Found += ShowCosmetic;
    }
    void OnDisable()
    {
        CosmeticGive4.OnCosmetic4Found -= ShowCosmetic;
    }
    private void ShowCosmetic()
    {
        sr.sprite = Cosmetics[1];
    }
}
