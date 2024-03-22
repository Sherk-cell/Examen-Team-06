using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class RandomSpawner : MonoBehaviour
    {

        [Header("Spawner Settings: ")] 
        [SerializeField] private GameObject[] randomObjects;
        [SerializeField] private GameObject boundsObject;
        [SerializeField] private int maxSpawnedIn = 10;

        [Header("Grid Settings: ")] 
        [SerializeField] [Range(0, 500)] private int gridRows;
        [SerializeField] [Range(0, 500)] private int gridCols;
        
        private HashSet<Vector3> _occupiedPositions;

        // Start is called before the first frame update
        private void Start()
        {
            _occupiedPositions = new HashSet<Vector3>();

            var randomChance = Random.Range(0, 100);
            
            if (randomChance < 50)
                SpawnIn();
        } 

        private void SpawnIn()
        {
            if (boundsObject == null)
            {
                Debug.LogError("Bounds Object isn't set");
                return;
            }

            for (var i = 0; i < Random.Range(1,maxSpawnedIn); i++)
            {
                // Choose a random object to spawn
                var getInt = Random.Range(0, randomObjects.Length);
                var objectToSpawn = randomObjects[getInt];
                var bounds = boundsObject.GetComponent<Renderer>().bounds;
                var spawnPos = FindValidSpawnPosition(bounds);
            
               
                Instantiate(objectToSpawn, spawnPos, Quaternion.identity, transform);
            }
        }
        
        private Vector3 FindValidSpawnPosition(Bounds bounds)
        {
            var cellSizeX = bounds.size.x / (gridCols - 1);
            var cellSizeZ = bounds.size.z / (gridRows - 1);
            
            var maxAttempts = gridRows * gridCols;
            var attempts = 0;
            Vector3 spawnPos;
            
            do
            {
                var gridX = Random.Range(0, gridCols);
                var gridZ = Random.Range(0, gridRows);
                
                spawnPos = boundsObject.transform.position + new Vector3(gridX * cellSizeX, 0.04999876f, gridZ * cellSizeZ) - bounds.extents;
                if (!_occupiedPositions.Contains(spawnPos))
                {
                    _occupiedPositions.Add(spawnPos);
                    break;
                }
                
                attempts++;
            } 
            
            while (attempts < maxAttempts);
            return spawnPos;
        }
    }
}
