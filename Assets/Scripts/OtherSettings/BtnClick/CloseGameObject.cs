using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameObject : MonoBehaviour
{
    public GameObject newgameObject;

    public void closeGameObject()
    {
        newgameObject.SetActive(false);//關閉物件
    }
}
