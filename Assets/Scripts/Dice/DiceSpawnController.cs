using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawnController : MonoBehaviour
{
    private int _diceCount = 2;
    [SerializeField] private Dice _dicePrefab;
    [SerializeField] private List<Transform> _spawnPositions;

    private void Start()
    {
        GameManager.Instance.OnDiceDataSet += OnDiceDataSet;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDiceDataSet -= OnDiceDataSet;
    }

    private void OnDiceDataSet()
    {
        SpawnDice();
    }

    private void SpawnDice()
    {
        for(int i = 0; i < 1; i++)
        {
            int random = UnityEngine.Random.Range(0, _spawnPositions.Count);
            Dice diceObject = Instantiate(_dicePrefab, _spawnPositions[random].position, Quaternion.identity, transform);
            
        }
    }
}
