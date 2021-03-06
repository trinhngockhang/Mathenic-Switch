﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour {

    [SerializeField]
    private GameObject Trap;
    bool first = true;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        float rand = 3f;
        if (first == true)
        {
            rand = 1f;
            first = false;
        }
        yield return new WaitForSeconds(rand);
        Vector2 temp = new Vector2(0, 5.53f);
        Instantiate(Trap, temp, Quaternion.identity);
        StartCoroutine(Spawner());
        Controller.instance.vec.y -= 0.09f;
    }
}