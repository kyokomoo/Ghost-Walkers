using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{
    public static MusicControllerScript instance; // Creates a static varible for a MusicControlScript instance

    private void Awake() // Runs before void Start()
    {

        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }
}