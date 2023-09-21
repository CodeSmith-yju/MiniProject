using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        start, player_Turn, enemy_Turn, win
    }

    public State state;
    public Text turnText;
    public Text playerHP_Text;
    public Text enemyHP_Text;
    public Text cost_Text;
    public int playerHP;
    public int enemyHP;
    public Button btn;
    public int cost;


    

    void Awake()
    {
        playerHP = 10;
        enemyHP = 10;
        state = State.start;
        playerHP_Text.text = "플레이어 체력 : " + playerHP;
        enemyHP_Text.text = "적 체력 : " + enemyHP;
        BattleStart();
    }

    void BattleStart()
    {
        turnText.text = "플레이어 턴";
        state = State.player_Turn;
        PlayerTurn();
    }

    void PlayerTurn() {
        cost = 3;
        cost_Text.text = cost + "/" + "3";
    }



    public void PlayerAttackButton()
    {
        cost--;
        cost_Text.text = cost + "/" + "3";
        StartCoroutine(PlayerAttack());

        if (cost <= 0)
        {
            btn.interactable = false;
            return;
        }
        
    }
    
    public void ResetButton() {
        Awake();
    }

    public void TurnQuit() {
        EnemyTurn();
    }


    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("플레이어 공격");
        enemyHP--;
        enemyHP_Text.text = "적 체력 : " + enemyHP;

        if(enemyHP <= 0)
        {
            state = State.win;
            turnText.text = "승리";
            EndBattle();
        }
    }

    void EndBattle()
    {
        Debug.Log("전투 종료");
    }

    void EnemyTurn() {
        state = State.enemy_Turn;
        turnText.text = "적의 턴";
        StartCoroutine(EnemyAttack());
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("적 공격");
        playerHP--;
        playerHP_Text.text = "플레이어 체력 : " + playerHP;

        if(playerHP <= 0) {
            EndBattle();
        }
        else {
            state = State.player_Turn;
            turnText.text = "플레이어 턴";
            btn.interactable = true;
            PlayerTurn();
        }
    }

}
