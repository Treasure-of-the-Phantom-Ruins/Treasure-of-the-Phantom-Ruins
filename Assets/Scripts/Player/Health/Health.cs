using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]private float StartingHealth;
    public float CurrentHealth{get;private set;}
    private Animator animator;
    public bool dead{get;private set;} = false;

    [Header("iFrames")]
    [SerializeField]private float iFramesDuration;
    [SerializeField]private int numberofFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("Hurt_Sound")]
    [SerializeField]private AudioClip hurtAudio;

    [Header("Death_Sound")]
    [SerializeField]private AudioClip deathAudio;

    [SerializeField]private GameObject losepanel; 

    private void Awake()
    {
       CurrentHealth = StartingHealth;
       animator = GetComponent<Animator>(); 
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0,StartingHealth);

        if (CurrentHealth > 0)
        {
            //Player hurt
            //animator.SetTrigger("Hurt");
            SoundManager.instance.PlaySound(hurtAudio);
            StartCoroutine(Invulnerability());
        }
        else
        {
            //Player die
            if(!dead)
            {
                animator.SetTrigger("Die"); 
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SoundManager.instance.PlaySound(deathAudio);
                StartCoroutine(playerlose());
            }
               
        }
    }

    public void AddHealth(float _health)
    {
        //Add player health when player health between 0 to 3
        CurrentHealth = Mathf.Clamp(CurrentHealth + _health, 0,StartingHealth);
    }

    private IEnumerator Invulnerability()
    {
        //When player  was hurted that will have X seconds invulnerability
        Physics2D.IgnoreLayerCollision(8 , 9,true);
        for (int i = 0; i < numberofFlashes; i++)
        {
            animator.SetTrigger("Hurt");
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
           /*
            spriteRenderer.color = new Color( 1,  0,  0, 0.5f);
            Debug.Log("red");
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRenderer.color = Color.white;
            Debug.Log("white");
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            */
        }
        Physics2D.IgnoreLayerCollision(8 , 9,false);
    }

    private IEnumerator playerlose()
    {
        yield return new WaitForSeconds(2);
        losepanel.SetActive(true);
    }

}
