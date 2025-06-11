using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinReward : MonoBehaviour
{
    public TextMeshProUGUI coin;
    int coinnum;
    private void Start()  
    {
        coinnum = Random.Range(1, 3);
        coin.text= "Reward:\n" + "Small Stone x" + coinnum.ToString();
    }
}
