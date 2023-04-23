using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ActiveItem
{
    [SerializeField] private Transform _modelTransform;
    [SerializeField] private Renderer _modelRenderer;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private BallSettings _ballSettings;
    [SerializeField] private Rigidbody _rigidBody;

    public override void LevelUp()
    {
        base.LevelUp();
        SetModel();
        BecomeKinematic();
        BecomeUnkinematic();
    }

    public void SetModel()
    {
        _radius = Mathf.Lerp(_ballSettings.MinRadius, _ballSettings.MaxRadius, Level / 10f);
        _collider.radius = _radius;
        _modelRenderer.material = _ballSettings.GetMaterial(Level);
        _modelTransform.localScale = _radius * Vector3.one * 2f;
        Trigger.radius = _radius + _radius * 0.1f;
        InCollision = false;
    }

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel(int value)
    {
        Level = value;
    }

    public void BecomeKinematic()
    {
        _rigidBody.isKinematic = true;
        _collider.enabled = false;
        Trigger.enabled = false;
    }

    public void BecomeUnkinematic()
    {
        _rigidBody.isKinematic = false;
        _collider.enabled = true;
        Trigger.enabled = true;

        _rigidBody.AddForce(Vector3.down, ForceMode.VelocityChange);
    }
 
    protected override void ResponseTrigger(ActiveItem trigger)
    {
        
    }

  
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
