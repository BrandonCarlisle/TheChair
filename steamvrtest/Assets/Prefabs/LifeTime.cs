﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LifeTime : MonoBehaviour
{
    public float TimeToLive = 90f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}