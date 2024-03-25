using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;//untuk import text TMP


public class QuestSoal : MonoBehaviour
{
    public TextMeshProUGUI soalText;
    public TextMeshProUGUI[] jawabanText;
    public int[] randomJawaban;
    public int[] randomSoal;
    public QontrolQuest qontrolQuest;
    private int noSoal;
    public int gameRound;
    public GameObject panelHasil;
    public static float resultJawabanBenarlvl1; 

    // Start is called before the first frame update
    void Start()
    {
        RandomIndexSoal();
        GenerateQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            //subtitusi nilais
            randomSoal[b] = a;
        }
    }

    void GenerateQuest(){
    
        RandomIndexJawaban();

        // soalText.text = qontrolQuest.soals[noSoal].soalElement.soal;
         soalText.text = qontrolQuest.soals[randomSoal[noSoal]].soalElement.soal;

        for (int i = 0; i < jawabanText.Length; i++)
            {
                // jawabanText[i].text = qontrolQuest.soals[noSoal].soalElement.jawaban[i];
                jawabanText[i].text = qontrolQuest.soals[randomSoal[noSoal]].soalElement.jawaban[randomJawaban[i]];
            }
        }
    
    
    public void jawabSoal(){
        TextMeshProUGUI currentJawaban = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if(currentJawaban.text == qontrolQuest.soals[randomSoal[noSoal]].soalElement.jawaban[qontrolQuest.soals[randomSoal[noSoal]].soalElement.jawabanBenar]){
            //point+=10;
             Debug.Log("benar"); 

            if(noSoal >= gameRound-1){
                 panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar, Semua Soal Terjawab, Lanjut Level 2";
                 panelHasil.transform.GetChild(1).gameObject.SetActive(false);
                 panelHasil.transform.GetChild(2).gameObject.SetActive(true);
                  
                  //coba skor
                //   hasilNilai1 = resultJawabanBenarlvl1;
                //     Debug.Log(hasilNilai1);
                //  panelHasil.transform.GetChild(1).gameObject.SetActive(true);

                
            }
            else{
                //coba tambah nilai
                panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar";
                resultJawabanBenarlvl1 += 1;
                Debug.Log(resultJawabanBenarlvl1);

            }
        }
        else
        {
            Debug.Log("Salah"); 
             panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Salah !, Jawab Soal Berikutnya";
            
            if(noSoal >= gameRound-1){
                panelHasil.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text="Jawaban Salah, Semua Soal Terjawab. Lanjut Level 2";
                panelHasil.transform.GetChild(1).gameObject.SetActive(false);
                panelHasil.transform.GetChild(2).gameObject.SetActive(true);
            }
            // panelHasil.transform.GetChild(1).gameObject.SetActive(false);
        }
         panelHasil.SetActive(true);
    }

    public void ButtonNextSoal(){
        panelHasil.SetActive(false);
        noSoal++;
        GenerateQuest();
    }
}
