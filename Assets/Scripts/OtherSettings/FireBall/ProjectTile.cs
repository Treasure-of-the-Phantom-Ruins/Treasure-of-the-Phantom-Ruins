using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
   // 投射物的移動速度
   [SerializeField]private float speed;
   // 投射物的移動方向 (-1 或 1)
   private float direction;
   // 是否已經碰撞
   private bool IsHit;
   // 投射物的存活時間
   private float Lifetime;

   private Animator animator;
   private BoxCollider2D boxCollider2D;


   private void  Awake()
   {
      animator = GetComponent<Animator>();
      boxCollider2D = GetComponent<BoxCollider2D>();
   }

   private void Update()
   {
      // 如果已經碰撞，則不再移動
      if (IsHit) return;

      // 計算移動速度並更新位置
      float Movementspeed = speed * Time.deltaTime * direction;
      transform.Translate(Movementspeed, 0,0);

      // 增加存活時間，若超過 3 秒則停用物件
      Lifetime += Time.deltaTime;
      if(Lifetime > 3)gameObject.SetActive(false);
   }

   // 當投射物與其他物件發生碰撞時觸發
   private void OnCollisionEnter2D(Collision2D other) 
   {
    // 設置為已碰撞狀態，禁用碰撞器並播放爆炸動畫
     IsHit = true;
     boxCollider2D.enabled = false;
     animator.SetTrigger("Explode");
   }

  // 設置投射物的移動方向並初始化相關屬性
   public void SetDirection(float _direction)
   {
      Lifetime = 0 ;
      direction =_direction;
      gameObject.SetActive(true);
      IsHit = false;
      boxCollider2D.enabled = true;

      float localScaleX =transform.localScale.x;
      if(Mathf.Sign(localScaleX) != _direction)
      {
        localScaleX =-localScaleX;
      }

      transform.localScale = new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
   }

   // 停用投射物
   private void Deactivate()
   {
        gameObject.SetActive(false);
   }

}
