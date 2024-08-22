using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DiceDatas
{
    public int FirstData;
    public int SecondData;
    public bool FirstDataSet;
    public bool SecondDataSet;
}

public class Dice : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _throwForce;
    [SerializeField] private List<Transform> _diceFaces;

    private void Start()
    {
        GameManager.Instance.OnDiceDataSet += OnDiceDataSet;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDiceDataSet -= OnDiceDataSet;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetNumberOnTop();
        }
    }

    private void OnDiceDataSet()
    {
        RollDice();
    }

    public void GetNumberOnTop()
    {
        if (_diceFaces == null)
        {
            return;
        }
        var topFace = 0;
        var lastYPosition = _diceFaces[0].position.y;

        for(int i = 0; i < _diceFaces.Count; i++)
        {
            if(_diceFaces[i].position.y > lastYPosition)
            {
                lastYPosition = _diceFaces[i].position.y;
                topFace = i;
            }
        }
    }

    private void RollDice()
    {
        //_rigidbody.AddForce(transform.forward * (_throwForce + UnityEngine.Random.Range(-1f, 1f)), ForceMode.Impulse);

    }

    public void StopRolling()
    {
    }
}
