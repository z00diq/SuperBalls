using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _numberText;

    protected int Level=0;
    protected float _radius;

    [ContextMenu("Increase Level")]
    private void IcnreaseLevel()
    {
        Level++;
        SetLevel(Level);
    }

    public virtual void SetLevel(int level)
    {
        int number = (int)Mathf.Pow(2, level + 1);
        Level = level;
        _numberText.text = number.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
            if(other.attachedRigidbody.TryGetComponent(out ActiveItem otherActiveItem))
                if (otherActiveItem.Level == Level)
                {
                    Destroy(otherActiveItem.gameObject);
                    SetLevel(Level + 1);
                }
    }
}
