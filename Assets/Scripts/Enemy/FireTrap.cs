using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField]private float damage;

    [Header("Fire Trap Timer")]
    [SerializeField]private float activationDelay;
    [SerializeField]private float activeTime;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("SFX")]
    [SerializeField]private AudioClip firertrapSound;

    private bool triggered = false;//When the trap gets triggered
    private bool active = false;//When the trap is active and can hurt the player
    private void Awake() 
    {    
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivativeFireTrap());
            }
            if(active)
            {
                other.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivativeFireTrap()
    {
        //turn color to red to notify the player the trap is trigger
        triggered =true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        //Wait for delay,activate trap,turn on animation,return color back to normal 
        spriteRenderer.color = Color.white;
        active = true;
        SoundManager.instance.PlaySound(firertrapSound  );
        animator.SetBool("actived",true);

        //Wait until X seconds, dectivative trap  and reset all variables animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        animator.SetBool("actived",false);
        triggered = false;
    }
}
