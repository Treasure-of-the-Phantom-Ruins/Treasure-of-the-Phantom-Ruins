using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StoneSelect : MonoBehaviour
{
    public GameObject Btnpanel;
    public Button[] buttons;
    public GameObject[] Btns;
    public GameObject[] images;
    public GameObject KeysPanel;
    public Transform canvasTransform;
    public GameObject panelPrefab;
    private const string JsonFileName = "ActiveImages.json";

    private void Awake()
    {
        LoadArrayData();
        int i = 0;
        foreach (var Button in buttons)
        {
            BtnHandle(Button, i);
            i++;
        }
    }

    private void BtnHandle(Button Btn, int index)
    {
        Btn.onClick.AddListener(() => { CreatePanel(index); });
    }

    private void appear(int index, GameObject panel)
    {
        Debug.Log(index);
        Destroy(panel);
        Btns[index].SetActive(false);
        images[index].SetActive(true);
        KeysPanel.SetActive(false);
        SaveArrayData();
        Btnpanel.SetActive(true);
    }

    public void SaveArrayData()
    {
        // 建立一個數據結構來儲存
        List<bool> imageStates = new List<bool>();
        foreach (var image in images)
        {
            imageStates.Add(image.activeSelf);
        }

        // 將數據轉換成 JSON 字串
        string json = JsonUtility.ToJson(new SaveData { states = imageStates });
        string path = Path.Combine(Application.persistentDataPath, JsonFileName);

        // 儲存到檔案
        File.WriteAllText(path, json);
        Debug.Log("Data saved to: " + path);
    }

    public void LoadArrayData()
    {
        string path = Path.Combine(Application.persistentDataPath, JsonFileName);
        if (File.Exists(path))
        {
            // 從檔案讀取 JSON 字串
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // 將數據載入到遊戲物件
            for (int i = 0; i < images.Length; i++)
            {
                if (i < saveData.states.Count)
                {
                    images[i].SetActive(saveData.states[i]);
                    Btns[i].SetActive(!saveData.states[i]);
                }
            }
            Debug.Log("Data loaded from: " + path);
        }
        else
        {
            Debug.Log("No save file found at: " + path);
        }
    }
    public static void ClearJsonData()
    {
        string path = Path.Combine(Application.persistentDataPath, JsonFileName);

        // 建立空的 SaveData 結構
        SaveData emptyData = new SaveData { states = new List<bool>() };

        // 將空數據儲存到檔案
        string json = JsonUtility.ToJson(emptyData);
        File.WriteAllText(path, json);

        Debug.Log("JSON data cleared: " + path);
    }
    public void CreatePanel(int index)
    {
        Btnpanel.SetActive(false);
        if (panelPrefab != null && canvasTransform != null)
        {
            GameObject newPanel = Instantiate(panelPrefab, canvasTransform);
            Button yesButton = newPanel.transform.Find("YesBtn").GetComponent<Button>();
            Button noButton = newPanel.transform.Find("NoBtn").GetComponent<Button>();

            newPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            if (yesButton != null)
            {
                yesButton.onClick.AddListener(() => appear(index, newPanel));
            }

            if (noButton != null)
            {
                noButton.onClick.AddListener(() => DeletePanel(newPanel));
            }

            newPanel.name = "GeneratedPanel";
            Debug.Log("Panel created!");
        }
        else
        {
            Debug.LogError("Panel Prefab or Canvas Transform is not assigned!");
        }
    }

    private void DeletePanel(GameObject panel)
    {
        Destroy(panel);
        Debug.Log("Panel deleted!");
    }

    [System.Serializable]
    private class SaveData
    {
        public List<bool> states;
    }
}
