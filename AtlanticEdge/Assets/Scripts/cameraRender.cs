using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shader myShader = Shader.Find("/Assets/Shaders/oceanFog.shader");
        Camera.main.RenderWithShader(myShader, "RenderType");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
