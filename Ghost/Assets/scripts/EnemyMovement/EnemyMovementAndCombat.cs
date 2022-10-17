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
    bool attack = false;

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
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
      //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
      //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
        setWallLeft(_wallLeft);
        setWallRight(_wallRight);
    }

    // Update is called once per frame
    void Update()
    {



	  //walkAmount.x = walkingDirection * getMoveSpeed() * Time.deltaTime;
	  if (!attack)
        {
        	if (this.transform.position.x >= getWallRight())
      		  walkingDirection = -1.0f;
        	else if (this.transform.position.x <= getWallLeft())
      	        walkingDirection = 1.0f;

       	this.transform.position += new Vector3(walkingDirection * getMoveSpeed() * Time.deltaTime, 0f, 0f);
   	   }
 

	 
        if (checkFollowRadius(playerTransform.position.x,transform.position.x))
        {
            attack = true;
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("AttackA", true);
        		  FindObjectOfType<Player>().GetComponent<Health>().AddHealth(-getAttackDamage());
            
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
            else if(playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("AttackA", true);
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
}