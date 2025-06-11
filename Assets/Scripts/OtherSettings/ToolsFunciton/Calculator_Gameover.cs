using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Calculator_Gameover : MonoBehaviour
{
    public TMP_InputField[] inputFields; // 輸入框陣列
    private int[] TreasureNum = { 5, 10, 15, 25 }; // 假設的寶藏數值
    public TextMeshProUGUI ResultText; // 顯示結果的文字
    public TextMeshProUGUI PlayerText; // 顯示結果的文字
    public Button nextBtn; // 下一步按鈕
    private int[] num; // 用於存儲每次計算結果的陣列
    private int j = 0; // 當前索引

    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI winnernumText;
    public GameObject gameoverPanel;
    public GameObject WinnerPanel;

    private void Start()
    {
        // 初始化數組大小
        num = new int[inputFields.Length];

        // 為每個輸入框添加事件監聽器
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.keyboardType = TouchScreenKeyboardType.NumberPad;//設定使用者輸入模式為數字鍵盤
            inputField.onValueChanged.AddListener(delegate { Calculate(); });//設定監聽事件，當任意數值改變時，改變總和
        }

        // 為 nextBtn 添加點擊事件
        nextBtn.onClick.AddListener(() =>
        {
            // 判斷是否是最後一位玩家
            if (j >= num.Length - 1)
            {
                final(); // 執行結果計算
                nextBtn.interactable = false; // 禁用按鈕
            }
            else
            {
                j = Nextone(j);//nextone 
                PlayerText.text = "Player " + (j + 1); // 顯示下一位玩家
                ResetInputs();//清空輸入框
            }
        });

        PlayerText.text = "Player 1"; // 初始化玩家文字
    }

    // 計算總和
    private void Calculate()
    {
        int register = 0; // 結果變數

        for (int i = 0; i < inputFields.Length; i++)
        {
            string input = inputFields[i].text;
            // 嘗試解析輸入內容
            if (int.TryParse(input, out int parsedValue))
                register += parsedValue * TreasureNum[i]; // 累加有效數值
        }

        ResultText.text = register.ToString(); // 更新結果文字

        // 存儲當前結果到 num[j]
        num[j] = register;
    }

    // 下一個索引
    public int Nextone(int index) // index = j
    {
        return index + 1; // 返回下一個索引
    }

    // 重置輸入框內容
    private void ResetInputs()
    {
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.text = ""; // 清空輸入框
        }

        ResultText.text = "0"; // 重置結果文字
    }

    // 計算並顯示最終結果
    private void final()
    {
        int max = 0;
        int maxnum = 0;
        int checknum = 0;
        bool isSame = true;
        for(int i = 0; i < num.Length;i++)
        {
            if (num[i]>= checknum)
            checknum=num[i];
            if(num[i]!=checknum)
            isSame = false;
        }
        if(isSame == true)
        {
            gameoverPanel.SetActive(false);
            WinnerPanel.SetActive(true);
            winnerText.text = "Winner is AllPlayer " ;
            winnernumText.text = "Score: " + num[0].ToString();
            return;
        }
        //檢查最大值
        for (int i = 0; i < num.Length; i++)
        {
            if (max < num[i])
            {
                max = num[i];
                maxnum = i;
            }
        }
        gameoverPanel.SetActive(false);
        WinnerPanel.SetActive(true);
        winnerText.text = "Winner is Player " + (maxnum + 1).ToString();
        winnernumText.text = "Score: " + max.ToString();
    }
}
