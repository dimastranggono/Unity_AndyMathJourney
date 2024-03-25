using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(){
        SceneManager.LoadScene("Soundsetting");
    }
    public void LoadMenu(){
        SceneManager.LoadScene("SampleScene");
    }
}