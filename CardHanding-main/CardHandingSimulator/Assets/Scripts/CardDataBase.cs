using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<CardInit> cardList = new List<CardInit>();
    
    void Awake()
    {
        cardList.Add(new CardInit(0, "타격", 1, "피해를 5 줍니다."));
        cardList.Add(new CardInit(1, "수비", 1, "방어도 5를 얻습니다."));
        cardList.Add(new CardInit(2, "강타", 2, "적에게 피해를 8 주고 약화를 2 부여합니다."));
        cardList.Add(new CardInit(3, "폼멜타격", 1, "피해를 9 줍니다. 카드를 1장 뽑습니다."));
        cardList.Add(new CardInit(4, "이중타격", 1, "5의 피해를 2번 줍니다."));
    }
}
