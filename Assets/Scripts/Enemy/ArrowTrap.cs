using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]private float AttackCooldown;
    [SerializeField]private Transform firepoint;
    [SerializeField]private GameObject[] arrows;
    private float CooldownTimer;

    [Header("SFX")]
    [SerializeField]private AudioClip arrowSound;


    private void Update() 
    {    
        CooldownTimer += Time.deltaTime;

        if (CooldownTimer >= AttackCooldown)
            Attack();
    }


    private void Attack()
    {
        CooldownTimer = 0;

        SoundManager.instance.PlaySound(arrowSound);
        arrows[FindArrow()].transform.position = firepoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivativeProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
           if(!arrows[i].activeInHierarchy)
           {
             return i;
           } 
        }
        return 0;
    }
}
