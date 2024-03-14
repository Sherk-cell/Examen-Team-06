using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Input;




public class StoreManager : MonoBehaviour
{
    
    
    [SerializeField] private Transform carCatalog;
    [SerializeField] private List<GameObject> carModels = new List<GameObject>();
    [SerializeField] private float distanceBetweenCars;
    private List<Transform> carTransform = new List<Transform>();
    public GameObject currentlySelectedCar;
    private void Awake()
    {
        LoadCars();
        SpawnCars();
    }

    private void LoadCars()
    {
        var cars = Resources.LoadAll<GameObject>("CarModels");

        foreach (var car in cars)
        {
            carModels.Add(car);
        }
    }
    private void SpawnCars()
    {
        for (int i = 0; i < carModels.Count; i++)
        {
            var spawnOffset = (carModels.Count * distanceBetweenCars) * -1;
            var carXSpawn = spawnOffset + (distanceBetweenCars * (i + Mathf.FloorToInt(carModels.Count / 2)));
            var currentCar = Instantiate(carModels[i], new Vector3(carXSpawn, carModels[i].transform.position.y, carModels[i].transform.position.z), Quaternion.identity, carCatalog);
            carTransform.Add(currentCar.transform);
            if (currentCar.transform.position.x == 0)
                currentlySelectedCar = currentCar;
        }
    }

    public void GoRight()
    {
        CarPlaceHandler(2);
    }
    public void GoLeft()
    {
        CarPlaceHandler(0);
    }
    
    


    private void CarPlaceHandler(int tapLocation)
    {
        float spawnOffset;
        spawnOffset = (carModels.Count * distanceBetweenCars) * -1;
        var carXSpawnMin = spawnOffset + (distanceBetweenCars * (0 + Mathf.FloorToInt(carModels.Count / 2)));
        var carXSpawnMax = spawnOffset + (distanceBetweenCars * (carTransform.Count + Mathf.CeilToInt(carModels.Count / 2)));
        var offset = 1 - tapLocation;
        
        foreach (var car in carTransform)
        {
            var xCarOld = car.position.x;
            var newCarX = xCarOld -= distanceBetweenCars * offset *-1;
            car.position = new Vector3(newCarX, car.position.y, car.position.z);
            if (car.position.x > carXSpawnMax)
            {
                var CarXFix = carXSpawnMin + car.position.x + distanceBetweenCars;
                car.position = new Vector3(carXSpawnMin + CarXFix, car.position.y, car.position.z);
            }
            if (car.position.x < carXSpawnMin)
            {
                var carXFix = (carXSpawnMax + distanceBetweenCars)+ car.position.x;
                car.position = new Vector3(carXSpawnMax + carXFix , car.position.y, car.position.z);
            }
            if (car.position.x == 0)
                currentlySelectedCar = car.gameObject;

        }
    }

    private void CarTouchHandler()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                
                var zoneSplit = Screen.width / 3;
                for (int i = 0; i < 3; i++)
                {
                    var screenZones = new Vector2(i * zoneSplit, (i +1) * zoneSplit);
                    if (touch.position.x >= screenZones.x && touch.position.x <= screenZones.y)
                    {
                        Debug.Log(i);
                        CarPlaceHandler(i);
                    }

                }

            }

        }     
       
    }

}
