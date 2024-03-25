using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel2 : MonoBehaviour
{
    public void GoLevel2(){
        SceneManager.LoadScene("leveldua");
    }

    public void GoResultScene(){
        SceneManager.LoadScene("cutsceneending");
    }
}
