using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{

    //allows us to change speed variable in inspector even it is private to read/write
    [SerializeField]

    public float distanceToCheck = 0.3f;

    public float speed = 3.5f;

    public float jumpspeed = 7f;

    public bool isGrounded;

    private float direction = 0f;

    private SpriteRenderer sprite;

    private Rigidbody2D player;

    public LayerMask groundlayer;



    //For animator
    UnityEngine.AI.NavMeshAgent _agent;
    Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();


         //For the animator controller
	  _animator = GetComponentInChildren<Animator>();
	  _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

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


        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck, groundlayer))
        {
            isGrounded = true;

        }

        else
        {
            isGrounded = false;
        }




        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpspeed);
        }



	  //For animator controller
	  float speedPercent = _agent.velocity.magnitude / _agent.speed;
 		_animator.SetFloat("speed", speedPercent);


    }

}