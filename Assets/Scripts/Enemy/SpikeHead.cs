using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("SpikeHeadAttributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkdelay;
    [SerializeField] private LayerMask playerlayer;
    private float checktimer;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private bool attacking;

    [Header("SFX")]
    [SerializeField]private AudioClip impactSound;

    private void OnEnable()
    {
        //to avoid the spikehead will attack player at first
        stop();
    }


    private void Update()
    {    
        if(attacking)
           transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checktimer += Time.deltaTime;
            if(checktimer > checkdelay )
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        //Check spikehead does see player
        CalculateDirections();
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i],Color.red);
            RaycastHit2D hit =Physics2D.Raycast(transform.position, directions[i],range,playerlayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checktimer = 0 ;
            }
        }

    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range ;//Right direction
        directions[1] = -transform.right * range ;//Left direction
        directions[2] = transform.up * range ;//Up direction
        directions[3] = -transform.up * range ;//Up direction
    }

    private void stop()
    { 
        destination = transform.position;//set destination as current position so it doesn't move
        attacking = false;   
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        SoundManager.instance.PlaySound(impactSound);
        base.OnTriggerEnter2D(other);
        stop();
    }
}
