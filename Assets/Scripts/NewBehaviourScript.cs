using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float VisionRadius = 0;
    [SerializeField] Transform Ghost;
    [SerializeField] Transform Sphere;
    [SerializeField] Transform AmmoHead;
    [SerializeField] float RotationSpeed = 1;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float CooldownTime;
   

    private SphereCollider _visionCollider;
    private Transform _playerPos;
    private float _currentTime;

    // Start is called before the first frame update

    void Awake()
    {
        _visionCollider = GetComponent<SphereCollider>();
    }

    void Start()
    {
        _visionCollider.radius = VisionRadius;
        _currentTime = CooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerPos != null)
        {
            _currentTime += Time.deltaTime;
            var rotDirection = Ghost.position - Sphere.position;
            Sphere.rotation = Quaternion.LookRotation(rotDirection.normalized);
        }

        
        


    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player")) 
        {
            _playerPos = other.gameObject.transform;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _currentTime >= CooldownTime)
        {
            var bullet = Instantiate(BulletPrefab, AmmoHead.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().TargetPos = _playerPos.position;
            _currentTime = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerPos = null;
        }
    }
}
