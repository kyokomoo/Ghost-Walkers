using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
   private Animator anim;
    
    private bool dead;
    private bool death;
    float timer;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;


    public GameManagerScript gameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
           // anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            death = false;
            //SoundManager.instance.PlaySound(hurtSound);
        }
        
        else
        {
		if (gameObject.tag == "Enemy")
        {
            
            gameObject.GetComponent <Animator>().SetBool("death", true);
           
            //gameObject.GetComponent <Animator>().SetBool("death", false);
			Destroy(gameObject, 1.4f);
            
        }
            if (!dead)
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("dead", currentHealth == 0);
                //anim.SetTrigger("die");
                
                //Destroy(gameObject);

                //LevelManager.instance.Respawn();

                gameManager.gameOver();


                //SoundManager.instance.PlaySound(deathSound);

                
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

   
   
}