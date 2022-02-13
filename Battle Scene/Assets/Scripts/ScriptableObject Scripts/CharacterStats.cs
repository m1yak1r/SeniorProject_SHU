using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    PHYSICAL,
    FIRE,
    WATER,
    ELECTRIC,
    WIND,
    LIGHT,
    DARK
}

[CreateAssetMenu(fileName = "New Character", menuName = "Character", order = 1)]
public class CharacterStats : ScriptableObject
{
    public string chName;

    public int level;



    public int maxHealth;
    public int curHealth;

    public int maxMana;
    public int curMana;

    public int attack;
    public int magic;
    public int defense;
    public int speed;
    public int luck;
}
