using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBehaviour : BaseMovementBehaviour
{
    private Coroutine _jumpRoutine;
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
        _jumpRoutine = StartCoroutine(JumpToTarget(targetTransforms, () =>
        {
            Debug.Log("!!JumpCompleted");
            _stepCount++;
            if(_stepCount >= GameManager.Instance.DiceDatas.TotalData)
            {
                Debug.Log("!!_StepCount is " + _stepCount);
                _stepCount = 0;
                StopCoroutine(_jumpRoutine);
                OnMovementStop?.Invoke();
                GameManager.Instance.OnMovementCompleted?.Invoke();
                return;
            }
            Debug.Log("!!_StepCount is and Jump" + _stepCount);
            StopCoroutine(_jumpRoutine);
            if(_character.TileCount >= targetTransforms.Count)
            {
                _character.TileCount = 0;
                _movementSpeed *= 2f;
            }
            MoveCustomActions(targetTransforms);
        }));

    }

    private IEnumerator JumpToTarget(List<BoardPiece> targetTransforms, Action onComplete = null)
    {
        Vector3 startPosition = _character.transform.position;
        Vector3 targetPosition = targetTransforms[_character.TileCount].TargetPoint.position;
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
        _character.TileCount++;
        Debug.Log($"!Jump finished: {_character.TileCount}");
        _movementSpeed = _initSpeed;

        onComplete?.Invoke();
    }
}
