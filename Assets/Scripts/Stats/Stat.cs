using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Stat
{
    [SerializeField]
    private float baseValue;

    public List<float> modifiers;

    public float GetValue()
    {
        float finalvalue = baseValue;

        foreach (float modifier in modifiers)
        {
            finalvalue += modifier;
        }
        return finalvalue;
    }

    public void AddModifiers(float newModifier)
    {
        modifiers.Add(newModifier);
    }

    public void RemoveModifiers(float newModifier)
    {
        modifiers.Remove(newModifier);
    }


}
