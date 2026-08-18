using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite Icon;

    public bool isGold;

    [Header("Stats")]
    public int currenHealth;
    public int maxHealth;
    public int speed;
    public int damage;

    [Header("For Temporary Items")]

    public float duration;

}
