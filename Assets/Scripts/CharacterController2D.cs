using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Rigidbody2D player; // Reference to the Rigidbody2D component
    public float speed;        // Assign a constant speed for the Horizontal movement
    public float jumpspeed;    // Assign a constant speed for the jump
    bool jump;                 // Boolean to check the jump state

    public LayerMask whatisground; // Layermask to detect the bollision of the overlap circle drawn for checking a specified object
    public Transform grundcheck;   // A specified point where the overlap circle is created
    public float radius;           // Radius of the circle created to check the layer
    public bool isgrounded;        // Boolean to return the result of the collision

    public int jumptimes;       // Number of times we want to have our player jump on air


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) ) // Checks for the button press
        {
            jump = true; // If the following condition satisfies then our player will jump
        }
        
       
        else
        {
            jump = false; // Jump state changes back to false if the button is not pressed
        }

    }
    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(grundcheck.position, radius, whatisground);// Checks the boolean isgrounded by casting a circle
        if (isgrounded) // Checks for the player grounded
        {
            jumptimes = 2; //Number of jummps player has to make on air
        }
        player.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, player.velocity.y); // A desired velocity is given to the player to move Horizontally
        if (jump && jumptimes > 0) // Checks for the Jump state to make the player jump and the number of jump available to the player
        {
            player.AddForce(new Vector2(player.velocity.x, jumpspeed)); // Add a force to the player if the Jump state is true.
            jumptimes--; // We will reduce the jump each time we press the jump button


        }
        else if (Input.GetKeyDown(KeyCode.W) && isgrounded && jumptimes == 0) // Check the Button pressed and whether the player is grounded
        {                                                                     // and implement the function if the number of jumps available is 0
            player.AddForce(new Vector2(player.velocity.x, jumpspeed)); // Add a force to the player if the Jump state is true.
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)  // Function for the Collision Enter
    {
        if (collision.collider.tag == "spikes") // Checks whether the player is collided to the given tag
        {
            Debug.Log("Player died !!"); // Debugs an message if the player actually collided to the given tag
            Destroy(gameObject);  // Destroy the current gameobject on whic the script is attached
        }
        if (collision.collider.tag == "Exit") // Checks for the player collision with the door or the checkpoint with the given tag
        {
            Debug.Log("Game Won");  // Debugs the message if the player actually collided with the given tag
        }
    }


}

















