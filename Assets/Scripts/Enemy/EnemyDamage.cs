using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]protected float damage;

    protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //When player touch the object that player will take damage
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
