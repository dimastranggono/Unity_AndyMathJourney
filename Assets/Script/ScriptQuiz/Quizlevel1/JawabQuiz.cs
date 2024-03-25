using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JawabQuiz : MonoBehaviour
{
    public GameObject feed_benar, feed_salah, benarComp, salahComp, panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void jawaban(bool jawab){
        if(jawab ){
            feed_benar.SetActive(false);
            feed_benar.SetActive(true);
            benarComp.SetActive(true);
        }else{
            feed_salah.SetActive(false);
            feed_salah.SetActive(true);
            salahComp.SetActive(true);
        }
        gameObject.SetActive (false);
        
        transform.parent.GetChild (gameObject.transform.GetSiblingIndex()+1).gameObject.SetActive (true);
    }

    public void ClosePanel(){
        Destroy(panel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
