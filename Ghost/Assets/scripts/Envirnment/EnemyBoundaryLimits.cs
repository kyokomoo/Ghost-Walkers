using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundaryLimits : MonoBehaviour
{

    
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
