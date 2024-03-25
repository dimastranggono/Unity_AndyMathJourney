using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherYates : MonoBehaviour
{

    public int[] ValueArray;

    public List<string> StringSoalJawaban;
    // Start is called before the first frame update
    void Start()
    {
        // Shuffle(ValueArray);
        ShuffleStringList(StringSoalJawaban);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shuffle(int[] value){
        for (int i = value.Length - 1; i > 0 ; i--)
        {
            // Debug.Log(i); 

            // random 
            int random = Random.Range(0,i); // 1-i
            int temp = value[i];

            value[i] = value[random] =temp;
            // value[random] = temp;
        }
    }
    public void ShuffleStringList(List<string> kalimat){
        for (int i = kalimat.Count - 1; i > 0 ; i--)
        {
            // Debug.Log(i); 

            int random = Random.Range(0,i); // 1-i
            string temp = kalimat[i];

            kalimat[i] = kalimat[random];
             kalimat[random] = temp;
        }
    }
}
