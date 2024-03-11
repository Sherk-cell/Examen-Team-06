using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarUpgradeManager : MonoBehaviour
{
    [SerializeField] private MockUpPlayer player;
    [SerializeField] private StoreManager storeManager;
    private int maxSpeed;
    private int maxSpeedCount;

    private int gripHandle;
    private int gripHandleCount;

    private int acceleration;
    private int accelerationCount;
    private int upgradeCost = 3;

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
    
    [SerializeField] private TextMeshProUGUI maxSpeedTextCost;
    [SerializeField] private TextMeshProUGUI gripHandleTextCost;
    [SerializeField] private TextMeshProUGUI accelerationTextCost;
    
    public GameObject selectedCar;
    


    private void Awake()
    {
        InitializeUpgrades();
       
    }

    private void Update()
    {
        if (selectedCar!= storeManager.currentlySelectedCar)
        {
            LoadCarStats();
        }
    }

    public void UpgrageMaxSpeed()
    {
        var cost = upgradeCost * (MaxSpeedCount + 2);
        if(maxSpeedCount < maxUpgradeCount && player.coins >= cost)
        {
            player.coins -= cost;
            maxSpeed += 10;
            maxSpeedCount++;
            maxSpeedTextCost.text = cost.ToString();
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
        var cost = upgradeCost * (gripHandleCount + 2);
        if (gripHandleCount < maxUpgradeCount)
        {
            player.coins -= cost;
            gripHandleTextCost.text = cost.ToString();
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
        var cost = upgradeCost * (accelerationCount + 2);
        if (accelerationCount < maxUpgradeCount)
        {
            acceleration += 10;
            accelerationCount++;
            player.coins -= cost;
            accelerationTextCost.text = cost.ToString();
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
        selectedCar = storeManager.currentlySelectedCar;
        DataLoader.LoadCarUpgrades(selectedCar, this);
        var costMaxSpeed = upgradeCost * (MaxSpeedCount + 1);
        var costAcceleration = upgradeCost * (accelerationCount + 1);
        var costGripHandle = upgradeCost * (gripHandleCount + 1);

        maxSpeedTextCost.text = costMaxSpeed.ToString();
        accelerationTextCost.text = costAcceleration.ToString();
        gripHandleTextCost.text = costGripHandle.ToString();
        
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
        var costMaxSpeed = upgradeCost * (MaxSpeedCount + 1);
        var costAcceleration = upgradeCost * (accelerationCount + 1);
        var costGripHandle = upgradeCost * (gripHandleCount + 1);

        maxSpeedTextCost.text = costMaxSpeed.ToString();
        accelerationTextCost.text = costAcceleration.ToString();
        gripHandleTextCost.text = costGripHandle.ToString();


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
