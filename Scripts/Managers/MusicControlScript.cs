using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance;
    public  Slider volumeSlider; 
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume",1);
           // Load();
        }
      //  else Load();

    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; 
        Save();
    }
   /* void Load()
    {
        volumeSlider.value= PlayerPrefs.GetFloat("musicVolume");
    }*/

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
