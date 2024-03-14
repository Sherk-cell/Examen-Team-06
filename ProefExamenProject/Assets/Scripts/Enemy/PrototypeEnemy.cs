using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrototypeEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float baseSpeed;
    private GameObject _player;

    [Header("Game Over Settings: ")] 
    [SerializeField] private GameObject setGameOver;
    
    private float _playerPosX;
    public GameObject model;
    [SerializeField] private float maxDistance;
    void Start()
    {
        setGameOver.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        _playerPosX = _player.gameObject.transform.position.x;
        transform.Translate(0 , 0, speed * Time.deltaTime);
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector3.Distance(_player.transform.position, this.gameObject.transform.position);
        transform.position = new Vector3(_playerPosX, transform.position.y, transform.position.z);
        if (distance > maxDistance)
        {

        }
        else
        {
            speed = baseSpeed;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            setGameOver.SetActive(true);
        }
    }
}
