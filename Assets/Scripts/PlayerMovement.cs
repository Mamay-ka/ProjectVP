using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed; // Скорость движения
    [SerializeField] public Vector3 _direction; // Направление движения
    private Rigidbody _rigidbody;

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(0,10,0, ForceMode.Impulse);

        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        Jump();
    }
    public void FixedUpdate()
    {
        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed);

        
    }
}