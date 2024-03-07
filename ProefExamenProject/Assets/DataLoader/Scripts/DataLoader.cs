using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public static DataLoader instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
            instance = new DataLoader();
    }

    public static void SaveCoins(int addCoins)
    {
        PlayerData data = new PlayerData();
        data.coinCount += addCoins;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + $"/DataLoader/Json/Player.json", json);
        
    }

    public static void LoadCoins(int value)
    {
        if (!File.Exists(Application.dataPath + $"/DataLoader/Json/Player.json"))
        {
            UpgradeData data = new UpgradeData();
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Application.dataPath + $"/DataLoader/Json/Player.json", json);
        } 
        else
        {
            
            string json = File.ReadAllText(Application.dataPath + $"/DataLoader/Json/Player.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            value = data.coinCount;
        }
    }

    public static void SaveCarUpgrades(CarUpgradeManager car)
    {
        UpgradeData data = new UpgradeData();
        data.Acceleration = car.Acceleration;
        data.AccelerationCount = car.AccelerationCount;
        data.GripHandle = car.GripHandle;
        data.GripHandleCount = car.GripHandleCount;
        data.MaxSpeed = car.MaxSpeed;
        data.MaxSpeedCount = car.MaxSpeedCount;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + $"/DataLoader/Json/{car.selectedCar.name}DataFile.json", json);
    }

    public static void LoadCarUpgrades(GameObject carObj, CarUpgradeManager car)
    {
        if (!File.Exists(Application.dataPath + $"/DataLoader/Json/{carObj.name}DataFile.json"))
        {
            UpgradeData data = new UpgradeData();
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Application.dataPath + $"/DataLoader/Json/{car.selectedCar.name}DataFile.json", json);
        }       
        else
        {
            
            string json = File.ReadAllText(Application.dataPath + $"/DataLoader/Json/{carObj.name}DataFile.json");
            UpgradeData data = JsonUtility.FromJson<UpgradeData>(json);
            car.Acceleration = data.Acceleration;
            car.AccelerationCount = data.AccelerationCount;
            car.GripHandle = data.GripHandle;
            car.GripHandleCount = data.GripHandleCount;
            car.MaxSpeed = data.MaxSpeed;
            car.MaxSpeedCount = data.MaxSpeedCount;
        }


    }

}
