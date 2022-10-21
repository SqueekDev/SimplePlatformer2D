using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Coin _template;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        Vector3 spawnPosition = _startPoint.position;
        int spawnStep = 3;

        while (spawnPosition.x <= _endPoint.position.x)
        {
            Instantiate(_template, spawnPosition, Quaternion.identity, transform);
            spawnPosition.x += spawnStep;
        }
    }
}
