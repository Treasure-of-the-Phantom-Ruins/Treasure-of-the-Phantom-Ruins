using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will damage the player every time they touch
public class EnemyProjectile : EnemyDamage
{
   [SerializeField]private float speed;
   [SerializeField]private float resettime;
   private float lifetime;


   public void ActivativeProjectile()
   {
        lifetime = 0;
        gameObject.SetActive(true);
   }

   private void Update() 
   {
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed ,0 ,0 );
        //transform.Translate( 0,movementspeed ,0 );

        lifetime += Time.deltaTime; 
        if(lifetime > resettime)
        {
            gameObject.SetActive(false);
        }
   }

   protected override void OnTriggerEnter2D(Collider2D other) 
   {
          base.OnTriggerEnter2D(other);//code will run the parent first 
          gameObject.SetActive(false);//when arrow hit anything that will disappear 
   }
}
