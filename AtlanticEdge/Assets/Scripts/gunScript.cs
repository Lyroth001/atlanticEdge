using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gunButton;
    private gunButton buttonScript;

    public float launchVelocity;
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
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // rotate bullet by 90 degrees
        bullet.transform.Rotate(90, 0, 0);
        Debug.Log(bullet.transform.rotation);
        rb.velocity -= rb.transform.up * launchVelocity;
        Debug.Log(rb.velocity);
    }
}
