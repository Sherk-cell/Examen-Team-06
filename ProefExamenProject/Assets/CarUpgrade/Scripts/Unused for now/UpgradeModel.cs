using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpgradeModel
{
    
    [SerializeField] private string Name;
    [SerializeField] private int upgradeCount;
    [SerializeField] private int upgradeLimit;
    [SerializeField] private float increment;
   



    public void SetModel(string MyName, int UC, int UL, int inc)
    {
        Name = MyName;
        upgradeCount = UC;
        upgradeLimit = UL;
        increment = inc;

    }

}
