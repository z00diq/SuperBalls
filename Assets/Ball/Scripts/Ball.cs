using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ActiveItem
{
    [SerializeField] private Transform _modelTransform;
    [SerializeField] private Renderer _modelRenderer;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private SphereCollider _trigger;
    [SerializeField] private BallSettings _ballSettings;
    [SerializeField] private Rigidbody _rigidBody;

    public override void SetLevel(int level)
    {
        base.SetLevel(level);

        _radius = Mathf.Lerp(_ballSettings.MinRadius, _ballSettings.MaxRadius, Level / 10f);
        _collider.radius = _radius;
        _modelRenderer.material = _ballSettings.GetMaterial(Level);
        _modelTransform.localScale = _radius * Vector3.one * 2f;
        _trigger.radius = _radius + _radius * 0.1f;
    }

    public void BecomeKinematic()
    {
        _rigidBody.isKinematic = true;
        _collider.enabled = false;
        _trigger.enabled = false;
    }
    public void BecomeUnkinematic()
    {
        _rigidBody.isKinematic = false;
        _collider.enabled = true;
        _trigger.enabled = true;

        _rigidBody.AddForce(Vector3.down, ForceMode.VelocityChange);
    }
}
