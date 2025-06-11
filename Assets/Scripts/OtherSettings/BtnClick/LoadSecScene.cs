using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecScene : MonoBehaviour
{
    public GameObject canvas;
    public void loadDice()
    {
        StartCoroutine(CreateDiceScene());
    }
    public static IEnumerator CreateDiceScene() {
        // 使用正確的場景名稱
        Scene previousScene = SceneManager.GetSceneByName("DiceRoll");
        Debug.Log($"Previous Scene: {previousScene.name}, IsValid: {previousScene.IsValid()}");

        // 如果場景有效則卸載
        if (previousScene.IsValid() || previousScene.isLoaded) 
        {
            Debug.Log("Unloading previous scene...");
            yield return SceneManager.UnloadSceneAsync("DiceRoll");
        }

        // 加載新場景
        Debug.Log("Loading new scene...");
        SceneManager.LoadScene("DiceRoll", LoadSceneMode.Additive);

        // 確保場景加載完成
        Scene scene = SceneManager.GetSceneByName("DiceRoll");
        while (!scene.isLoaded) 
        {
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("New scene loaded successfully.");
    }
}
