using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    
    [HideInInspector] public static int Turn_Count;
    public Character character;
    public Enemy enemy;
    // public Card card;
    [HideInInspector] private int cur_Cost;
    [HideInInspector] private int max_Cost;
    [HideInInspector] private int enemy_spawn;


    public Button turn_End;
    public Text max_Player_HP_Text;
    public Text cur_Player_HP_Text;
    public Text max_Enemy_HP_Text;
    public Text cur_Enemy_HP_Text;
    public Text max_Cost_Text;
    public Text cur_Cost_Text;
    

    private enum State {
        Player_Turn, Enemy_Turn, End_Battle
    }
    
    private State state;
    

    void Awake() {
        Turn_Count = 0;
        enemy_spawn = Random.Range(0, 1);
        character.Player_state();
        enemy.Spawn_Enemy(enemy_spawn);

        enemy.Enemy_state(enemy.max_Enemy_HP,enemy.cur_Enemy_HP);
        // card.Cur_Deck_state();

        max_Player_HP_Text.text = character.max_Player_HP.ToString();
        cur_Player_HP_Text.text = character.cur_Player_HP.ToString();

        max_Enemy_HP_Text.text = enemy.max_Enemy_HP.ToString();
        cur_Enemy_HP_Text.text = enemy.cur_Enemy_HP.ToString();

        PlayerTurn();
    }

    void Update() {
        character.Player_state();
        enemy.Enemy_state(enemy.max_Enemy_HP,enemy.cur_Enemy_HP);

        max_Player_HP_Text.text = character.max_Player_HP.ToString();
        cur_Player_HP_Text.text = character.cur_Player_HP.ToString();

        max_Enemy_HP_Text.text = enemy.max_Enemy_HP.ToString();
        cur_Enemy_HP_Text.text = enemy.cur_Enemy_HP.ToString();
    }

    void PlayerTurn() {
        state = State.Player_Turn;
        if(character.barricade) {
            character.block = true;
        }
        else {
            character.block = false;
            character.cur_Player_Defense_cut = 0;
        }

        if(character.power) {
            character.power_Duration--;

            if(character.power_Duration == 0) {
                character.power = false;
            }
        }

        if(character.weak) {
            character.weak_Duration--;

            if(character.power_Duration == 0) {
                character.weak = false;
            }
        }

        if(character.injury) {
            character.injury_Duration--;

            if(character.injury_Duration == 0) {
                character.injury = false;
            }
        }

        Turn_Count++;
        cur_Cost = 3;
        max_Cost = 3;
        if(character.Max_Cost_Relic) {
            max_Cost++;
            cur_Cost = max_Cost;
        }


        if(Turn_Count == 1) { // 선천성 카드 로직 작성

        }
    }

    public void TurnEnd() {
        state = State.Enemy_Turn;
        EnemyTurn();
    }

    void EnemyTurn() {
        if(enemy.block) {
            enemy.cur_Enemy_Defense_cut = 0;
            enemy.Act_Enemy(enemy_spawn);
        }
        else {
            enemy.Act_Enemy(enemy_spawn);
        }

        if(enemy.power) {
            enemy.power_Duration--;

            if(enemy.power_Duration == 0) {
                enemy.power = false;
            }
        }

        if(enemy.weak) {
            enemy.weak_Duration--;

            if(enemy.power_Duration == 0) {
                enemy.weak = false;
            }
        }

        if(enemy.injury) {
            enemy.injury_Duration--;

            if(enemy.injury_Duration == 0) {
                enemy.injury = false;
            }
        }

        
        if(enemy.attack) {
            if(character.cur_Player_Defense_cut - enemy.damage >= 0) {
                character.cur_Player_Defense_cut -= enemy.damage;
            }
            else {
                character.cur_Player_HP -= (enemy.damage - character.cur_Player_Defense_cut);
            }

            if(enemy.block) {
                enemy.cur_Enemy_Defense_cut += enemy.GetDefense();
            }
        }
        else { // 버프 효과 작성 (방어도, 힘 등)
            if(enemy.block) {
                enemy.cur_Enemy_Defense_cut += enemy.GetDefense();
            } 
            if (enemy.power) {
                // 힘 작성
            }
        }

        PlayerTurn();
    }

    void End() {
        state = State.End_Battle;
        // 맵 씬으로 이동하는 코드
    }

}
