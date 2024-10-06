using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseStats", menuName = "ScriptableObjects/BaseStats", order = 1)]
public class BaseStats : ScriptableObject
{
    [Header("Assets References")]
    public string unitName;

    [Header("General Stats")]
    public float health;
    public float movementSpeed;

    [Header("Attack Stats")]
    public float attackDamage;
    public float attackSpeed;
}
