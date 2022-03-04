using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FantasyRPG
{
   public class CtrHome : CtrBase
   {
      public Transform backGround;
      public StatusBar statusBar;
      public PanelBase[] panelBase;
      private int panelNum = 0;


    
      
      void Start()
      {
         backGround.DOKill();
         backGround.DOScale(1.05f, 0f);
         backGround.transform.DOScale(1f, 1.5f).SetEase(Ease.Linear);

         Click_Panel(0);
      }


      public void Click_Panel(int num)
      {
         if (panelNum == num) return;
         
         panelBase[panelNum].Close();
         panelNum = num;
         
         switch (panelNum)
         {
            case 0:
               //Home
               SetStatus(true, true, true , true);
               break;
            
            case 1:
               //Shop
               SetStatus(false, true, true , true);
               break;
            
            case 2:
               //Heroes
               SetStatus(false, false, true , true);
               break;
            
            case 3:
               //Inventory
               SetStatus(true, true, true , true);
               break;
            
            case 4:
               //Battlepass
               SetStatus(false, true, true , false);
               break;
            
            case 5:
               //Settings
               SetStatus(false, false, false , false);
               break;
            
            case 6:
               //Ranking
               SetStatus(false, false, false , false);
               break;
            
            case 7:
               //Mission
               SetStatus(false, true, true , false);
               break;
            
            case 8:
               //RewardWeek
               SetStatus(false, false, false, false);
               break;
            
            case 9:
               //RewardDay
               SetStatus(false, false, false, false);
               break;
            case 11:
               //Auction house
               SetStatus(false, true, false, true);
               break;
         }

         panelBase[panelNum].Open();
      }


      public void SetHome()
      {
         panelNum = 0;
         panelBase[panelNum].Open();
         
         SetStatus(true, true, true, true);
      }
      
      public void SetStatus(bool isEnerge, bool isGem, bool isGold, bool isInfGem)
      {
         statusBar.SetEnerge(isEnerge);
         statusBar.SetGem(isGem);
         statusBar.SetGold(isGold);
         statusBar.SetInfernumGem(isInfGem);
      }
   }
}
