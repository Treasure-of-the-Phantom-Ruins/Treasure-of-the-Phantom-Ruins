using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinRewardHard : MonoBehaviour
{
   public TextMeshProUGUI coin;
    int coinnum;
    private void Start()  
    {
        coinnum = Random.Range(1, 3);
        coin.text= "Reward:\n" + "Big Stone x" + coinnum.ToString() + "\n" + " Key Stone x1";
    }
}
