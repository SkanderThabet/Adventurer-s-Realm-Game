using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace FantasyRPG
{

    public class PanelLogin : MonoBehaviour
    {
        public Transform[] buttons;

        public CtrTitle ctrTitle;
        public GameObject settingsPrefab; 

        public void Show(CtrTitle ctr)
        {
            ctrTitle = ctr;

            this.gameObject.SetActive(true);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].DOKill();
                buttons[i].DOScale(1f, 0.2f).SetEase(Ease.OutBack).SetDelay(0.2f * i);
            }

          
        }

        public void Hide()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].DOKill();
                buttons[i].DOScale(0f, 0f);
            }

     

            this.gameObject.SetActive(false);
        }

        public void Click_Login()
        {
            Hide();
            ctrTitle.Login();
        }

        public void Click_SignUp()
        {
            Application.OpenURL("http://localhost:9090/user");
            Debug.Log("is this working?");
            
        }

        public void openSettings()
        {

            Instantiate(settingsPrefab, this.transform);
        }
        

      

        
    }
}
