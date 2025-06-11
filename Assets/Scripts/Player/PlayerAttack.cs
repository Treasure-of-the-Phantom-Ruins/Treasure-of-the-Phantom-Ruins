using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttackCoolDown;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject[] FireBalls;
    [SerializeField] private AudioClip swingswordSound;

    private PlayerMovement playerMovement;
    private Animator animator;
    private float CoolDownTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {   //Input.GetMouseButtonDown(0)
        //notify player attack event
        if(Input.GetKeyDown("f") && CoolDownTimer > AttackCoolDown && playerMovement.CanAttack())
        {
            Attack();
        }
        CoolDownTimer += Time.deltaTime;

        
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(swingswordSound);
        animator.SetTrigger("Attack");
        CoolDownTimer = 0 ;

        FireBalls[FindFireBall()].transform.position = FirePoint.position;
        FireBalls[FindFireBall()].GetComponent<ProjectTile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireBall()
    {
        for(int i=0; i<FireBalls.Length;i++)
        {
            //ex:if fireball[2] is inhierachy that can use it
            if(!FireBalls[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
