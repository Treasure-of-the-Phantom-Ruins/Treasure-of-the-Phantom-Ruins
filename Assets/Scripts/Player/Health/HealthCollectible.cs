using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField]private float healthvalue;
    [Header("SFX")]
    [SerializeField]private AudioClip colectiableSound;
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlaySound(colectiableSound);
            other.GetComponent<Health>().AddHealth(healthvalue);
            gameObject.SetActive(false);
        } 
   }
}
