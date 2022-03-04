using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    public GameObject statusEnerge;
    public GameObject statusGem;
    public GameObject statusGold;
    public GameObject statusInfernumGem;

    public void SetEnerge(bool value)
    {
        statusEnerge.SetActive(value);
    }
   
    public void SetGem (bool value)
    {
        statusGem.SetActive(value);
    }
   
   
    public void SetGold(bool value)
    {
        statusGold.SetActive(value);
    }
    public void SetInfernumGem(bool value)
    {
        statusInfernumGem.SetActive(value);
    }
    
    
}
