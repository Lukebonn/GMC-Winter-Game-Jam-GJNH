using System;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCheck : MonoBehaviour
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
        CosmeticGive.OnCosmetic0Found += ShowCosmetic;
    }
    void OnDisable()
    {
        CosmeticGive.OnCosmetic0Found -= ShowCosmetic;
    }
    private void ShowCosmetic()
    {
        sr.sprite = Cosmetics[1];
    }
}
