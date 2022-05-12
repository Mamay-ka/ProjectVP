using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FF : MonoBehaviour
{
    public int Speed = 0;
    private Rigidbody _rigidbody;
    [SerializeField] Transform _gameObject;
    public Transform PointToShot;




    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(-transform.up * Speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        var _target = (PointToShot.position - _gameObject.position);
        _rigidbody.AddForce(_target * Speed, ForceMode.Impulse);
        //var _target = (A.position - _gameObject.position);
        //_rigidbodyGrenade.AddForce(Vector3.right * GrenadeSpeed, ForceMode.Impulse);
        //_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime);
        //_rigidbodyGrenade.AddForce(_target * GrenadeSpeed, ForceMode.Impulse);
    }
    
}
