using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DiceSpawnController : MonoBehaviour
{
    private int _diceCount = 2;
    private List<Dice> _dices = new List<Dice>();

    [SerializeField] private Dice _dicePrefab;
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private ParentConstraint _parentConstraint;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private float _randomRange = 3f;

    private void Start()
    {
        GameManager.Instance.OnDiceDataSet += OnDiceDataSet;
        GameManager.Instance.OnMovementCompleted += OnMovementCompleted;
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnDiceDataSet -= OnDiceDataSet;
            GameManager.Instance.OnMovementCompleted -= OnMovementCompleted;
        }
    }

    private void OnDiceDataSet()
    {
        SpawnDice();
    }

    private void OnMovementCompleted()
    {
        _parentConstraint.constraintActive = true;
    }

    private void SpawnDice()
    {
        DestroyDice();
        _parentConstraint.constraintActive = false;
        for(int i = 0; i < _diceCount; i++)
        {
            Dice dice = Instantiate(_dicePrefab, _spawnPositions[i].position, Quaternion.identity, null);
            _dices.Add(dice);
            dice.RollDice(GameManager.Instance.DiceDataList[i]);
        }
        StartCoroutine(this.WaitForSeconds(2f, () =>
        {
            GameManager.Instance.OnDiceStopped?.Invoke();
        }));
    }

    private void DestroyDice()
    {
        if(_dices != null)
        {
            foreach(Dice dice in _dices)
            {
                DestroyImmediate(dice.gameObject);
            }
            _dices.Clear();
        }
    }
}
