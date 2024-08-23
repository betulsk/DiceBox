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
    public int TotalData;
    public List<int> DiceDataList;
}

public class Dice : MonoBehaviour
{
    [SerializeField] private DiceAnimationController _diceAnimationController;
    [SerializeField] private List<Transform> _diceFaces;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _throwForce;
    [SerializeField] private float _rollForce;
    
    public void RollDice(int diceData, Action callBack = null)
    {
        _diceAnimationController.Animator.enabled = true;
        _diceAnimationController.PlayAnim((EAnim)diceData);
        StartCoroutine(this.WaitForSeconds(1f, () =>
        {
            callBack?.Invoke();
        }));
    }
}
