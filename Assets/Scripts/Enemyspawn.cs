﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{

    public GameObject enemynormal;
    public GameObject enemyBig;
    float randY;
    float randtype;
    Vector2 spawnlocation;
    public float spawnrate = 2f;
    float nextspawn = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            randY = Random.Range(4.4f, -4.5f);
            spawnlocation = new Vector2(transform.position.x, randY);
            randtype = Random.Range(0, 6);
            if(randtype < 5)
            {
            Instantiate(enemynormal, spawnlocation, enemynormal.transform.rotation);
            }
            else
            {
                Instantiate(enemyBig, spawnlocation, enemyBig.transform.rotation);
            }


        }
    }
}
