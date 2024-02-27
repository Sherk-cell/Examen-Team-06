using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarUpgrade : MonoBehaviour
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

    public List<GameObject> MaxSpeedTick = new List<GameObject>();
    public List<GameObject> GripHandleTick = new List<GameObject>();
    public List<GameObject> AccelerationTick = new List<GameObject>();


    public int MaxUpgradeCount;
    [SerializeField] private GameObject upgradeTick;
    [SerializeField] private RectTransform BackGround;

    [SerializeField] private TextMeshProUGUI maxSpeedText;
    [SerializeField] private TextMeshProUGUI gripHandleText;
    [SerializeField] private TextMeshProUGUI accelerationText;


    private void Awake()
    {
        InitializeUpgrades();
    }
    public void UpgrageMaxSpeed()
    {
        
        if(maxSpeedCount < 10)
        {            
            maxSpeed += 10;
            maxSpeedCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < maxSpeedCount; i++)
            {
                var tick = MaxSpeedTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }
        }

    }
    public void UpgradeGripHandle()
    {
       
        if (gripHandleCount < 10)
        {
            gripHandle += 10;
            gripHandleCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < gripHandleCount; i++)
            {
                var tick = GripHandleTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }

        }
    }
    public void UpgradeAcceleration()
    {
       
        if (accelerationCount < 10)
        {
            acceleration += 10;
            accelerationCount++;
            DataLoader.SaveCarUpgrades(this);
            for (int i = 0; i < accelerationCount; i++)
            {
                var tick = AccelerationTick[i].GetComponent<Image>();
                tick.color = Color.green;
            }
        }
    }
    public void InitializeUpgrades()
    {
        var UpgradeCount = 3;
        DataLoader.LoadCarUpgrades(this);
        var TotalHeight = BackGround.rect.height / UpgradeCount;
        var MST = maxSpeedText.gameObject.GetComponent<RectTransform>();
        var GHT = gripHandleText.gameObject.GetComponent<RectTransform>();
        var AT = accelerationText.gameObject.GetComponent<RectTransform>();


        for (int i = 0; i < MaxUpgradeCount; i++)
        {

            var Step = MST.rect.width / 4;
            var TotalWidth = (BackGround.rect.width - MST.rect.width) / MaxUpgradeCount;
            var obj = Instantiate(upgradeTick, MST);
            MaxSpeedTick.Add(obj);
            var ObjTrans = obj.GetComponent<RectTransform>();
            ObjTrans.anchoredPosition = new Vector3(TotalWidth * i + MST.rect.width / 2, 0, 0);
            ObjTrans.sizeDelta = new Vector2(TotalWidth, TotalHeight);
            ObjTrans.SetParent(MST);
        }
        for (int i = 0; i < MaxUpgradeCount; i++)
        {

            var Step = GHT.rect.width / 4;
            var TotalWidth = (BackGround.rect.width - GHT.rect.width) / MaxUpgradeCount;
            var obj = Instantiate(upgradeTick, GHT);
            GripHandleTick.Add(obj);
            var ObjTrans = obj.GetComponent<RectTransform>();
            ObjTrans.anchoredPosition = new Vector3(TotalWidth * i + GHT.rect.width / 2, 0, 0);
            ObjTrans.sizeDelta = new Vector2(TotalWidth, TotalHeight);
            ObjTrans.SetParent(GHT);
        }
        for (int i = 0; i < MaxUpgradeCount; i++)
        {

            var Step = AT.rect.width / 4;
            var TotalWidth = (BackGround.rect.width - AT.rect.width) / MaxUpgradeCount;
            var obj = Instantiate(upgradeTick, AT);
            AccelerationTick.Add(obj);
            var ObjTrans = obj.GetComponent<RectTransform>();
            ObjTrans.anchoredPosition = new Vector3(TotalWidth * i + AT.rect.width / 2, 0, 0);
            ObjTrans.sizeDelta = new Vector2(TotalWidth, TotalHeight);
            ObjTrans.SetParent(AT);
        }
        for (int i = 0; i < accelerationCount; i++)
        {
            var tick = AccelerationTick[i].GetComponent<Image>();
            tick.color = Color.green;
        }
        for (int i = 0; i < gripHandleCount; i++)
        {
            var tick = GripHandleTick[i].GetComponent<Image>();
            tick.color = Color.green;
        }
        for (int i = 0; i < maxSpeedCount; i++)
        {
            var tick = MaxSpeedTick[i].GetComponent<Image>();
            tick.color = Color.green;
        }

    }

}
