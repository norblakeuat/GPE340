using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField, Tooltip("The max speed of the player")]
    // "speed" float meant to control the speed the player moves at
    private float speed = 4f;
    // "originalSpeed" float meant for setting the speed back to its original speed after sprinting
    private float originalSpeed = 4f;
    [SerializeField, Tooltip("The speed multiplier given by sprinting to the player")]
    // "sprintspeed" float meant for multiplying the original speed by this value.
    private float sprintSpeed = 2f;
    // "animator" variable for using animations in the Animator
    private Animator animator;

    
    
    [SerializeField, Tooltip("Control Character rotation sensitivity")]
    // "sensitvity" float meant for controlling the sensitivity of player rotation
    public float sensitivity;

    // Start is called before the first frame update
    private void Awake()
   {
        // Gets the animator component for use.
        animator = GetComponent<Animator>();
        
   }

    // Update is called once per frame
   private void Update()
   {
        // creates new Vector3 "input" for player's Horizontal/Vertical movement input
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        // Clamps the input so the player doesn't move faster when moving diagonally
        input = Vector3.ClampMagnitude(input, 1f);
        // Multiplies the input by speed float
        input *= speed;
        // applies x value for Horizontal(left/right) parameters
        animator.SetFloat("Horizontal", input.x);
        // applies z value for Vertical (up/down) parameters
        animator.SetFloat("Vertical", input.z);
        
        // if the player presses and holds the left shift key, run this code block
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // sets Boolean "IsSprinting" in the animator to true so that the player enters the sprinting animation
            animator.SetBool("IsSprinting", true);
            // multiplies speed by sprintSpeed float
            speed *= sprintSpeed;
            // multiplies input by the new speed
            input *= speed;
            // print to show that the player is sprinting 
            print("you are sprinting!");
           


        }
        // if the user lets go of the left shift key, run this code block
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // sets the speed back to its original value
            speed = originalSpeed;
            // sets the input back to the original value
            input *= speed;
            // sets "IsSprinting" as false so that the player stops sprinting
            animator.SetBool("IsSprinting", false);
            // print to show that the player is not sprinting
            print("you are not sprinting!");
        }

        // rotateHorizontal float that uses the player's horizontal mouse movement to rotate the player
        float rotateHorizontal = Input.GetAxis("Mouse X");
        // Rotates the player, multiplied by the sensitivity float value
        transform.RotateAround(transform.position, Vector3.up, rotateHorizontal * sensitivity);


   }
    
}
