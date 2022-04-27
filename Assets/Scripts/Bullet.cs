using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 1;
            
    public Vector3 TargetPos 
    {
        get => _targetPos;
        set
        {
            _isShooted = true;
            _targetPos = value;
        }
    }

    private bool _isShooted = false;
    private Vector3 _targetPos;

    // Update is called once per frame
    void Update()
    {
        if(_isShooted && Vector3.Distance(transform.position, _targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, BulletSpeed * Time.deltaTime);
        }
    }
}
