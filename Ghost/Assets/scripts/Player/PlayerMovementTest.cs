using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{

    //allows us to change speed variable in inspector even it is private to read/write
    [SerializeField]

    public float speed = 3.5f;

    public float jumpspeed = 5f;

    public bool isGrounded;

    private float direction = 0f;

    private SpriteRenderer sprite;

    private Rigidbody2D player;

    private BoxCollider2D box;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        box = GetComponent<BoxCollider2D>();
        isGrounded = true;
        isGrounded = false;


    }



    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo;


        hitInfo = Physics2D.Raycast(transform.position - new Vector3(0, sprite.bounds.extents.y, 0), Vector2.down, -0.327f);



        if (hitInfo)
        {

            isGrounded = true;


        }

        else
        {

            isGrounded = false;


        }


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
            player.velocity = new Vector2(player.velocity.x, jumpspeed);
        }

      

        
        



    }

}