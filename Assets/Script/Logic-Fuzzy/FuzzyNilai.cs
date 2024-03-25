using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class FuzzyNilai : MonoBehaviour

{
   // mengambil game object canvas untuk digunakan memanggil child untuk textNilai
   public GameObject txtNilai;

   //mengambil nilai inputan jawaban benar dari quiz level1 dan level2
   

    // variabel input fuzzy (hasil poin jawaban pada quiz 1 dan jawaban pada quiz 2)
    public static float point;
    public static float point2;

    // nilai kondisi fuzzyfikasi
    public float berhasil1,gagal1;
    public float berhasil2,gagal2;

    //array untuk menampung aturanfuzzy (peluang pada tiap stage)
    public float[]  aturanFuzzy = new float [4];

    // nilai output kondisi deffuzyfikasi
    public float rsltMin;
    public float rsltMinOtpt;
    public static float deffuzyfikasi;
   //  public float rsltOtpt;

    

   void inputFuzzy(){
      point = QuestSoal.resultJawabanBenarlvl1;
      // point = 6;
      Debug.Log("hasil pertama : "+point);
      point2 = QuestSoalDua.resultJawabanBenarlvl2;
      // point2 = 7;
      Debug.Log("hasil kedua : "+point2);
   }

    //pembuatan fungsi keanggotaan linear, menggunakan kurva linear naik dan kurva linear turun pada Level1 untuk hasil dengan jawaban bagus
    void JawabanNilaiBagusLevel1(){
        
         if(point < 6){
            berhasil1 = 0f;
         }else if(point >= 6 && point <= 9){
            berhasil1 = (point-6) / (9-6);
         }else if(point > 9){
            berhasil1 = 1f;
         }
         Debug.Log("jawaban nilai bagus 1: "+berhasil1);
        
    }

    //pembuatan fungsi keanggotaan linear, menggunakan kurva linear naik dan kurva linear turun pada Level1 untuk hasil jawaban dengan hasil jelek
    void JawabanNilaiJelekLevel1(){
        
         if(point > 8){
            gagal1 = 0f;
         }else if(point >= 5 && point <= 8){
            gagal1 = (8-point) / (8-5);
         }else if(point < 5){
            gagal1 = 1f;
         }
         Debug.Log("jawaban nilai jelek 1: "+gagal1);
         
    }
    
   //pembuatan fungsi keanggotaan linear, menggunakan kurva linear naik dan kurva linear turun pada Level2 untuk hasil dengan jawaban bagus
    void JawabanNilaiBagusLevel2(){
         
         if(point2 < 4){
            berhasil2 = 0f;
         }else if(point2 >= 4 && point2 <= 7){
            berhasil2 = (point2-4) / (7-4);
         }else if(point2 > 7){
            berhasil2 = 1f;
         }
         Debug.Log("jawaban nilai bagus 2: "+berhasil2);
         
    }

   //pembuatan fungsi keanggotaan linear, menggunakan kurva linear naik dan kurva linear turun pada Level2 untuk hasil dengan jawaban jelek
    void JawabanNilaiJelekLevel2(){
         
         if(point2 > 6){
            gagal2 = 0f;
         }else if(point2 >= 3 && point2 <= 6){
            gagal2 = (6-point2) / (6-3);
         }else if(point2 < 3){
            gagal2 = 1f;
         }
         Debug.Log("jawaban nilai jelek 2: "+gagal2);
    }

    void nilaiTerkecil(){
      aturanFuzzy[0] = Mathf.Min(berhasil1,berhasil2);
      aturanFuzzy[1] = Mathf.Min(berhasil1,gagal2);
      aturanFuzzy[2] = Mathf.Min(gagal1,berhasil2);
      aturanFuzzy[3] = Mathf.Min(gagal1,gagal2); 
    }

    void totalNilaiTerkecil(){
      rsltMin = aturanFuzzy[0] + aturanFuzzy[1] + aturanFuzzy[2] + aturanFuzzy[3];
      Debug.Log("total nilai terkecil : "+rsltMin);
    }

    void NilaiTerkecilOutput(){
      rsltMinOtpt = (aturanFuzzy[0]*3) + (aturanFuzzy[1]*1) + (aturanFuzzy[2]*2) + (aturanFuzzy[3]*1);
      Debug.Log("nilai x bobot : "+rsltMinOtpt);
    }

    void HasilOutput(){
      deffuzyfikasi = rsltMinOtpt/rsltMin;
      Debug.Log("hasil defuzzy : " + deffuzyfikasi);
      // rsltOtpt = ;

      if(deffuzyfikasi  > 0 && deffuzyfikasi  <2){
        SceneManager.LoadScene("cutsceneNilaiC", LoadSceneMode.Single);
      }else if(deffuzyfikasi >= 2 && deffuzyfikasi < 3 ){
         SceneManager.LoadScene("cutsceneNilaiB", LoadSceneMode.Single);
      }else if(deffuzyfikasi >= 3){
         txtNilai.transform.GetComponent<TextMeshProUGUI>().text = "A";
      }
    }

   //  void Start()
   //  {
       
   //  }

   
    void Update()
    {
      inputFuzzy();

      // if(point < 4){
      //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      // }
      // else{
      //    if(point >4 && point2 >2){
      //    JawabanNilaiBagusLevel1();
      //    JawabanNilaiJelekLevel1();
      //    JawabanNilaiBagusLevel2();
      //    JawabanNilaiJelekLevel2();
      //    nilaiTerkecil();
      //    totalNilaiTerkecil();
      //    NilaiTerkecilOutput();
      //    HasilOutput(); 
      // }

      //pengondisian result 
      if(point >4 && point2 >2){
         JawabanNilaiBagusLevel1();
         JawabanNilaiJelekLevel1();
         JawabanNilaiBagusLevel2();
         JawabanNilaiJelekLevel2();
         nilaiTerkecil();
         totalNilaiTerkecil();
         NilaiTerkecilOutput();
         HasilOutput(); 
      }else

      {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         // txtNilai.transform.GetComponent<TextMeshProUGUI>().text = "Remedial"

      }
    }
}
