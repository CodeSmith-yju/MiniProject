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
    [HideInInspector] private static int enemy_spawn;


    public Button turn_End;
    public Text max_Player_HP_Text;
    public Text cur_Player_HP_Text;
    public Text max_Enemy_HP_Text;
    public Text cur_Enemy_HP_Text;
    public Text max_Cost_Text;
    public Text cur_Cost_Text;
    public Text enemy_act;
    public Text turn_Count_text;
    public Text enemy_def;
    

    private enum State {
        Player_Turn, Enemy_Turn, End_Battle
    }
    
    private State state;
    

    void Awake() {
        turn_Count_text.text = Turn_Count.ToString();
        enemy_spawn = 0;
        character.Spawn_Player();
        enemy.Spawn_Enemy(enemy_spawn);
        // card.Cur_Deck_state();
        enemy_act.text = "";
        enemy_def.text = "";

        max_Player_HP_Text.text = character.max_Player_HP.ToString();
        cur_Player_HP_Text.text = character.cur_Player_HP.ToString();

        max_Enemy_HP_Text.text = enemy.max_Enemy_HP.ToString();
        cur_Enemy_HP_Text.text = enemy.cur_Enemy_HP.ToString();

        Debug.Log("게임 시작");
        PlayerTurn();
    }

    // void Start() {
    //     character.Player_state(character.max_Player_HP, character.cur_Player_HP);
    // }

    void Update() {
        if(state == State.Enemy_Turn) {
            character.Player_state(character.max_Player_HP, character.cur_Player_HP);
        }
        else if (state == State.Player_Turn) {
            enemy.Enemy_state(enemy.max_Enemy_HP,enemy.cur_Enemy_HP);
        }
        
        
        max_Player_HP_Text.text = character.max_Player_HP.ToString();
        cur_Player_HP_Text.text = character.cur_Player_HP.ToString();

        max_Enemy_HP_Text.text = enemy.max_Enemy_HP.ToString();
        cur_Enemy_HP_Text.text = enemy.cur_Enemy_HP.ToString();
    }

    void PlayerTurn() {
        Debug.Log("플레이어 턴");
        state = State.Player_Turn;
        if(character.barricade) {
            character.block = true;
        }
        else {
            character.block = false;
            character.cur_Player_Defense_cut = 0;
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
        turn_Count_text.text = Turn_Count.ToString();
        cur_Cost = 3;
        max_Cost = 3;
        if(character.Max_Cost_Relic) {
            max_Cost++;
            cur_Cost = max_Cost;
        }


        if(Turn_Count == 1) { // 선천성 카드 로직 작성

        }
        // 적 행동 보여주는 코드 작성
        enemy.Act_Enemy(enemy_spawn);
        if(enemy.attack) {
            if(enemy.block) {
                enemy_act.text = enemy.damaged.ToString() + ", " + "<color=#0017FF>" + enemy.GetDefense().ToString() + "</color>";
            }
            else {
                enemy_act.text = enemy.damaged.ToString();
            }
        }
        else if (enemy.block) {
            enemy_act.text = "<color=#0017FF>" + enemy.GetDefense().ToString() + "</color>";
        }
    }

    public void TurnEnd() {
        state = State.Enemy_Turn;
        Debug.Log("턴 종료");
        EnemyTurn();
    }

    void EnemyTurn() {
        Debug.Log("적 턴 시작");
        enemy.cur_Enemy_Defense_cut = 0;
        enemy_def.text = "";


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
            int damage_Val = enemy.damaged;
            int player_Def = character.cur_Player_Defense_cut;
            enemy_act.text = enemy.damaged.ToString();
            if(player_Def - damage_Val >= 0) {
                player_Def -= damage_Val;
            }
            else {
                character.cur_Player_HP -= damage_Val - player_Def;
            }

            if(enemy.block) {
                enemy.cur_Enemy_Defense_cut += enemy.GetDefense();
                enemy_def.text = enemy.cur_Enemy_Defense_cut.ToString();
            }
        }
        else { // 버프 효과 작성 (방어도, 힘 등)
            if(enemy.block) {
                enemy.cur_Enemy_Defense_cut += enemy.GetDefense();
                enemy_def.text = enemy.cur_Enemy_Defense_cut.ToString();
            } 
            if (enemy.power) {
                // 힘 작성
            }
        }

        PlayerTurn();
    }

    void End() {
        state = State.End_Battle;
        Debug.Log("전투 종료");

        // 맵 씬으로 이동하는 코드
    }

}
