using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
     public TMP_InputField[] inputFields; // 輸入框陣列
    private int[] TreasureNum = { 5, 10, 15, 25 }; // 假設的寶藏數值 (未使用)
    public TextMeshProUGUI ResultText; // 顯示結果的文字
    private void Start()
    {
        // 為每個輸入框添加事件監聽器
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.keyboardType = TouchScreenKeyboardType.NumberPad;
            inputField.onValueChanged.AddListener(delegate { Calculate(); });
        }
    }

    // 計算總和
    private void Calculate()
    {
        int num = 0; // 結果變數

        for (int i = 0; i < inputFields.Length; i++)
        {
            string input = inputFields[i].text;

            // 嘗試解析輸入內容
            if (int.TryParse(input, out int parsedValue))
                num += parsedValue*TreasureNum[i]; // 累加有效數值
           
        }

        // 更新結果文字
        ResultText.text = num.ToString();
    }
}
