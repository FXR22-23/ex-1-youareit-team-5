using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject ai;
 
    public bool isPlayerIt;
    private Collider _aiCollider;
    private Collider _playerCollider;
    public Vector3 initialIt;
    public Vector3 initialNotIt;

    void Start ()
    {
        _playerCollider = player.GetComponent<Collider>();
        _aiCollider = ai.GetComponent<Collider>();
        // Set the AI as "it"
        isPlayerIt = false;
    }

    public void Reset()
    {
        initialIt = new Vector3(Random.Range(-40, 0), 0, Random.Range(-40, 40));
        initialNotIt = new Vector3(Random.Range(0, 40), 0, Random.Range(-40, 40));
        // Switch roles
        if (isPlayerIt)
        {
            player.transform.position = initialNotIt;
            ai.transform.position = initialIt;
            print("AI is it!");
        }
        else
        {
            player.transform.position = initialIt;
            ai.transform.position = initialNotIt;
            print("Player is it!");
        }
        isPlayerIt = !isPlayerIt;
    }
}