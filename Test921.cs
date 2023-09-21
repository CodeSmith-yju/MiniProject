using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //체력 변수 지정하기
    int HP_enemy;
    int HP_player;
    int cost;

    //적 체력을 화면에 표시해줄 Text
    public Text ScoreHP_enemy;
    public Text ScoreHP_player;


    //시작하거나 리셋버튼 누르면 실행되는 어웨이크
    void Awake()
    {
        HP_enemy = 10;
        HP_player = 10;
        BattleStart();
    }

    public void Reset()
    {
        Awake();
    }

    //배틀 시작 버튼
    void BattleStart()
    {
        //시작과 동시에 내 체력, 적 체력 표시
        ScoreHP_enemy.text = string.Format($"적 체력 : {HP_enemy}");
        ScoreHP_player.text = string.Format($"내 체력 : {HP_player}");
        
        Debug.Log("전투 시작");
        Debug.Log("내 턴");
    }



    //공격 버튼
    public void PlayerAttackButton()
    {
        HP_enemy --;
        Debug.Log("플레이어 공격");
        //줄어든 체력 반영
        ScoreHP_enemy.text = string.Format($"적 체력 : {HP_enemy}");

        if(HP_enemy == 0)
        {
            Debug.Log("적 처치 성공");
            WinBattle();
        }
    }

    public void Turn_fin()
    {
        Debug.Log("적 턴");
        HP_player --;
        Debug.Log("적이 공격함");
        //줄어든 체력 반영
        ScoreHP_player.text = string.Format($"내 체력 : {HP_player}");
        if(HP_player == 0)
        {
            Debug.Log("캐릭터 사망");
            LoseBattle();
        }
        else
        {
            Debug.Log("내 턴");
        }
        
    }

    void WinBattle()
    {
        Debug.Log("전투 승리");
        
    }

    void LoseBattle()
    {
        Debug.Log("전투 패배");
        
    }

}
