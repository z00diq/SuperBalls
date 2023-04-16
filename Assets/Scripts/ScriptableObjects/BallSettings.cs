using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BallSettings",menuName ="Ball/Settings")]
public class BallSettings : ScriptableObject
{
    [SerializeField] private Material[] _ballMaterials;
    [SerializeField] private float _minRadius=0.4f;
    [SerializeField] private float _maxRadius = 0.7f;

    public float MinRadius => _minRadius;
    public float MaxRadius => _maxRadius;

    public Material GetMaterial(int index)
    {
        if (index < 0 || index > _ballMaterials.Length)
            return null;
        return _ballMaterials[index];
    }
}
