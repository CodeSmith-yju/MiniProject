using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    private int damage; // 데미지 정수 변수
    private int defense; // 방어도 상태 확인 후 방어도 정수 변수
    public bool attack; // 공격 상태 확인
    public bool block; // 방어도 상태 확인 (기본적으로 모든 턴 종료 후 false 상태로 변함)
    public bool power; // 힘 상태 확인
    public bool injury; // 손상 상태 확인
    public bool weak; // 약화 상태 확인



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

    public void Injury_Dur(int dur) {
        
    }

    public void Power_Dur(int dur) {

    }

    public void Weak_Dur(int dur) {
        
    }
}