using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QontrolQuest : MonoBehaviour
{
    [System.Serializable]

    public class Soal{
        
        [System.Serializable]

        public class elementSoal {
            [TextArea]
            public string soal;
            public string[] jawaban; // 
            public int jawabanBenar; //angka array dari jawaban yang merupakan jawaban benar
        }

        public elementSoal soalElement;
    }

    public List<Soal> soals;

}
