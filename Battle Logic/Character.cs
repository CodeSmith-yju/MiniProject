using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : State
{
    
    [HideInInspector] public int max_Player_HP;
    [HideInInspector] public int cur_Player_HP;
    [HideInInspector] public int cur_Player_Defense_cut;
    [HideInInspector] public bool barricade = false;
    [HideInInspector] public bool Max_Cost_Relic = false;
    public Enemy monster;

    public void Spawn_Player() {
        max_Player_HP = 80;
        cur_Player_HP = 80;
        Player_state(max_Player_HP, cur_Player_HP);
    }


    public void Player_state(int max, int cur) {
        max_Player_HP = max;
        cur_Player_HP = cur;

        if(GameManager.Turn_Count == 1) {
            cur_Player_Defense_cut = 0;
        }

        
        if(block) {
            cur_Player_Defense_cut += GetDefense();
        }
    }
}
