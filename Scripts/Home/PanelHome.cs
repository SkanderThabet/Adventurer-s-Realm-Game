using System;
using System.Collections;
using System.Collections.Generic;
using MoralisWeb3ApiSdk;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MoralisWeb3ApiSdk;
using Moralis.Platform.Objects;
using Moralis.Platform.Operations;
using UnityEngine.Events;

//WalletConnect
using WalletConnectSharp.Core.Models;
using WalletConnectSharp.Unity;


public class PanelHome : PanelBase
{
     public TextMeshProUGUI UserAddress;

     private void Start()
     {
       
               var user = MoralisInterface.GetClient().GetCurrentUser();
               

               if (user != null)
               {
                   string addr = user.authData["moralisEth"]["id"].ToString();
                  /* UserAddress.text = "Formatted Wallet Address:\n" + string.Format("{0}...{1}", addr.Substring(0, 6),
                       addr.Substring(addr.Length - 3, 3));*/
                   UserAddress.text = user.ethAddress.ToString();
               }
               else UserAddress.text = "no user auth";

     }
}
