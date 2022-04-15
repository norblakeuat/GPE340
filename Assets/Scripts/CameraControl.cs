using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // "player" GameObject to connect the camera to a player
    public GameObject player;
    // "sensitivity" float to control the sensitivity of the camera
    public float sensitivity = 20;
    // float "maxFov" to control what the maximum field of view is
    public float maxFov = 90;
    // float "minFov" to control what the minimum field of view is
    public float minFov = 15;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        // "fov" float that's set to the Camera's fieldOfView.
        float fov = Camera.main.fieldOfView; 
         // sets fov as equal to the the Mouse ScrollWheel axis, multiplied by the sensitivity which is multiplied by -1 so that scrolling down zooms out instead of in and vice versa
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity * -1;

        // clamps this so that the fov cannot go past the the minimum/maximum values
        fov = Mathf.Clamp(fov, minFov, maxFov);
        // sets the Camera's fieldOfView as equal to fov, applying the change.
        Camera.main.fieldOfView = fov;
    }
}
