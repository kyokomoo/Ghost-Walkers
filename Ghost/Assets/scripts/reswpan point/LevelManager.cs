using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{

        public static LevelManager instance;

        public Transform respawnPoint;
          
        public GameObject playerPrefab;

        public CinemachineVirtualCameraBase cam;


    public void Awake()

    {
        instance = this;
    }



    // Start is called before the first frame update
    public void Respawn()
    {

       GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
       
       cam.Follow = player.transform;


    }

    
}
