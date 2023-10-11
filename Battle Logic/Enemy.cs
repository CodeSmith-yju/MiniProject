using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : State
{
    
    public Character player;
    [HideInInspector] public int max_Enemy_HP;
    [HideInInspector] public int cur_Enemy_HP;
    [HideInInspector] public int cur_Enemy_Defense_cut;
    [HideInInspector] public int damage;
    
    // public State state; // enemy 상태 State 객체
    bool dup = false; // 중복 방지 변수
    
    // random 난수, switch-case문 이용
    
    public void Spawn_Enemy(int ran_Spawn) {
        if(GameManager.Turn_Count != 0) {
            return;
        }

        switch(ran_Spawn) {
            case 0:
                Jaw_Worm();
                break;
            case 1:
                Silme();
                break;
        }
    }

    public void Jaw_Worm() {
        max_Enemy_HP = 40;
        cur_Enemy_HP = 40;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    public void Silme() {
        max_Enemy_HP = 65;
        cur_Enemy_HP = 65;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    public void Enemy_state(int maxHp, int curHp) {
        max_Enemy_HP = maxHp;
        cur_Enemy_HP = curHp;
    }


    public void Act_Enemy(int cases) {
        attack = false;
        SetAttackDamage(0);
        block = false;
        SetDefense(0);
        switch(cases) {
            case 0: // 턱벌레 패턴
                if(GameManager.Turn_Count == 1) {
                    attack = true;
                    SetAttackDamage(11);
                    damage = GetAttackDamage();
                    return;
                }
                else {
                    int ran = Random.Range(0, 2);
                    switch (ran)
                    {  
                        case 0: 
                            attack = true;
                            SetAttackDamage(11);
                            damage = GetAttackDamage();
                            break;
                        case 1:
                            attack = true;
                            block = true;
                            SetAttackDamage(7);
                            damage = GetAttackDamage();
                            SetDefense(5);
                            cur_Enemy_Defense_cut = GetDefense();
                            break;
                        case 2:
                            attack = false;
                            if(dup) {
                                dup = false;
                                break;
                            }
                            block = true;
                            SetDefense(6);
                            cur_Enemy_Defense_cut = GetDefense();
                            dup = true;
                            break;
                    }
                }
                break;
            case 1: // 슬라임 패턴
                int ran_2 = Random.Range(0, 2);
                switch(ran_2) 
                {
                    case 0:
                        attack = true;
                        SetAttackDamage(16);
                        break;
                    case 1:
                        player.injury = true;
                        player.Injury_Dur(2);
                        attack = true;
                        SetAttackDamage(0);
                        break;
                    case 2:
                        attack = true;
                        SetAttackDamage(0);
                        player.weak = true;
                        player.Weak_Dur(2);
                        break;
                }
                break;
        }

        
            
    }
}
