using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyControler : MonoBehaviour
{
    

    [SerializeField] Transform[] PatrolPos;
    [SerializeField] int PatrolPosIndex = 0;

    private NavMeshAgent _agent;
    

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //_agent.destination = PatrolPos.position; - направить агента перемещаться в указанную точку

        _agent.destination = PatrolPos[PatrolPosIndex].position;
    }

    
    void Update()
    {
        if(!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance + 0.25f)
        {
            //var index = Random.Range(0, PatrolPos.Length); - рандомное назначение точек перемещения агента
            //_agent.destination = PatrolPos[index].position;

            PatrolPosIndex = (PatrolPosIndex + 1) % PatrolPos.Length;
            _agent.destination = PatrolPos[PatrolPosIndex].position;


        }
    }
}
