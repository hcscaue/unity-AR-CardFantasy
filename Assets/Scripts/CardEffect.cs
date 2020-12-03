using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Effect")]
public class CardEffect : ScriptableObject {

    public string cardName;

    [Multiline]
    public string description;

    public int mana;

    public Animator animator;                               

}