using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhisic : MonoBehaviour
{
    public float Speed = 0;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        _rigidbody.AddForce(0,1,0, ForceMode.Impulse);
    }
}
