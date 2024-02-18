using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class gunButton : MonoBehaviour
{
    public delegate void buttonPressed();
    public event buttonPressed OnButtonPressed;
    private XRSimpleInteractable simpleInteractable;
    public float fireRate;
    private float lastShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        // if touched by XR controller, throw button pressed event
        if (simpleInteractable.interactorsSelecting.Any())
        {
            if (Time.time > fireRate + lastShot)
            {
             OnButtonPressed?.Invoke();
             lastShot = Time.time;
            }
            
        }
        
    }
    
}
