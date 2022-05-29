using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for controlling camera movement
public class CameraController : MonoBehaviour
{
    public Transform player; // Mario's Transform
    public Transform endLimit; // GameObject that indicates the end of map
    private float offset; // initial x-offset between camera and Mario
    private float startX; // smallest x-coordinate of the Camera
    private float endX; // largest x-coordinate of the camera
    private float viewportHalfWidth;

    void Start()
    {
        // get coordinate of the bottomleft of the Camera viewport
        // z doesn't matter since the camera is orthographic
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        viewportHalfWidth = Mathf.Abs(bottomLeft.x - this.transform.position.x); // this actually refers to the Camera Controller script which is placed inside the Main Camera

        offset = this.transform.position.x - player.position.x; //offset in X or horizontal between the camera position and the player's x position
        startX = this.transform.position.x; // camera's starting X position
        endX = endLimit.transform.position.x - viewportHalfWidth;
    }

    void Update()
    {
        float desiredX = player.position.x + offset;
        // check if desiredX is within startX and endX, still withing the Camera's smallest and largest coordinate
        if (desiredX > startX && desiredX < endX)
            this.transform.position = new Vector3(desiredX, this.transform.position.y, this.transform.position.z); //move the camera horizontally, while keeping the y and z position
    }
}
