using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoint2 : MonoBehaviour
{
            
        public GameObject spawnPoint;
            public GameObject objToSpawn;

    

    void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity), 3f);//уничтожить по€вл€ющиес€ объекты
                
            }


    }
   

}




