using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    [SerializeField] protected SphereCollider Trigger;
    [SerializeField] private TMP_Text _numberText;

    protected int Level=0;
    protected float _radius;
    protected bool InCollision = false;

    public virtual void SetLevel(int level)
    {
        Level = level;
        int number = (int)Mathf.Pow(2, level + 1);
        _numberText.text = number.ToString();
    }

    protected virtual void ResponseTrigger(ActiveItem trigger){}

    [ContextMenu("Increase Level")]
    private void IcnreaseLevel()
    {
        Level++;
        SetLevel(Level);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out ActiveItem otherActiveItem))
                if (otherActiveItem.InCollision == false)
                    if (otherActiveItem.Level == Level)
                    {
                        otherActiveItem.Trigger.enabled = false;
                        otherActiveItem.InCollision = true;
                        InCollision = true;
                        ResponseTrigger(otherActiveItem);
                    }
        } 
        else
        {
            
        }

    }

}
