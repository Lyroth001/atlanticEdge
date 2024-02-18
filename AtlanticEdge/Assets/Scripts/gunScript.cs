using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gunButton;
    private gunButton buttonScript;

    public float launchVelocity = 700f;
    // Start is called before the first frame update
    void Start()
    {
        // get gunButton script
        buttonScript = gunButton.GetComponent<gunButton>();
        // subscribe to button press event
        buttonScript.OnButtonPressed += fire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void fire()
    {
        Debug.Log("firing");
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * launchVelocity);
    }
}
