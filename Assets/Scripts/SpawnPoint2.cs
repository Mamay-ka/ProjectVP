using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SpawnPoint2 : MonoBehaviour
    {
        public GameObject spawnPoint;
        public GameObject objToSpawn;

        

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity);
            }



        }

    }




