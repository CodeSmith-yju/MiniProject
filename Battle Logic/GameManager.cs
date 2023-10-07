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
    private int cost;
    private int enemy_spawn = Random.Range(0, 1);

    protected enum States {
        Player_Turn, Enemy_Turn, End_Battle
    }
    
    private States states;
    

    void Awake() {
        Turn_Count = 0;
        character.Player_state();
        enemy.Spawn_Enemy(enemy_spawn);
        card.Cur_Deck_state();

        states = States.Player_Turn;
        PlayerTurn();
    }

    void PlayerTurn() {
        Turn_Count++;
        cost = 3; 
        if(Turn_Count == 1) { // 선천성 카드 로직 작성

        }
    }

    void TurnEnd() {
        states = States.Enemy_Turn;
    }

    void EnemyTurn() {
        enemy.Act_Enemy(enemy_spawn);
        if(enemy.state.attack) {
            character.cur_Player_HP -= enemy.damage;
            if(enemy.state.block) {
                enemy.cur_Enemy_HP += enemy.state.GetDefense();
            }
            return;
        }
        else {
            if(enemy.state.block) {
                enemy.cur_Enemy_HP += enemy.state.GetDefense();
            } // 버프 효과 작성 (방어도, 힘 등)
            if (enemy.state.power) {
                // 힘 작성
            }
        }
        return;

    }

    void End() {
        states = States.End_Battle;
    }

}
