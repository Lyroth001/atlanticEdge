using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float lifeSpan = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan *= Time.deltaTime;
        if (lifeSpan > 20.0f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        {
            // debug log the object that the bullet collided with
            Debug.Log($"object: {other.gameObject.name}");
            Destroy(this.gameObject);
        }
    }
}
