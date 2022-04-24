using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float VisionRadius = 10;
    [SerializeField] Transform Ghost;
    [SerializeField] Transform Sphere;
   

    private SphereCollider _visionCollider;

    // Start is called before the first frame update

    void Awake()
    {
        _visionCollider = GetComponent<SphereCollider>();
    }

    void Start()
    {
        _visionCollider.radius = VisionRadius;
    }

    // Update is called once per frame
    void Update()
    {

        var rotDirection = Ghost.position - Sphere.position;

        //Turret.forward = rotDirection; 
        Sphere.rotation = Quaternion.LookRotation(rotDirection.normalized);
        
    }
}
