using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    [SerializeField] protected SphereCollider Trigger;
    [SerializeField] private TMP_Text _numberText;

    protected int Level=0;
    protected float _radius;

    public virtual void LevelUp()
    {
        Level++;
        SetLevel();
        
    }

    public virtual void SetLevel()
    {
        int number = (int)Mathf.Pow(2, Level + 1);
        _numberText.text = number.ToString();
    }

    protected async virtual Task ResponseTrigger(ActiveItem trigger){}

    [ContextMenu("Increase Level")]
    private void IcnreaseLevel()
    {
        LevelUp();
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            if (other.attachedRigidbody.TryGetComponent(out ActiveItem otherActiveItem))
                if (otherActiveItem.Level == Level)
                    await ResponseTrigger(otherActiveItem);
       

    }

}
