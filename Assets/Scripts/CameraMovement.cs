using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform Ghost;
    [SerializeField] float MouseSencetivity = 1;
    float y = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xRot = Input.GetAxis("Mouse X");
        var yRot = Input.GetAxis("Mouse Y");


        y -= yRot;
        y = Mathf.Clamp(y, -80, 70);

        Ghost.Rotate(new Vector3(0, xRot * MouseSencetivity, 0));
        transform.localRotation = Quaternion.Euler(y * MouseSencetivity,0,0);
    }
}
