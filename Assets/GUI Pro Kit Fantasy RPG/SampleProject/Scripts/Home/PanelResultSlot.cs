using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelResultSlot : PanelBase
{
    public Navicontrol navicontrol;

    public void Click_Prev()
    {
        navicontrol.Prev();
    }

    public void Click_Next()
    { 
        navicontrol.Next();
    }
}