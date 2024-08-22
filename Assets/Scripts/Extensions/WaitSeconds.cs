using System;
using System.Collections;
using UnityEngine;

public static class WaitSeconds
{
    public static IEnumerator WaitForSeconds(this MonoBehaviour monoBehaviour, float seconds, Action callBack = null)
    {
        yield return new WaitForSeconds(seconds);
        callBack?.Invoke();
    }
}
