using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuisInteraktifSM : MonoBehaviour
{
    public GameObject Message;
    public GameObject comp;
    public GameObject comp2;
    public GameObject comp3;
    public GameObject compLat;

    // public void OnTriggerEnter2D(Collider2D other){
    //     if(other.gameObject.tag == "Player"){
    //         Message.SetActive(true);
    //     }
    // }

    //  public void OnTriggerExit2D(Collider2D other){
    //     if(other.gameObject.tag == "Player"){
    //         Message.SetActive(false);
    //     }
    // }

    public void NextMateriSoal(){
        Message.SetActive(false);
        comp.SetActive(true);
        //  Message.transform.GetChild(0).gameObject.SetActive(false);
        // Message.transform.GetChild(1).gameObject.SetActive(true);
        //  Message.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void NextMateriDua(){
        Message.SetActive(false);
        comp.SetActive(false);
        comp2.SetActive(true);
    }

    public void NextSoalLatihan(){
        Message.SetActive(true);
        comp.SetActive(false);
        comp2.SetActive(false);
        comp3.SetActive(false);
        compLat.SetActive(true);
    }

    public void ClosePanel(){
         Message.transform.gameObject.SetActive(false);
       
    }
}
