using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    [SerializeField]private Transform[] roomAchive;


    private void Start() {
       for (int i = 0; i < roomAchive.Length; i++)
       {   
            roomAchive[i].GetComponent<Room>().ActivateRoom(false);
       }
    }
}
