using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // four public gameObjects, named "forwardButton", "backwardButton", "leftButton", and "rightButton"
    public GameObject forwardButton;
    public GameObject backwardButton;
    public GameObject leftButton;
    public GameObject rightButton;
    public int rotateAngle;
    public int moveDistance;
    private leftButton lButtonScript;
    private rightButton rButtonScript;
    private forwardButton fButtonScript;
    private backwardButton bButtonScript;
    void Start()
    {
        lButtonScript = leftButton.GetComponent<leftButton>();
        
        lButtonScript.OnButtonPressed += turnLeft;
        rButtonScript = rightButton.GetComponent<rightButton>();
        rButtonScript.OnButtonPressed += turnRight;
        fButtonScript = forwardButton.GetComponent<forwardButton>();
        fButtonScript.OnButtonPressed += moveForward;
        bButtonScript = backwardButton.GetComponent<backwardButton>();
        bButtonScript.OnButtonPressed += moveBackward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turnLeft()
    {
        Debug.Log("turning left");
        // if the left button is pressed, rotate the robot left
        transform.Rotate(0, -rotateAngle*Time.deltaTime, 0);
    }
    void turnRight()
    {
        Debug.Log("turning right");
        // if the right button is pressed, rotate the robot right
        transform.Rotate(0, rotateAngle*Time.deltaTime, 0);
    }
    void moveForward()
    {
        Debug.Log("moving forward");
        // if the forward button is pressed, move the robot forward
        transform.Translate(0, 0, moveDistance*Time.deltaTime);
    }
    void moveBackward()
    {
        Debug.Log("moving backward");
        // if the backward button is pressed, move the robot backward
        transform.Translate(0, 0, -moveDistance*Time.deltaTime);
    }
}
