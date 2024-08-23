using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovementBehaviour : BaseMovementBehaviour
{
    private Coroutine _jumpRoutine;
    private List<BoardPiece> _targetTransforms = new List<BoardPiece>();
    private int _stepCount = 0;
    private float _initSpeed = 4;

    [SerializeField] private Character _character;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _movementSpeed = 10;

    public Action OnMovementStarted;
    public Action OnMovementStop;

    private void Awake()
    {
        _initSpeed = _movementSpeed;
    }

    public override void MoveCustomActions(List<BoardPiece> targetTransforms)
    {
        _targetTransforms = targetTransforms;
        _jumpRoutine = StartCoroutine(JumpToTarget(() =>
        {
            _stepCount++;

            if(_stepCount >= GameManager.Instance.DiceDatas.TotalData)
            {
                _stepCount = 0;
                StopCoroutine(_jumpRoutine);
                OnMovementStop?.Invoke();
                GameManager.Instance.OnMovementCompleted?.Invoke();
                return;
            }
            StopCoroutine(_jumpRoutine);
            MoveCustomActions(targetTransforms);
        }));

    }

    private IEnumerator JumpToTarget(Action onComplete = null)
    {
        _character.CurrentBoardIndex++;
        Vector3 startPosition = _character.transform.position;
        SetTargetPiece();
        Vector3 targetPosition = _targetTransforms[_character.CurrentBoardIndex].TargetPoint.position;
        Vector3 handlePosition = Vector3.Lerp(startPosition, targetPosition, 0.5f);
        handlePosition.y += _jumpPower;

        float distance = (startPosition - targetPosition).magnitude;
        float duration = distance / _movementSpeed;

        for(float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            _character.transform.position = Vector3.Lerp(
                Vector3.Lerp(
                    startPosition,
                    handlePosition,
                    i),
                Vector3.Lerp(
                    handlePosition,
                    targetPosition,
                    i),
                i);

            yield return null;
        }
        _movementSpeed = _initSpeed;
        onComplete?.Invoke();
    }

    private void SetTargetPiece()
    {
        if(_character.CurrentBoardIndex == _targetTransforms.Count)
        {
            _character.CurrentBoardIndex = 0;
            _movementSpeed *= 2f;
        }
    }
}
