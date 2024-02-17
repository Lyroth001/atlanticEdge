using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RotoController rotoController;
    void Start()
    {
        
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
        if (z != 0)
        {
            rotoController.;
        }
        
    }
}
