using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Turn_Count;
    private Character character;
    private Enemy enemy;
    private Card card;
    private State state;
    private int cur_Cost;
    private int max_Cost;
    private int enemy_spawn;

    protected enum States {
        Player_Turn, Enemy_Turn, End_Battle
    }
    
    private States states;
    

    void Awake() {
        Turn_Count = 0;
        enemy_spawn = Random.Range(0, 1);
        character.Player_state();
        enemy.Spawn_Enemy(enemy_spawn);
        enemy.Enemy_state(enemy.Max_Enemy_HP,enemy.cur_Enemy_HP);
        card.Cur_Deck_state();
        
        PlayerTurn();
    }

    void Update() {
        character.Player_state();
        enemy.Enemy_state(enemy.Max_Enemy_HP,enemy.cur_Enemy_HP);
    }

    void PlayerTurn() {
        states = States.Player_Turn;
        if(character.barricade) {
            character.state.block = true;
        }
        else {
            character.state.block = false;
            character.cur_Player_Defense_cut = 0;
        }
        Turn_Count++;
        cur_Cost = 3;
        max_Cost = 3;
        if(maxCost_Up) {
            max_Cost++;
            cur_Cost = max_Cost;
        }


        if(Turn_Count == 1) { // 선천성 카드 로직 작성

        }
    }

    void TurnEnd() {
        states = States.Enemy_Turn;
        EnemyTurn();
    }

    void EnemyTurn() {
        if(enemy.state.block) {
            enemy.cur_Enemy_Defense_cut = 0;
            enemy.Act_Enemy(enemy_spawn);
        }
        else {
            enemy.Act_Enemy(enemy_spawn);
        }
        
        if(enemy.state.attack) {
            if(character.cur_Player_Defense_cut - enemy.damage >= 0) {
                character.cur_Player_Defense_cut -= enemy.damage;
            }
            else {
                character.cur_Player_HP -= (enemy.damage - character.cur_Player_Defense_cut);
            }

            if(enemy.state.block) {
                enemy.cur_Enemy_Defense_cut += enemy.state.GetDefense();
            }
        }
        else {
            if(enemy.state.block) {
                enemy.cur_Enemy_Defense_cut += enemy.state.GetDefense();
            } // 버프 효과 작성 (방어도, 힘 등)
            if (enemy.state.power) {
                // 힘 작성
            }
        }

        PlayerTurn();
    }

    void End() {
        states = States.End_Battle;
        // 맵 씬으로 이동하는 코드
    }

}
