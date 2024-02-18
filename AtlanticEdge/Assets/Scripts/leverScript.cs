using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class leverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RotoController rotoController;
    public int id;
    private XRGrabInteractable _grabInteractable = null;
    void Start()
    {
        // get interactable
        _grabInteractable = GetComponent<XRGrabInteractable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the x and z rotation of the lever
        float x = transform.localEulerAngles.x;
        float z = transform.localEulerAngles.z;
        // if x rotation is not 0, it is the rotation lever
        // if z rotation is not 0, it is the forward backward lever
        // if x rotation, call to roto chair to rotate
        if (z != 0 & z>0)
        {
            rotoController.startLeftRotation();
            transform.parent.Rotate(0, -20, 0);
        }
        if (z != 0 & z<0)
        {
            rotoController.startRightRotation();
            transform.parent.Rotate(0, 20, 0);
        }
        //if(z == 0)
        //{
            //rotoController.stopRotation();
        //}

        if ((!_grabInteractable.interactorsSelecting.Any() || _grabInteractable.interactorsSelecting == null) & id == 0)
        {
            // if not being grabbed, set z to 0
            transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, 0);
            // stop cockpit rotation
            transform.parent.Rotate(0, 0, 0);
            
            
            
        }
        else if (!_grabInteractable.interactorsSelecting.Any() || _grabInteractable.interactorsSelecting == null)
        {
            // if not being grabbed, set x to 0
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, z);
            
        }
    }
}
