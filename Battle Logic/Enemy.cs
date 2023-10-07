using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Max_Enemy_HP;
    public int cur_Enemy_HP;
    public int damage;
    
    public State state = new State();
    bool dup = false;
    
    // random 난수, switch-case문 이용
    
    void Update()
    {
    }

    public void Spawn_Enemy(int ran_Spawn) {
        if(GameManager.Turn_Count != 1) {
            return;
        }

        switch(ran_Spawn) {
            case 0:
                Jaw_Worm();
                break;
            case 1:
                Slime();
                break;
        }
    }

    public void Jaw_Worm() {
        Max_Enemy_HP = 40;
        cur_Enemy_HP = 40;
        damage = state.GetAttackDamage(); 
    }


    public void Act_Enemy(int case) {
        state.attack = false;
        state.block = false;
        switch(case) {
            case 0: // 턱벌레 패턴
                if(GameManager.Turn_Count == 1) {
                    state.attack = true;
                    state.SetAttackDamage(11);
                    return;
                }
                else {
                    int ran = Random.Range(0, 2);
                    switch (ran)
                    {  
                        case 0: 
                            state.attack = true;
                            state.SetAttackDamage(11);
                            break;
                        case 1:
                            state.attack = true;
                            state.block = true;
                            state.SetAttackDamage(7);
                            state.SetDefense(5);
                            break;
                        case 2:
                            state.attack = false;
                            if(dup) {
                                dup = false;
                                break;
                            }
                            state.block = true;
                            state.SetDefense(6);
                            dup = true;
                            break;
                    }
                }
        }

        
            
    }
}
