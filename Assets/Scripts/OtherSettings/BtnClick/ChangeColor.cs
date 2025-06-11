using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Button[] buttons;
    private Button lastClickedButton;

    private void Start() 
    {
        foreach(var button in buttons)
        button.onClick.AddListener(()=>ColorChange(button));//Btn OnClick事件

        buttons[2].image.color =new Color32(255,184,77,255);
    }

    private void ColorChange(Button ClickedButton)
    {
       foreach(var button in buttons)
        button.image.color =new Color32(255,255,255,255);//make unclick btn back to white

        ClickedButton.image.color =new Color32(223,139,54,255);//change click btn color

        lastClickedButton=ClickedButton;

         Debug.Log("Color Changed: " + ClickedButton.name);
    }
}
