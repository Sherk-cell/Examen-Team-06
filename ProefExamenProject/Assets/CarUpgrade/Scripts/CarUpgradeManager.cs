using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarUpgradeManager : MonoBehaviour
{
    private int maxSpeed;
    private int maxSpeedCount;

    private int gripHandle;
    private int gripHandleCount;

    private int acceleration;
    private int accelerationCount;

    public int MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public int MaxSpeedCount
    {
        get { return maxSpeedCount; }
        set { maxSpeedCount = value; }
    }

    public int GripHandle
    {
        get { return gripHandle; }
        set { gripHandle = value; }
    }

    public int GripHandleCount
    {
        get { return gripHandleCount; }
        set { gripHandleCount = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int AccelerationCount
    {
        get { return accelerationCount; }
        set { accelerationCount = value; }
    }
    
    
    
    public List<Image> maxSpeedTick = new List<Image>();
    public List<Image> gripHandleTick = new List<Image>();
    public List<Image> accelerationTick = new List<Image>();


    [SerializeField] private int maxUpgradeCount = 15;
    [SerializeField] private GameObject upgradeTick;
    [SerializeField] private RectTransform backGround;

    [SerializeField] private TextMeshProUGUI maxSpeedText;
    [SerializeField] private TextMeshProUGUI gripHandleText;
    [SerializeField] private TextMeshProUGUI accelerationText;
    public GameObject selectedCar;


    private void Awake()
    {
        InitializeUpgrades();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadCarStats();
        }
    }


    public void UpgrageMaxSpeed()
    {
        
        if(maxSpeedCount < maxUpgradeCount)
        {            
            maxSpeed += 10;
            maxSpeedCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < maxSpeedCount; i++)
            {
                var tick = maxSpeedTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }
        }

    }
    public void UpgradeGripHandle()
    {
       
        if (gripHandleCount < maxUpgradeCount)
        {
            gripHandle += 10;
            gripHandleCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < gripHandleCount; i++)
            {
                var tick = gripHandleTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }

        }
    }
    public void UpgradeAcceleration()
    {
       
        if (accelerationCount < maxUpgradeCount)
        {
            acceleration += 10;
            accelerationCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < accelerationCount; i++)
            {
                var tick = accelerationTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }
        }
    }

    public void LoadCarStats()
    {
        DataLoader.LoadCarUpgrades(selectedCar, this);
        for (int i = 0; i < maxUpgradeCount; i++)
        {
            var tickAcceleration = accelerationTick[i];
            var tickMaxSpeed = maxSpeedTick[i];
            var tickGripHandle = gripHandleTick[i];
            
            tickAcceleration.color = Color.white;
            tickMaxSpeed.color = Color.white;
            tickGripHandle.color = Color.white;
        }
        for (int i = 0; i < accelerationCount; i++)
        {
            var tick = accelerationTick[i];
            tick.color = Color.green;
        }
        
        for (int i = 0; i < gripHandleCount; i++)
        {
            var tick = gripHandleTick[i];
            tick.color = Color.green;
        }
        
        for (int i = 0; i < maxSpeedCount; i++)
        {
            var tick = maxSpeedTick[i];
            tick.color = Color.green;
        }
    }
    
    
    
    public void InitializeUpgrades()
    {
        var upgradeCount = 3;
        DataLoader.LoadCarUpgrades(selectedCar, this);
        var totalHeight = backGround.rect.height / upgradeCount;
        var maxSpeedTextComponent = maxSpeedText.gameObject.GetComponent<RectTransform>();
        var gripHandleTextComponent = gripHandleText.gameObject.GetComponent<RectTransform>();
        var accelerationTextComponent = accelerationText.gameObject.GetComponent<RectTransform>();


        for (int i = 0; i < maxUpgradeCount; i++)
        {
            var totalWidth = (backGround.rect.width - maxSpeedTextComponent.rect.width) / maxUpgradeCount;
            var obj = Instantiate(upgradeTick, maxSpeedTextComponent);
            maxSpeedTick.Add(obj.GetComponent<Image>());
            var objTrans = obj.GetComponent<RectTransform>();
            objTrans.anchoredPosition = new Vector3(totalWidth * i + maxSpeedTextComponent.rect.width / 2, 0, 0);
            objTrans.sizeDelta = new Vector2(totalWidth, totalHeight);
            objTrans.SetParent(maxSpeedTextComponent);
        }
        for (int i = 0; i < maxUpgradeCount; i++)
        {

            
            var totalWidth = (backGround.rect.width - gripHandleTextComponent.rect.width) / maxUpgradeCount;
            var obj = Instantiate(upgradeTick, gripHandleTextComponent);
            gripHandleTick.Add(obj.GetComponent<Image>());
            var objTrans = obj.GetComponent<RectTransform>();
            objTrans.anchoredPosition = new Vector3(totalWidth * i + gripHandleTextComponent.rect.width / 2, 0, 0);
            objTrans.sizeDelta = new Vector2(totalWidth, totalHeight);
            objTrans.SetParent(gripHandleTextComponent);
        }
        for (int i = 0; i < maxUpgradeCount; i++)
        {

          
            var totalWidth = (backGround.rect.width - accelerationTextComponent.rect.width) / maxUpgradeCount;
            var obj = Instantiate(upgradeTick, accelerationTextComponent);
            accelerationTick.Add(obj.GetComponent<Image>());
            var objTrans = obj.GetComponent<RectTransform>();
            objTrans.anchoredPosition = new Vector3(totalWidth * i + accelerationTextComponent.rect.width / 2, 0, 0);
            objTrans.sizeDelta = new Vector2(totalWidth, totalHeight);
            objTrans.SetParent(accelerationTextComponent);
        }
        for (int i = 0; i < accelerationCount; i++)
        {
            var tick = accelerationTick[i];
            tick.color = Color.green;
        }
        for (int i = 0; i < gripHandleCount; i++)
        {
            var tick = gripHandleTick[i];
            tick.color = Color.green;
        }
        for (int i = 0; i < maxSpeedCount; i++)
        {
            var tick = maxSpeedTick[i];
            tick.color = Color.green;
        }

    }

}
