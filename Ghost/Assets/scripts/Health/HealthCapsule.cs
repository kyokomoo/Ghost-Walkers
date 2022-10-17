using UnityEngine;

public class HealthCapsule : MonoBehaviour
{
    
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            
            gameObject.SetActive(false);

        }
    }
}