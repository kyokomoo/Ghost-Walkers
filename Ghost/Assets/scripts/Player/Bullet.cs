using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletDamage = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = transform.right * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

	  if (collision.gameObject.tag.Equals("Enemy")) 
		collision.gameObject.GetComponent<Health>().TakeDamage(1);
    }



}
