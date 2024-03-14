using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int coinCount;
    public List<int> highScore = new List<int>();
    public List<String> unlockedCars = new List<string>();

}