using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public Button myButton;
    public float delayTime = 1f;// 延遲時間

    private void Start()
    {
       myButton.onClick.AddListener(DisableButton);//Btn OnClick事件
    }

    private void DisableButton()
    {
        myButton.interactable = false; // 初始設置不可交互
        Invoke("EnableButton", delayTime); // 延遲啟用
    }
    private void EnableButton()
    {
        myButton.interactable = true; // 啟用按鈕
    }
}
