using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExercise : MonoBehaviour
{
    public Slider playerHPSlider; //유니티 인스펙터창에서 슬라이더를 받을 변수
    public Text playerHPText; //유니티 인스펙터창에서 텍스트를 받을 변수
    
    public Slider enermyHPSlider;
    public Text enermyHPText;

    private float maxPlayerHP = 0f; //플레이어 최대 체력 초기화 유니티 인스펙터창에 나오면 안되므로 private
    private float curPlayerHP = 0f; //플레이어 현재 체력 초기화

    private float maxEnermyHP = 0f;
    private float curEnermyHP = 0f;

    //    private bool dropIsAttack = false;
    public DropZone Dz;

    public float damagePerKeyPress = 10f; //임의로 플레이어 체력을 줄일 변수


    private void Start()
    {
        HPSetting();
        Debug.Log("UpdateHPUI() 메서드 최초 호출");
        UpdateHPUI();

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A 입력");
            if (curPlayerHP > 0)
            {
                damagePerKeyPress = 5;
                curPlayerHP -= damagePerKeyPress;
                Debug.Log("플레이어 체력 감소");
                if (curPlayerHP <= 0)
                {
                    curPlayerHP = 0;
                    Debug.Log("플레이어 사망.");
                }
                UpdateHPUI();
            }
        }
        if (Dz.dropCheck == true)
        {
            if (curEnermyHP > 0)
            {
                damagePerKeyPress = 3;
                curEnermyHP -= damagePerKeyPress;
                Debug.Log("적 체력 감소");
                Dz.dropCheck = false;
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("적 캐릭터 사망.");
                }
                UpdateHPUI();
            }
        }
        
/*
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B 입력");
            if (curEnermyHP > 0)
            {
                damagePerKeyPress = 3;
                curEnermyHP -= damagePerKeyPress;
                Debug.Log("적 체력 감소");
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("적 캐릭터 사망.");
                }
                UpdateHPUI();
            }
        }
*/

    }

    public void UpdateHPUI()	//플레이어의 체력이 감소되면 슬라이더가 체력의비율에 맞춰 감소되고, 감소된 체력이 텍스트에 반영되게할 메서드
    {
        playerHPSlider.value = curPlayerHP / maxPlayerHP;
        playerHPText.text = $"{curPlayerHP}/{maxPlayerHP}";

        enermyHPSlider.value = curEnermyHP / maxEnermyHP;
        enermyHPText.text = $"{curEnermyHP}/{maxEnermyHP}";
    }

    public void HPSetting()	//플레이어의 체력을 초기화하여 첵스트창에 나타나게할 메서드
    {
        maxPlayerHP = 80f;
        maxEnermyHP = 15f;

        curEnermyHP = maxEnermyHP;
        curPlayerHP = maxPlayerHP;
        playerHPText.text = $"{curPlayerHP}/{maxPlayerHP}";
        enermyHPText.text = $"{curEnermyHP}/{maxEnermyHP}";
    }

    /*
    public void DropIsAttack() 
    {
        dropIsAttack = true;
        if (dropIsAttack)
        {
            if (curEnermyHP > 0)
            {
                damagePerKeyPress = 3;
                curEnermyHP -= damagePerKeyPress;
                Debug.Log("적 체력 감소");
                dropIsAttack = false;
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("적 캐릭터 사망.");
                }
                UpdateHPUI();
            }
        }
    }
    */
}
