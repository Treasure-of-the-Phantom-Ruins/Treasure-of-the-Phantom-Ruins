using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
       void Start()
    {
        Debug.Log($"Running on Mobile Platform: {Application.isMobilePlatform}");
        
        #if UNITY_IOS || UNITY_ANDROID
            Debug.Log("Platform is iOS or Android");
            gameObject.SetActive(true);
        #else
            Debug.Log("Platform is not iOS or Android");
            gameObject.SetActive(false);
        #endif
    }
    /*// Start is called before the first frame update
    void Start()
    {
        //check the gameobject is on mobile
        gameObject.SetActive (Application.isMobilePlatform);
    }*/
}
