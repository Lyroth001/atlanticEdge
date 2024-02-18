using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MechaController : MonoBehaviour
{
    public Rigidbody rb;
    public float rotateForce = 100;
    public Transform Transform;
    
    public void rotate(float targetSpeed)
    {
        var rotateSpeed = Vector3.Cross(rb.angularVelocity, Transform.up).magnitude;
        
        rb.AddRelativeTorque(new Vector3(0f,0f,rotateForce * Mathf.Sign(targetSpeed-rotateSpeed)));
    }

}
