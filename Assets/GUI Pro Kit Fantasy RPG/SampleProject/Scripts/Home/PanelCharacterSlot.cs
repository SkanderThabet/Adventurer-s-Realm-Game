using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCharacterSlot : PanelBase
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
