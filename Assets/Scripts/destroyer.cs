﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{

    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
