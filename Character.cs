using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Max_Player_HP;
    public int cur_Player_HP;

    void Update() {
    }

    public void Player_state() {
        Max_Player_HP = 80;
        cur_Player_HP = 80;
    }
}
