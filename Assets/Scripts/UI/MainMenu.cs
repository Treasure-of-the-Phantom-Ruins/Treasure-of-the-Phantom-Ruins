using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   [SerializeField]private Button startgameBtn;
   [SerializeField]private Button quitgameBtn;
   [SerializeField]private Button moreifnBtn;

   private void Start()
   {
        startgameBtn.onClick.AddListener(()=>startgame());
        quitgameBtn.onClick.AddListener(()=>quitgame());
        moreifnBtn.onClick.AddListener(()=>moreifn());
   }
   public void startgame()
   {
        SceneManager.LoadScene("Mario2DGame");
   }

   public void quitgame()
   {
       Application.Quit();
   }

   public void moreifn()
   {
        Debug.Log("More information...");
   }
   
}
