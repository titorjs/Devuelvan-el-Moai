using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public GameObject tile;
    Vector3 nextSpawn;
    private int tileCount;


    public void SpawnTile()
    {
        GameObject temp = Instantiate(tile, nextSpawn, Quaternion.identity);
        nextSpawn = temp.transform.GetChild(1).transform.position;
        tileCount++;
        Debug.Log(tileCount);
    }

    void Start()
    {
        tileCount = 0;
        for (int i = 0; i < Constants.initialTails; i++)
        {
            SpawnTile();
        }
    }
}
