using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] float AgentVisionRadius = 0;
    [SerializeField] GameObject Agent;
    private CapsuleCollider _agentCollider;
    private Transform _playerPos;

    void awake()
    {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //_agentCollider.radius = AgentVisionRadius;
    }

    // Update is called once per frame
    

    

    void Update()
    {
        

    }

   
}
