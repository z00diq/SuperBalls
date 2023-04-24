 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private int _maxBallLevelNumber=10;
    [SerializeField] private RayConfigurer _rayConfigurer;
    private Ball _ballInTube;
    private Ball _ballInSpawn;

    private void Start()
    {
        CreateBall();
        StartCoroutine(nameof(MoveBallOnSpawn));
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PushBall();
        }
        //tim += Time.deltaTime;
        //if (tim >= 0.5f)
        //{
        //    PushBall();
        //    tim = 0;
        //}
    }

    private void CreateBall()
    {
        _ballInTube = Instantiate(_ballPrefab, transform.position, Quaternion.identity);
        _ballInTube.SetLevel(Random.Range(0,_maxBallLevelNumber));
        _ballInTube.SetModel();
        _ballInTube.BecomeKinematic();
    }

    private void PushBall()
    {
        if (_ballInSpawn == null)
            return;
        _ballInSpawn.transform.parent = null;
        _ballInSpawn.BecomeUnkinematic();
        _rayConfigurer.UnsetBall();
        _ballInSpawn = null;
        StartCoroutine(nameof(MoveBallOnSpawn));

    }

    private IEnumerator MoveBallOnSpawn()
    {
        while (Vector3.Distance(_ballInTube.transform.position, _spawn.position) > 0)
        {
            _ballInTube.transform.position = Vector3.MoveTowards(_ballInTube.transform.position,
                _spawn.position, Time.deltaTime*10f);
            yield return new WaitForEndOfFrame();
        }
        _ballInSpawn = _ballInTube;
        _ballInSpawn.transform.parent = _spawn;
        _rayConfigurer.SetBall(_ballInSpawn);
        _ballInTube = null;
        CreateBall();
    }
}
