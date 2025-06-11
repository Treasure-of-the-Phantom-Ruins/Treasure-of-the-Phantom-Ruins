using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private AudioClip boxopenSound;//Use SerializeField is make private variable can edit outside
    public GameObject RewardScreen;
    [SerializeField]private GameObject treasure;
    private void Awake() 
    {    
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)//To detect the player
    {
        if(other.tag == "Player")
        {
           StartCoroutine(Touched());//When the player touches the box,the box will open
        }

    }

    private IEnumerator Touched()
    {
        animator.SetBool("touched", true);
        SoundManager.instance.PlaySound(boxopenSound);//Play the sound of the box opening
        yield return new WaitForSeconds(0.5f);//Wait for 0.5 seconds
        //Delay 0.5 seconds to make sure the animation of the box opening is complete
        yield return new WaitForSeconds(3);//Wait for 3 seconds
        RewardScreen.SetActive(true);//Shoe the reward screen
        
    }
}
