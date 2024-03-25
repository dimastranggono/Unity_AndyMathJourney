using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsoalDua : MonoBehaviour
{
    [System.Serializable]

    public class SoalLevelDua{
        
        [System.Serializable]

        public class DeskripsiSoal {
            [TextArea]
            public string soalLevelDua;
            public string[] jawabanLevelDua; // 
            public int jawabanBenar; //angka array dari jawaban yang merupakan jawaban benar
        }

        public DeskripsiSoal deskripsiSoal;
    }

    public List<SoalLevelDua> soalsLeveldua;
}
