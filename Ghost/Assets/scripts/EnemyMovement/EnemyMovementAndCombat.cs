using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAndCombat : Enemies
{

//variables
    public int _moveSpeed;
    public int _attackDamage;
    public  int _lifePoints;
    public float _attackRadius;
    public float _wallLeft;
    public float _wallRight;
    public float _walkDistance;
    bool attack = false;
    float timer;
    float startPosition;

    float walkingDirection = 1.0f;


    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim; 

    SpriteRenderer enemySR;
    Vector3 walkAmount;

    void Start()
    {
      //get the player transform   
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
      //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
	  startPosition = this.transform.position.x;
      //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
	  setWalkDistance(_walkDistance);
        setWallLeft(_wallLeft);
        setWallRight(_wallRight);
    }

    // Update is called once per frame
    void Update()
    {



	  //walkAmount.x = walkingDirection * getMoveSpeed() * Time.deltaTime;
	  if (!attack)
        {
        	if (this.transform.position.x >= startPosition + getWalkDistance()) {
      		  walkingDirection = -1.0f;
			  //enemySR.flipX = true;
		}
        	else if (this.transform.position.x <= startPosition - getWalkDistance()) {
      	        walkingDirection = 1.0f;
			  //enemySR.flipX = false;
		}

		if (walkingDirection > 0)
			enemySR.flipX = false;
		else
			enemySR.flipX = true;

       	this.transform.position += new Vector3(walkingDirection * getMoveSpeed() * Time.deltaTime, 0f, 0f);
   	   }
 

	 
        if (checkFollowRadius(playerTransform.position.x,this.transform.position.x))
        {
            attack = true;
            //if player in front of the enemies
            if (playerTransform.position.x < this.transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, this.transform.position.x))
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
			  timer += Time.deltaTime;
			  if (timer > 2) {
        		  	GameObject.FindWithTag("Player").GetComponent<Health>().TakeDamage(getAttackDamage());
				timer = 0;
			  }
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("AttackA", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = true;
                }

            }
            //if player is behind enemies
            else if(playerTransform.position.x > this.transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, this.transform.position.x))
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
			  timer += Time.deltaTime;
			  if (timer > 2) {
        		  	GameObject.FindWithTag("Player").GetComponent<Health>().TakeDamage(getAttackDamage());
				timer = 0;
			  }
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("AttackA", false);
                    //walk
                    enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = false;
                }


            }
        }
        else
        {
            //enemyAnim.SetBool("Walking", false);
		attack = false;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            //GetComponent<Health>().TakeDamage(1);
		Destroy(gameObject);
            
            //gameObject.SetActive(false);

        }
    }

}