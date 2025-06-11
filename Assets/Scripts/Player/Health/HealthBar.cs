
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField]private Health Playerhealth;
   [SerializeField]private Image TotalHealthBar;
   [SerializeField]private Image CurrentHealthBar;


   private void Start()
   {
        //setup the player health
        TotalHealthBar.fillAmount = Playerhealth.CurrentHealth /10;
   }
   
   private void Update() 
   {
        //keep update the player health
        CurrentHealthBar.fillAmount = Playerhealth.CurrentHealth /10;
   }
}
