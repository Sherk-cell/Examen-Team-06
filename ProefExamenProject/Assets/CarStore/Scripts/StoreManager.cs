using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private Transform carCatalog;
    [SerializeField] private List<GameObject> carModels = new List<GameObject>();
    [SerializeField] private float distanceBetweenCars;
    private List<Transform> carTransform = new List<Transform>();
    private void Awake()
    {
        loadCars();
        spawnCars();
    }
    private void Update()
    {
        carTouchHandler();
    }


    private void loadCars()
    {
        var cars = Resources.LoadAll<GameObject>("CarModels");

        foreach (var car in cars)
        {
            carModels.Add(car);
        }
    }
    private void spawnCars()
    {
        for (int i = 0; i < carModels.Count; i++)
        {
            var SpawnOffset = (carModels.Count * distanceBetweenCars) * -1;
            var CarXSpawn = SpawnOffset + (distanceBetweenCars * (i + Mathf.FloorToInt(carModels.Count / 2)));
            var CurrentCar = Instantiate(carModels[i], new Vector3(CarXSpawn, carModels[i].transform.position.y, carModels[i].transform.position.z), Quaternion.identity, carCatalog);
            carTransform.Add(CurrentCar.transform);
        }
    }


    private void carPlaceHandler(int TapLocation)
    {
        var SpawnOffset = (carModels.Count * distanceBetweenCars) * -1;
        var CarXSpawnMin = SpawnOffset + (distanceBetweenCars * (0 + Mathf.FloorToInt(carModels.Count / 2)));
        var CarXSpawnMax = SpawnOffset + (distanceBetweenCars * (carTransform.Count + Mathf.CeilToInt(carModels.Count / 2)));
        var Offset = 2 - TapLocation;
        
        foreach (var Car in carTransform)
        {
            var xCarOld = Car.position.x;
            var newCarX = xCarOld -= distanceBetweenCars * Offset *-1;
            Car.position = new Vector3(newCarX, Car.position.y, Car.position.z);
            if (Car.position.x > CarXSpawnMax)
            {
                Debug.Log(Car.position.x);
                var CarXFix = CarXSpawnMin + Car.position.x + distanceBetweenCars;
                Car.position = new Vector3(CarXSpawnMin + CarXFix, Car.position.y, Car.position.z);
            }
            if (Car.position.x < CarXSpawnMin)
            {
                Debug.Log(Car.position.x);
                var CarXFix = (CarXSpawnMax + distanceBetweenCars)+ Car.position.x;
                Car.position = new Vector3(CarXSpawnMax + CarXFix , Car.position.y, Car.position.z);
            }
        }
    }

    private void carTouchHandler()
    {
        if(Input.touchCount > 0)
        {
            var Touch = Input.GetTouch(0);
            if (Touch.phase == TouchPhase.Began)
            {
                var ZoneSplit = Screen.width / 5;
                for (int i = 0; i < 5; i++)
                {
                    var ScreenZones = new Vector2(i * ZoneSplit, (i + 1) * ZoneSplit);
                    if (Touch.position.x >= ScreenZones.x && Touch.position.x <= ScreenZones.y)
                    {
                        carPlaceHandler(i);
                    }

                }

            }

        }     
       
    }






}
