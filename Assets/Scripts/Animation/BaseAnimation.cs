using System;
using System.Collections;
using UnityEngine;

public class BaseAnimation : MonoBehaviour
{
    private bool _isAnimationStarted;
    private Coroutine _animationRoutine;

    [SerializeField] private SerializableDictionary<EAnim, string> _animTypeToAnimName;
    [SerializeField] private Animator _animator = null;

    public Animator Animator
    {
        get { return _animator; }
        set { _animator = value; }
    }

    public void PlayAnim(EAnim animType, Action callback = null)
    {
        string anim = _animTypeToAnimName.Dictionary[animType];

        if(Animator == null || anim == default)
        {
            return;
        }

        Animator.Play(anim);
        _isAnimationStarted = true;
        _animationRoutine = StartCoroutine(AnimPlayRoutine(callback));
    }

    private IEnumerator AnimPlayRoutine(Action callBack = null)
    {
        while(true)
        {
            if(_isAnimationStarted)
            {
                if(Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    _isAnimationStarted = false;
                    Debug.Log("Anim finished");
                    callBack?.Invoke();
                }
            }
            yield return null;
        }
    }
}