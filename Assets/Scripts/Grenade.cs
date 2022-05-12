using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Collider), typeof(Rigidbody))]

public class Grenade : MonoBehaviour
{
    [SerializeField] Transform _gameObject;
    [SerializeField] Transform PointToShot;
    [SerializeField] public float GrenadeSpeed = 0;
   

    private Rigidbody _rigidbodyGrenade;
   
    
    //private Vector3 _target =A.position - _gameObject.position;
    


    private void awake()
    {
        _rigidbodyGrenade = GetComponent<Rigidbody>();


    }

    void Start()
    {
        //_target = new Vector3(50, transform.position.y, 50);
        
    }

   
    
     void Update()
     {

        //transform.position = Vector3.MoveTowards(transform.position, _target, GrenadeSpeed * Time.deltaTime);
        // gameObject.transform.localPosition = Vector3.Lerp(transform.position, _target, GrenadeSpeed * Time.deltaTime);
        //transform.Translate(0, 0, Time.deltaTime);
        //transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);
        //transform.Translate(transform.forward * GrenadeSpeed * Time.deltaTime);
        //objToSpawn.GetComponent<Rigidbody>().AddForce(Vector3.forward * GrenadeSpeed, ForceMode.Impulse);
        var _target = (PointToShot.position - _gameObject.position);
        transform.Translate(_target * GrenadeSpeed * Time.deltaTime);

        

     }

    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        
        //var gg = GetComponent<SpawnPoint2>();
        //gg._rigidbodyGrenade.AddForce(Vector3.forward * GrenadeSpeed, ForceMode.Impulse);
        //var _target = (A.position - _gameObject.position);
        //_rigidbodyGrenade.AddForce(Vector3.right * GrenadeSpeed, ForceMode.Impulse);
        //_rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime);
        //_rigidbodyGrenade.AddForce(_target * GrenadeSpeed, ForceMode.Impulse);
    }

}

