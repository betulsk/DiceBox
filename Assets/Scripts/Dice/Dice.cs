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
}

public class Dice : MonoBehaviour
{
    [SerializeField] private DiceAnimationController _diceAnimationController;
    [SerializeField] private List<Transform> _diceFaces;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _throwForce;
    [SerializeField] private float _rollForce;

    private void Start()
    {
        GameManager.Instance.OnDiceDataSet += OnDiceDataSet;
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnDiceDataSet -= OnDiceDataSet;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            RollDice();
        }
    }

    private void OnDiceDataSet()
    {
        RollDice();
    }

    public void GetNumberOnTop()
    {
        if(_diceFaces == null)
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
        Debug.Log("!RollDice");
        var randomVariance = UnityEngine.Random.Range(-1f, 1f);
        _rigidbody.AddForce(-_rigidbody.gameObject.transform.up * (_throwForce + randomVariance), ForceMode.Impulse);
        var randX = UnityEngine.Random.Range(0f, 1f);
        var randY = UnityEngine.Random.Range(0f, 1f);
        var randZ = UnityEngine.Random.Range(0f, 1f);
        _rigidbody.AddTorque(new Vector3(randX, randY, randZ) * (_rollForce + randomVariance), ForceMode.Impulse);
        Debug.Log("!Next step is anim");
        GameManager.Instance.OnDiceStopped?.Invoke();
        StartCoroutine(this.WaitForSeconds(5f, () =>
        {
            Debug.Log("!Anim must play");
            StopRolling();
            //_diceAnimationController.Animator.enabled = true;
            //_diceAnimationController.PlayAnim(EAnim.Dice_3);
        }));
    }

    public void StopRolling()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
