using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace FantasyRPG
{
    public class PanelSettings : PanelBase
    {
        public Slider sliderBarMusic;
        public TextMeshProUGUI VolumeIcon; 
        public GameObject[] imageVolumeMusic;
        public Button goBack; 

        void Start()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(0.8f, 0.2f).SetEase(Ease.OutBack);
        }
        
        void Update()
        { 
            
            if (sliderBarMusic.value <= 0)
            {
                imageVolumeMusic[1].SetActive(true);
                imageVolumeMusic[0].SetActive(false);
                VolumeIcon.text = "0";
                //imageVolumeIcon[0]. == "0";
                //VolumeIcon.GetComponent<Text>().text == "0";


            }
            else
            {
                imageVolumeMusic[1].SetActive(false);
                imageVolumeMusic[0].SetActive(true);
                VolumeIcon.text = (Math.Round(sliderBarMusic.value)).ToString();;
                
            }
            
        }

        public void CloseWindow()
        {
            GameObject self = this.gameObject;
            transform.DOScale(Vector3.zero, 0.2f).onComplete = delegate { Destroy(self); };
        }

  
        
        
    }
}
