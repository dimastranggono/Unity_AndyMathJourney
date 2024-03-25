using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOfIcon;
    private bool muted =false;


    void Start()
    {
        if(PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else{
           Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted==false){
            muted = true;
            AudioListener.pause = true;
        }
        else{
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon(){
        if (muted == false){
            soundOnIcon.enabled = true;
            soundOfIcon.enabled = false;
        }
        else{
            soundOnIcon.enabled = false;
            soundOfIcon.enabled = true;
        }
    }

    private void Load(){
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save(){
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
