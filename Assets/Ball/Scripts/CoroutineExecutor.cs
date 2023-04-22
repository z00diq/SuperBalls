using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineExecutor
{
    public static Coroutine StartCoroutine(IEnumerator func, MonoBehaviour host)
    {
        return host.StartCoroutine(func);
    }
}
