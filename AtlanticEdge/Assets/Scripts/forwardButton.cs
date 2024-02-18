using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class forwardButton : MonoBehaviour
{
    public delegate void buttonPressed();
    private XRSimpleInteractable simpleInteractable;
    public event buttonPressed OnButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (simpleInteractable.interactorsSelecting.Any())
        {
            Debug.Log("Forward Button Pressed");
            OnButtonPressed?.Invoke();
        }
    }
}
