using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Max_Player_HP;
    public int cur_Player_HP;
    public int cur_Player_Defense_cut;
    public bool barricade = false;
    public bool Max_Cost_Relic = false;

    public State state = new State();
    public Enemy monster;


    public void Player_state() {
        Max_Player_HP = 80;
        cur_Player_HP = 80;

        
        if(state.block) {
            cur_Player_Defense_cut += state.GetDefense();
        }
    }
}
