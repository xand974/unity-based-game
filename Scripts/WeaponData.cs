using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int Damage;
    public string Name;
    public int FreezeDuration;
    public GameObject Prefab;
}
