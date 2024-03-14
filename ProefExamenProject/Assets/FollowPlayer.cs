using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private int distanceFromPlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + distanceFromPlayer);
        transform.position = pos;
    }
}
