using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToolScreen : SceneTransition
{
    public Button Game_1;
    public Button Game_2;
    public Button Game_3;
    public GameObject ToolsScreen;

    private void Start()
    {
        Game_1.onClick.AddListener(firstGame);
        Game_2.onClick.AddListener(secondGame);
        Game_3.onClick.AddListener(thirdGame);
    }


    private void firstGame()
    {
       SceneManager.LoadScene("Pakour_Normal");
    }

    private void secondGame()
    {
       SceneManager.LoadScene("Game_two");
    }

    private void thirdGame()
    {
      Debug.Log("Coming Soon...");
       //SceneManager.LoadScene("Game_three");
    }
}
