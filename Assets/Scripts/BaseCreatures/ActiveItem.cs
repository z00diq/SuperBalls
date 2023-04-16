using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private TMP_Text _numberText;

    protected float _radius;

    [ContextMenu("Increase Level")]
    private void IcnreaseLevel()
    {
        _level++;
        SetLevel(_level);
    }

    public virtual void SetLevel(int level)
    {
        int number = (int)Mathf.Pow(2, _level + 1);
        _numberText.text = number.ToString();
    }
}
