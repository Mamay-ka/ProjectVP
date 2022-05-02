using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetHeals : MonoBehaviour
{
    [SerializeField] float Heals;
    public Action GetHealsDestroyed;
    
   

    private HealthController SpotHealthController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpotHealthController = other.gameObject.GetComponent<HealthController>();
            SpotHealthController.getHeals(Heals);
            Debug.Log(SpotHealthController.CurrentHealth);
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpotHealthController = null;
            GetHealsDestroyed?.Invoke(); //быстрая проверка на null
            Destroy(gameObject);
        }
    }

   
}
