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

    public bool isWall;

    private float direction = 0f;

    private SpriteRenderer sprite;

    private Rigidbody2D player;

    private float wallJumpCooldown;



    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private LayerMask wallLayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        isGrounded = true;

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


        RaycastHit2D hitInfo;

        RaycastHit2D wallCheck;

        Vector2 boxSize = new Vector2(0.25f, 0.01f);

        hitInfo = Physics2D.BoxCast(transform.position - new Vector3(0, sprite.bounds.extents.y + boxSize.y + 0.01f, 0), boxSize, 0, Vector2.down, boxSize.y, groundLayer);

        wallCheck = Physics2D.BoxCast(transform.position - new Vector3(0, sprite.bounds.extents.y + boxSize.y + 0.01f, 0), boxSize, 0, Vector2.down, boxSize.y, wallLayer);


        if (hitInfo)
        {

            isGrounded = true;
        }

        else
        {

            isGrounded = false;
        }

        if (wallCheck)
        {

            isWall = true;
        }

        else
        {

            isWall = false;
        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity = new Vector3(player.velocity.x, jumpspeed);
        }



        if (Input.GetButtonDown("Jump") && isWall)
        {
  
            player.velocity = new Vector2(player.velocity.y , jumpspeed);
        }



    }

}