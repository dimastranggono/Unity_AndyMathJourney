using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;//untuk import text TMP


public class QuestSoalDua : MonoBehaviour
{
     public TextMeshProUGUI textSoal;
     public TextMeshProUGUI[] textJawaban;
     public int[] randomSoalLevel2;
     public int[] randomJawabanLevel2;
     public ControlsoalDua controlsoalDua;
     private int nomorSoal;
     public int gameRound;
     public GameObject panelHasillevel2;
     public static float resultJawabanBenarlvl2 ;

     void Start()
    {
        RandomIndexSoalLevelDua();
        GenerateQuest();
    }

    void Update()
    {

    }

    void RandomIndexJawabanLevelDua(){
        for (int i = 0; i < randomJawabanLevel2.Length; i++)
        {
            int a = randomJawabanLevel2[i];
            int b = Random.Range(0, randomJawabanLevel2.Length);
            randomJawabanLevel2[i] = randomJawabanLevel2[b];
            randomJawabanLevel2[b] = a;
        }
    }

    void RandomIndexSoalLevelDua(){
        for (int i = 0; i < randomSoalLevel2.Length; i++)
        {
            int a = randomSoalLevel2[i];
            int b = Random.Range(0, randomSoalLevel2.Length);
            randomSoalLevel2[i] = randomSoalLevel2[b];
            //subtitusi nilai
            randomSoalLevel2[b] = a;
        }
    }

    void GenerateQuest(){
        RandomIndexJawabanLevelDua();

        textSoal.text = controlsoalDua.soalsLeveldua[randomSoalLevel2[nomorSoal]].deskripsiSoal.soalLevelDua;

        for (int i = 0; i < textJawaban.Length; i++)
        {
           
            textJawaban[i].text = controlsoalDua.soalsLeveldua[randomSoalLevel2[nomorSoal]].deskripsiSoal.jawabanLevelDua[randomJawabanLevel2[i]];
        }
    }

    public void JawabSoalLevelDua(){
        TextMeshProUGUI currentJawabanLevelDua = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();


        if (currentJawabanLevelDua.text == controlsoalDua.soalsLeveldua[randomSoalLevel2[nomorSoal]].deskripsiSoal.jawabanLevelDua[controlsoalDua.soalsLeveldua[randomSoalLevel2[nomorSoal]].deskripsiSoal.jawabanBenar])
        {
             Debug.Log("benar"); 
           
            

            if(nomorSoal >= gameRound-1){
                 panelHasillevel2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar, Semua Soal Terjawab, Lanjut kan Cerita";
                 panelHasillevel2.transform.GetChild(1).gameObject.SetActive(false);
                 panelHasillevel2.transform.GetChild(2).gameObject.SetActive(true);
                //  panelHasil.transform.GetChild(1).gameObject.SetActive(true);

                // hasilNilai2 = resultJawabanBenarlvl2;
                // Debug.Log(hasilNilai2);

                
            }
            else{
                panelHasillevel2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Benar";
                 resultJawabanBenarlvl2 += 1;
                 Debug.Log(resultJawabanBenarlvl2);
            }

        }else{
             Debug.Log("Salah"); 
             panelHasillevel2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Jawaban Salah !, Jawab Soal Berikutnya";
            
            if(nomorSoal >= gameRound-1){
                panelHasillevel2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text="Jawaban Salah, Semua Soal Terjawab. Lanjut Level 2";
                panelHasillevel2.transform.GetChild(1).gameObject.SetActive(false);
                panelHasillevel2.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        panelHasillevel2.SetActive(true);
    }

    public void ButtonNextSoalLevel2(){
        panelHasillevel2.SetActive(false);
        nomorSoal++;
        GenerateQuest();
    }
}
