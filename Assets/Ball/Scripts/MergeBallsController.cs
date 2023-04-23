using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public  class MergeBallsController
{
    private static MergeBallsController _instance;

    public static MergeBallsController Create()
    {
        if (_instance != null)
            return _instance;

        _instance = new MergeBallsController();
        return _instance;
    }

    private IEnumerator StartMergeCoroutine(Ball fromBall, Ball toBall)
    {
        while (fromBall.transform.position != toBall.transform.position)
        {
            fromBall.transform.position = Vector3.MoveTowards(fromBall.transform.position,
                toBall.transform.position, Time.deltaTime * 3f);
            yield return null;
        }

        fromBall.Destroy();
        toBall.LevelUp();
    }  
}
