using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    private int damage;
    private int defense;
    public bool attack = false; // 공격
    public bool block = false; // 방어도
    public bool power = false; // 힘


    public void SetAttackDamage(int damage) {
        this.damage = damage;
    }

    public void SetDefense(int defense) {
        this.defense = defense;
    }

    public int GetAttackDamage() {
        return damage;
    }

    public int GetDefense() {
        return defense;
    }
}
