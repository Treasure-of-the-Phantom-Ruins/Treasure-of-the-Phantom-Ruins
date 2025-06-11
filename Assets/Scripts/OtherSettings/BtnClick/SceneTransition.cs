using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using Unity.VisualScripting;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeImageGo;
    private string SceneName="";
    private void Start()
    {
        // 初始化全黑畫面為透明
        fadeImage.color = new Color(0, 0, 0, 1);
        fadeImageGo.SetActive(true);
        FadeFromBlack();   
    }
    // 淡入效果（畫面變黑）
    public void FadeToBlack(int index)
    {   
        Debug.Log("fade active");
        fadeImageGo.SetActive(true);
        //fadeImage.DOKill(); // 停止任何其他動畫
        fadeImage.DOFade(1f, 0.5f) // 透明度變為 1，持續 0.5 秒
         .OnComplete(() => SceneNum(index)); 
    }
    // 淡出效果（畫面顯現）
    public void FadeFromBlack() 
    {
        fadeImage.DOFade(0f, 0.5f) // 透明度變為 0，持續 0.5 秒
            .OnComplete(() => fadeImageGo.SetActive(false)); // 動畫完成後禁用黑屏
    }

    private void SceneNum(int index)
    {
        Debug.Log(index);
        switch(index)//When index is 0, go to GameScene
        {
            case 0:
            SceneName= "GameScene";
            GameScene();
            break;
            case 1:
            SceneName="DiceRoll";
            //當需要在原先場景加載新場景且保持原先場景不被關閉，加載新場景在原場景上
            //程式碼在LoadSecScene裡面
            StartCoroutine(CreateDiceScene());
            break;
            case 2:
            SceneName="StartUI";
            StartUI();
            break;
            case -1:
            SceneName="Pakour_Normal";
            SceneManager.LoadScene("Pakour_Normal");
            break;
            case -2:
            SceneName="Pakour_Hard";
            SceneManager.LoadScene("Pakour_Hard");
            break;
        }
    }
    private void StartUI()
    {
        StoneSelect.ClearJsonData();//Clear SaveData
        SceneManager.LoadScene("StartUI", LoadSceneMode.Single);//load StartUI
        
    }
    private void GameScene()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);//load GameScene
    }

    public static IEnumerator CreateDiceScene() {
        var previousScene = SceneManager.GetSceneByName("DiceRoll");//load DiceRoll
        Debug.Log(previousScene);

        //If Scene is valid,then unload this scene
        if (previousScene.IsValid()) {
            Debug.Log("unloading...");
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        //If Scene is not valid,then report error
        else if (!previousScene.IsValid())
        Debug.LogWarning("Unloading Failed");

        //Use path :Scene/DiceRoll  Because When you use LoadScene,to make sure the scene load successfully
        SceneManager.LoadScene("Scenes/DiceRoll", LoadSceneMode.Single);
        var scene = SceneManager.GetSceneByName("DiceRoll");
        while (!scene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
    }
}