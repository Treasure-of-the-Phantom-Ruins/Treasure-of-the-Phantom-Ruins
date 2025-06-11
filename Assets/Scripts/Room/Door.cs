using UnityEngine;
using UnityEngine.Animations;

public class Door : MonoBehaviour
{
    [SerializeField]private Transform PreviousRoom;
    [SerializeField]private Transform NextRoom;
    [SerializeField]private CameraController Cam;
    //[SerializeField]private BoxCollider2D Collider;

     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(other.transform.position.x < transform.position.x)
            {
               //Cam.MoveToNextRoom(NextRoom);
                NextRoom.GetComponent<Room>().ActivateRoom(true);
                PreviousRoom.GetComponent<Room>().ActivateRoom(false);
               // Collider.isTrigger=false;
            } 
            else
            {
               // Cam.MoveToNextRoom(PreviousRoom);
                NextRoom.GetComponent<Room>().ActivateRoom(false);
                PreviousRoom.GetComponent<Room>().ActivateRoom(true);
            }
               
        }
        
    }
}
