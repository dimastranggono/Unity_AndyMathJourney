using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class QuizRetryController : MonoBehaviour
{

    public TextMeshProUGUI soalText;
    public TextMeshProUGUI[] jawabanText;
    public int[] randomJawaban;
    public int[] randomSoal;
    // public QontrolQuest qontrolQuest;
    private int noSoal;
    public int gameRound;
    public GameObject panelHasil;

    [System.Serializable]

    public class SoalQuizRetry{
        
         [System.Serializable]
         
         public class KomponenSoal{
            [TextArea]
            public string soalQuizRetry;
            public string[] jawabanQuizRetry;  
            public int jawabanBenar;
         }
         public KomponenSoal kompSoal;
    }

    public List<SoalQuizRetry> soalsQuizRetry;

    void Start(){
        RandomIndexSoal();
        GenerateQuest();
    }
    void Update(){

    }
    
    void RandomIndexJawaban(){
        for (int i = 0; i < randomJawaban.Length; i++)
        {
            int a = randomJawaban[i];
            int b = Random.Range(0, randomJawaban.Length);
            randomJawaban[i] = randomJawaban[b];
            randomJawaban[b] = a;
        }
    }


    void RandomIndexSoal(){
        for (int i = 0; i < randomSoal.Length; i++)
        {
            int a = randomSoal[i];
            int b = Random.Range(0, randomSoal.Length);
            randomSoal[i] = randomSoal[b];
            //subtitusi nilai
            randomSoal[b] = a;
        }
    }

    void GenerateQuest(){
    
        RandomIndexJawaban();

         soalText.text = soalsQuizRetry[randomSoal[noSoal]].kompSoal.soalQuizRetry;

        for (int i = 0; i < jawabanText.Length; i++)
            {
                jawabanText[i].text =soalsQuizRetry[randomSoal[noSoal]].kompSoal.jawabanQuizRetry[randomJawaban[i]];
            }
    }

    public void jawabSoal(){
        TextMeshProUGUI currentJawaban = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if(currentJawaban.text == soalsQuizRetry[randomSoal[noSoal]].kompSoal.jawabanQuizRetry[soalsQuizRetry[randomSoal[noSoal]].kompSoal.jawabanBenar]){
            //point+=10;
             Debug.Log("benar"); 

             panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar, Lanjutkan Kembali bermain";
              panelHasil.transform.GetChild(1).gameObject.SetActive(true);
              panelHasil.transform.GetChild(2).gameObject.SetActive(false);

              

            // if(noSoal >= gameRound){
            //      panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar, Lanjutkan Kembali bermain";
            //      panelHasil.transform.GetChild(1).gameObject.SetActive(false);
            //      panelHasil.transform.GetChild(2).gameObject.SetActive(true);
            //     //  panelHasil.transform.GetChild(1).gameObject.SetActive(true);
            // }
            // else{
            //     panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar";
            // }
        }
        else
        {
            Debug.Log("Salah"); 
             panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Salah !, Anda tidak bisa melanjutkan ke level berikutnya";
                panelHasil.transform.GetChild(1).gameObject.SetActive(false);
              panelHasil.transform.GetChild(2).gameObject.SetActive(true);
            // ju        
            // panelHasil.transform.GetChild(1).gameObject.SetActive(false);
        }
         panelHasil.SetActive(true);
    }

        
}
