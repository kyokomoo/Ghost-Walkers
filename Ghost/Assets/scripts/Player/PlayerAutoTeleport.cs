using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Auto"))
        {
            if (currentTeleporter == null)
            {
                currentTeleporter = collision.gameObject;
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter Auto"))
        {
            if (collision.gameObject != currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
