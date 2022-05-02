using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject objToSpawn;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity);
            break;
        }
    }

    void Update()
    {

        

    }

}
