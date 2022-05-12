using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField] float Damage;
    private Rigidbody _rigidbody;
        
    private HealthController _mineController;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mineController = other.gameObject.GetComponent<HealthController>();
            _mineController.GetDamage(Damage);
            Debug.Log(_mineController.CurrentHealth);
            
        }
       
    }


           
    void Update()
    {
        
    }
}
