using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeals : MonoBehaviour
{
    [SerializeField] float Heals;
    
   

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
            Destroy(gameObject);
        }
    }

   
}
