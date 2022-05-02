using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;

     void awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
