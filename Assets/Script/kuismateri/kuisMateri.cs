using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuisMateri : MonoBehaviour
{
     [System.Serializable]

    public class SoalKuisMateri{
        
        [System.Serializable]

        public class elementSoal {
            [TextArea]
            public string materi;
            public string[] jawaban; // 
            public int jawabanBenar; //angka array dari jawaban yang merupakan jawaban benar
        }

        public elementSoal soalElement;
    }

    public List<SoalKuisMateri> materi;
}
