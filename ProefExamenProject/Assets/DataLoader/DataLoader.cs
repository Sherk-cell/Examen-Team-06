using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public static DataLoader instance { get; private set;}
    private void Awake()
    {
        if (instance == null)
            instance = new DataLoader();
    }

    public static void SaveCarUpgrades(CarUpgrade car)
    {
        UpgradeData data = new UpgradeData();
        data.Acceleration = car.Acceleration;
        data.AccelerationCount = car.AccelerationCount;
        data.GripHandle = car.GripHandle;
        data.GripHandleCount = car.GripHandleCount;
        data.MaxSpeed = car.MaxSpeed;
        data.MaxSpeedCount = car.MaxSpeedCount;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + $"/DataLoader/Json/{car.gameObject.name}DataFile.json", json);
        Debug.Log("Saved");
        Debug.Log(Application.dataPath + $"/DataLoader/Json/{car.gameObject.name}DataFile.json");
    }

    public static void LoadCarUpgrades(CarUpgrade car)
    {
        string json = File.ReadAllText(Application.dataPath + $"/DataLoader/Json/{car.gameObject.name}DataFile.json");
        UpgradeData data = JsonUtility.FromJson<UpgradeData>(json);
        car.Acceleration = data.Acceleration;
        car.AccelerationCount = data.AccelerationCount;
        car.GripHandle = data.GripHandle;
        car.GripHandleCount = data.GripHandleCount;
        car.MaxSpeed = data.MaxSpeed;
        car.MaxSpeedCount = data.MaxSpeedCount;
        Debug.Log("Saved");
    }

}
