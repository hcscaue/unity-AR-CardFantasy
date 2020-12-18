using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Hero")]
public class CardHero : ScriptableObject
{

    public string heroName;

    [Multiline]
    public string descriptionHero;

    public int Life, Attack;
    public float multiplyAttack;

    public RuntimeAnimatorController animator;

    public enum Passive { Shielded, LootReal, Enraged }
    public Passive special;

    [Multiline]
    public string descriptionSpecial;
    public int cooldown;

}
