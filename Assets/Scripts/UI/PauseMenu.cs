//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject PauseMenuUI;
   public GameObject PauseBtn;
   public GameObject MainCamera;
   public void Onclick_Pause() 
   {
        PauseBtn.SetActive(false);
        if(GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    
   }

   private void Pause()
   {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
   }

   public void Resume()
   {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PauseBtn.SetActive(true);
   }

   public void Home(int index)
   {
     Time.timeScale = 1f;
     GameIsPaused = false;
     MainCamera.GetComponent<SceneTransition>().FadeToBlack(index);
   }

   public void MainMenu()
   {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
   }

   public void Settings()
   {
        Debug.Log("Settings...");
   }

   

}
