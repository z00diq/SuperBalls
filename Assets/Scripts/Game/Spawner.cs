using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _intensity=25f;
    [SerializeField] private float _maxPosition = 2.5f;

    private float _oldPositionX;
    private float _mousePositionX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldPositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - _oldPositionX;
            _oldPositionX = Input.mousePosition.x;
            _mousePositionX += delta * _intensity / Screen.width;
            _mousePositionX = Math.Clamp(_mousePositionX, -_maxPosition, _maxPosition);
            transform.position = new Vector3(_mousePositionX,transform.position.y,transform.position.z);
        }
    }
}
