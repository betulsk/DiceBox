using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawnController : MonoBehaviour
{
    private int _diceCount = 2;
    [SerializeField] private GameObject _dicePrefab;
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
            GameObject diceObject = Instantiate(_dicePrefab, _spawnPositions[random].position, Quaternion.identity);
            Dice dice = diceObject.GetComponentInChildren<Dice>();
            dice.Rb.useGravity = true;
            dice.Rb.isKinematic = false;
            dice.AddForceRb(_spawnPositions[random].position);
            dice.GetNumberOnTop();
            dice.RollDice(GameManager.Instance.DiceDatas.FirstData);
            dice.Rb.useGravity = false;
            dice.Rb.isKinematic = true;
        }
    }
}
