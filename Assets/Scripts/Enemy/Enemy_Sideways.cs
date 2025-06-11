using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField]private float movementDistance;
    [SerializeField]private float speed;
    [SerializeField]private float damage;
    private bool moveleft;
    private float leftedge;
    private float rightedge;

    private void Awake()
    {
        leftedge =transform.position.x - movementDistance;
        rightedge = transform.position.x + movementDistance;
    }


    private void Update()
    {
        if(moveleft)
        {
            //when object move before the left edge that can keep move to left
            if(transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime  ,transform.position.y,transform.position.z);
            }
            else
            {
                moveleft =false;
            }
        }
        else
        {
            //when object move before the right edge that can keep move to right
            if(transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime  ,transform.position.y,transform.position.z);  
            }
            else
            {
                moveleft =true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //When player touch the object that player will take damage
        if(other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }    
    }
}
