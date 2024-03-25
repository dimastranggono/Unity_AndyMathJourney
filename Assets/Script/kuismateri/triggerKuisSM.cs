using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerKuisSM : MonoBehaviour
{
    public GameObject Message;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Message.SetActive(true);
        }
    }
}
