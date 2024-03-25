using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundmusic;
    // Start is called before the first frame update
    void Awake()
    {
        if(backgroundmusic == null){
            backgroundmusic = this;
            DontDestroyOnLoad(backgroundmusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
