using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class SlidingMenuController : MonoBehaviour
{
    public RectTransform[] buttons; // 要顯示的按鈕
    public GameObject Btn;
    public float slideDistance =200f; // 滑動的距離
    public float slideDuration = 0.5f; // 動畫持續時間
    public float delayTime = 0.5f;
    private bool isExpanded = false;
    public Mask maskComponent; 

    private void Start()
    {
       Btn.SetActive(false);
    }

    //切換菜單的展開與收起狀態
    public void ToggleMenu()
    {
        if (isExpanded)
        {
            foreach (var button in buttons)
            {
                button.DOAnchorPosX(button.anchoredPosition.x + slideDistance, slideDuration);
                 Btn.SetActive(false);
            }
        }
        else
        {
            foreach (var button in buttons)
            {
                button.DOAnchorPosX(button.anchoredPosition.x - slideDistance, slideDuration);
                Btn.SetActive(true);//need to upgrade
            }
        }
        isExpanded = !isExpanded;
    }
}
