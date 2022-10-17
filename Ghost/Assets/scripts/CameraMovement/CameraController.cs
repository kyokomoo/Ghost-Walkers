using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float lookAhead;

    private float currentPosX;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;


  
    private void Update()
    {
     
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
       
    }

    public void MoveToNewRoom(Transform follow)
    {
        currentPosX = follow.position.x;
    }
}