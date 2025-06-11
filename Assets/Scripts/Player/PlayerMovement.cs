using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D body;
   private BoxCollider2D boxCollider;
   private Animator animator;
   [SerializeField]private LayerMask WallLayer;
   [SerializeField]private LayerMask groundLayer;
   [SerializeField]private int Gravity;
   [SerializeField]private int GravitySlide;
   [SerializeField]private float Speed;
   [SerializeField]private float JumpPower;
   private float WallJumpCooldown;
   private float HorizontalInput;
   private float buttonInput;

   [Header("SFX")]
    public AudioClip jumpSound;
   
   private void Awake() 
   {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
   }

   private void Update() 
   {    
        float keyboardInput = Input.GetAxis("Horizontal");

        // 結合按鈕輸入與鍵盤輸入
        HorizontalInput = Mathf.Clamp(buttonInput + keyboardInput, -1f, 1f);


        //Flip the character when moving right or left
        if(HorizontalInput > 0.01f )
        {
          transform.localScale =  new Vector3( 0.2f, 0.2f , 0.2f );
        }
        else if(HorizontalInput < -0.01f )
        {
          transform.localScale =  new Vector3( -0.2f, 0.2f , 0.2f );
        }
        
        //set animator parameters
        animator.SetBool("Run", HorizontalInput != 0);
        animator.SetBool("Grounded",isGrounded());

        //Wall jump logic
        if(WallJumpCooldown > 0.2f)
        {
          body.velocity = new  Vector2(HorizontalInput * Speed , body.velocity.y);

          if ( OnWall() && !isGrounded() )
          {
               body.gravityScale = GravitySlide;
               body.velocity =Vector2.zero;
               
          }
          else
          {
               body.gravityScale = Gravity;
          }
          if (Input.GetKeyDown("space"))
          {
               PerformJump();
          }
              
        }
        else 
        {
           WallJumpCooldown +=Time.deltaTime;
        }
        
   }

    public void SetHorizontalInput(float input)
     {
          if(input !=0)
          {
               Debug.Log("I Got input:"+input);
          }
          buttonInput  = input;
     }

     public void PerformJump()
     {
          Jump();
               if(isGrounded())
               {
                    SoundManager.instance.PlaySound(jumpSound);
               }
     }
     
   private void Jump()
   {
     if(isGrounded())
     {
          body.velocity = new Vector2(body.velocity.x,JumpPower);
          animator.SetTrigger("Jump");   
     }
     
      if(OnWall() && !isGrounded())
     {
          if(HorizontalInput == 0)
          {
               body.velocity =new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
               //transform.localScale = new Vector3(-Mathf.Sign(0.2f),0.2f,0.2f);
          }
          else
          {
               body.velocity =new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 8);
          }
          WallJumpCooldown = 0;
          
     }
   }

   /*private void Wall_Behavior()
   {
     if(OnWall() && !isGrounded())
     {
          animator.SetTrigger("OnWall");
          if(HorizontalInput == 0)
          {
               body.velocity =new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
               transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x),transform.localScale.y,transform.localScale.z);
          }
          else
          {
               body.velocity =new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 8);
          }
          WallJumpCooldown = 0;
          
     }
   }*/

   private bool isGrounded()
   {
     RaycastHit2D raycastHit2D= Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
     return raycastHit2D.collider != null;
   }

   private bool OnWall()
   {
     RaycastHit2D raycastHit2D= Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,new Vector2(transform.localScale.x,0),0.1f,WallLayer);
     return raycastHit2D.collider != null;
   }

   public bool CanAttack()
   {
     return HorizontalInput == 0 && isGrounded() && !OnWall();
   }

    

}
