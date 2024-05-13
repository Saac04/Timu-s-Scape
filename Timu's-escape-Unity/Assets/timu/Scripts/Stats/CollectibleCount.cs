using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    public int collectibleCount;
    void Awake()
    {
        collectibleCount = PlayerPrefs.GetInt("collectibleCount", 0);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("collectibleCount", collectibleCount);
    }
}
