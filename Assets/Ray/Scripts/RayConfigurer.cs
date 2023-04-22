using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayConfigurer : MonoBehaviour
{
    [SerializeField] private Renderer _rayRenderer;
    [SerializeField] private Ray _ray;

    private Ball _ballInSpawn;

    public void SetBall(Ball ball)
    {
        _ballInSpawn = ball;
        _ray.SetUpRay(_ballInSpawn.transform.position, _ballInSpawn.transform.localScale.x / 2);
        _ray.gameObject.SetActive(true);
        ChangeMaterialColor(ball.GetLevel());

    } 

    public void UnsetBll()
    {
        _ballInSpawn = null;
        _ray.gameObject.SetActive(false);
    }

    private void ChangeMaterialColor(int matIndex)
    {
        _rayRenderer.material.color = _ballInSpawn.GetComponentInChildren<Renderer>().material.color;
    }
}
