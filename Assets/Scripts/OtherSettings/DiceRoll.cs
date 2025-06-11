using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class DiceRoll : MonoBehaviour
{
    public Rigidbody rb;
    public Image fadeImage;
    public GameObject fadeImageGo;
    public GameObject MainCamera;
   // public TextMeshProUGUI Result;
    public GameObject[] faceDetectons;
   // public AudioSource audioSource;
    private void Start()
    {
        SetInitialState();
    }

    private void Update() 
    {
        if(CheckObjectHasStopped() == true)
        {
            //int indexResult =FindFaceResult();
            StartCoroutine(BackToGameScene());
        }
    }
    public int FindFaceResult()
    {
        int maxIndex = 0;
        for(int i=1;i<faceDetectons.Length;i++)
        {
            if(faceDetectons[maxIndex].transform.position.y < faceDetectons[i].transform.position.y)
            {
                maxIndex = i;
                int num =maxIndex+1;
              //  Result.text =num.ToString();
            }
        }
      
        return maxIndex;
    }

    private IEnumerator BackToGameScene()
    {
        yield return new WaitForSeconds(2);
        MainCamera.GetComponent<SceneTransition>().FadeToBlack(0);
    }

     public void FadeToBlack()
    {
        fadeImageGo.SetActive(true); 
       // fadeImage.DOFade(1f, 0.5f) // 透明度變為 1，持續 0.5 秒    // .OnComplete(() => unloadDiceScene()); 
    }

    public bool CheckObjectHasStopped()
    {
        if(rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero)
        {
            return true;
        }
        else
        {
             return false;
        }
    }
    private void SetInitialState()
    {
        int x = Random.Range(0, 360);
        int y = Random.Range(0,360);
        int z = Random.Range(0,360);
        Quaternion rotation = Quaternion.Euler( x , y , z );

        x = Random.Range(0, 25);
        y = Random.Range(0, 25);
        z = Random.Range(0, 25);
        Vector3 force = new Vector3( x , -y , z );

        x = Random.Range(0, 50);
        y = Random.Range(0, 50);
        z = Random.Range(0, 50);
        Vector3 torque = new Vector3( x , y , z );

        transform.rotation = rotation;
        rb.velocity = force;

        //By Default Max Angular Velocity is capped at 7
        this.rb.maxAngularVelocity = 1000;
        rb.AddTorque(torque , ForceMode.VelocityChange);
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Dice"))   
        {
            PlaySoundCollideDice();
        } 
        if(other.transform.CompareTag("Floor"))
        {
            PlaySoundCollideFloor();
        }
    }

    private void PlaySoundCollideDice()
    {
        /*if(soundCollideFloor.isPlaying)
        {

        }*/
    }

    private void PlaySoundCollideFloor()
    {

    }
}
