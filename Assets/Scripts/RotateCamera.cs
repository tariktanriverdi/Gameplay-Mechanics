using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
     public float rotationSpeed=50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput=Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up*Time.deltaTime*horizontalInput*rotationSpeed);
    }
}
