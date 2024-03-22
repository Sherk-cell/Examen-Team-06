using System;
using UnityEngine;

namespace Obstacles.Cars
{
    public class ObstacleCar : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject gameOver;
        
        private  GameObject[] _allObjects;
        
        private void Start()
        {
            _allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            
            foreach (var obj in _allObjects)
            {
                if (!obj.activeInHierarchy && obj.name == "Panel")
                    obj.SetActive(false);
            }
        }

        private void Update()
        {
            transform.Translate(0 , 0, -speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            
                foreach (var obj in _allObjects)
                {
                    if (!obj.activeInHierarchy && obj.name == "Panel")
                        obj.SetActive(true);
                }
                Time.timeScale = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Deleter"))
                Destroy(gameObject);
        }
    }
}
