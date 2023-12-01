using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTarget", menuName = "Targets/New Target")]
public class TargetData : ScriptableObject
{
    public int currentHealth;
    public int maxHealth;
    public int pointValue;

    public bool isMobile;
}
