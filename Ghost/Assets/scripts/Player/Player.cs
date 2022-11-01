using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //allows us to change speed variable in inspector even it is private to read/write
    [SerializeField]

    public float speed = 3.5f;

    public float jumpspeed = 3f;

    public bool isGrounded;

    public int jumpCount = 0;


    private float direction = 0f;

    private SpriteRenderer sprite;

    private Rigidbody2D player;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        isGrounded = true;

        isGrounded = false;
    }



    public void Jump() 
    {
	
        jumpCount++;

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
	  isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
 


    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxis("Horizontal");

        if (direction > 0f && Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }

        else if (direction < 0f && Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }

        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity = new Vector3(player.velocity.x, jumpspeed);
        }



 

    }

}