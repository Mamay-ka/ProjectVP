using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float DamagePerSecond;
    private float m_Time = 0;

    private HealthController trappedHealthController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trappedHealthController = other.gameObject.GetComponent<HealthController>();
            trappedHealthController.GetDamage(Damage);
            Debug.Log(trappedHealthController.CurrentHealth);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (trappedHealthController != null && m_Time >= 1)
        {
            trappedHealthController.GetDamage(DamagePerSecond);
            Debug.Log(trappedHealthController.CurrentHealth);
            m_Time = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trappedHealthController = null;
        }
    }

    private void Update()
    {
        m_Time += Time.deltaTime;
    }
}
