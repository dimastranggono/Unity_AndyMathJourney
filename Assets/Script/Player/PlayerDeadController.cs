using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadController : MonoBehaviour
{
    

    public void GoToRetryScene(){
        SceneManager.LoadScene("quizretry");
    }

    public void GoToRetrySceneLevel2(){
        SceneManager.LoadScene("quizretrylevel2");  
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("SampleScene");
    }
}
