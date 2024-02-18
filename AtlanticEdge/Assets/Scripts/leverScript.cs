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
    public int rotateSpeed;
    void Start()
    {
        // get interactable
        _grabInteractable = GetComponent<XRGrabInteractable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{this.transform.rotation} + {this.id}");
        // get the x and z rotation of the lever
        float x = transform.localEulerAngles.x;
        float z = transform.localEulerAngles.z;
        // if x rotation is not 0, it is the rotation lever
        // if z rotation is not 0, it is the forward backward lever
        // if x rotation, call to roto chair to rotate
        if (z > 2)
        {
            rotoController.startLeftRotation();
            transform.parent.Rotate(0, rotateSpeed*Time.deltaTime, 0);
        }
        if (z < -2)
        {
            rotoController.startRightRotation();
            transform.parent.Rotate(0, -rotateSpeed*Time.deltaTime, 0);
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
            transform.parent.rotation = Quaternion.Euler(0, transform.parent.rotation.eulerAngles.y, 0);
            
            
            
        }
        else if (!_grabInteractable.interactorsSelecting.Any() || _grabInteractable.interactorsSelecting == null)
        {
            // if not being grabbed, set x to 0
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, z);
            
        }
    }
}
