﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRot : MonoBehaviour
{
    Vector3 turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = new Vector3(0, 0, -80f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turn * Time.deltaTime * 2f);

    }
}
