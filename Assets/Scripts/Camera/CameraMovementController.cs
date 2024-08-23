using System.Collections;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    private Coroutine _lerpRoutine;
    private float _initialFOV;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _fovValue;
    [SerializeField] private float _transitionSpeed;

    private void Start()
    {
        _initialFOV = _mainCamera.fieldOfView;
        GameManager.Instance.OnDiceDataSet += OnDiceDataSet;
        GameManager.Instance.OnDiceStopped += OnDiceStopped;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnDiceDataSet -= OnDiceDataSet;
        GameManager.Instance.OnDiceStopped -= OnDiceStopped;
    }

    private void OnDiceDataSet()
    {
        ZoomOutCamera();
    }

    private void OnDiceStopped()
    {
        ZoomInCamera();
    }

    private void ZoomInCamera()
    {
        if(_lerpRoutine != null)
        {
            StopCoroutine(_lerpRoutine);
        }
        _lerpRoutine = StartCoroutine(LerpRoutine(_initialFOV));
    }

    private void ZoomOutCamera()
    {
        if(_lerpRoutine != null)
        {
            StopCoroutine(_lerpRoutine);
        }
        _lerpRoutine = StartCoroutine(LerpRoutine(_fovValue));
    }

    private IEnumerator LerpRoutine(float targetValue)
    {
        var currentValue = 0f;
        while(true)
        {
            currentValue = Mathf.Lerp(_mainCamera.fieldOfView, targetValue, _transitionSpeed * Time.deltaTime);
            _mainCamera.fieldOfView = currentValue;
            if(Mathf.Abs(currentValue - targetValue) < 1)
            {
                StopCoroutine(_lerpRoutine);
            }
            yield return null;
        }
    }
}
