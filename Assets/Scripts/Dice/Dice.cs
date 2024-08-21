using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _throwForce;
    [SerializeField] private List<Transform> _diceFaces;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetNumberOnTop();
        }
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

    public void RollDice()
    {
        _rigidbody.AddForce(transform.forward * (_throwForce + Random.Range(-1f, 1f)), ForceMode.Impulse);
    }

    public void StopRolling()
    {
    }
}
