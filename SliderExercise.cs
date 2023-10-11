using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExercise : MonoBehaviour
{
    public Slider playerHPSlider; //����Ƽ �ν�����â���� �����̴��� ���� ����
    public Text playerHPText; //����Ƽ �ν�����â���� �ؽ�Ʈ�� ���� ����
    
    public Slider enermyHPSlider;
    public Text enermyHPText;

    private float maxPlayerHP = 0f; //�÷��̾� �ִ� ü�� �ʱ�ȭ ����Ƽ �ν�����â�� ������ �ȵǹǷ� private
    private float curPlayerHP = 0f; //�÷��̾� ���� ü�� �ʱ�ȭ

    private float maxEnermyHP = 0f;
    private float curEnermyHP = 0f;

    //    private bool dropIsAttack = false;
    public DropZone Dz;

    public float damagePerKeyPress = 10f; //���Ƿ� �÷��̾� ü���� ���� ����


    private void Start()
    {
        HPSetting();
        Debug.Log("UpdateHPUI() �޼��� ���� ȣ��");
        UpdateHPUI();

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A �Է�");
            if (curPlayerHP > 0)
            {
                damagePerKeyPress = 5;
                curPlayerHP -= damagePerKeyPress;
                Debug.Log("�÷��̾� ü�� ����");
                if (curPlayerHP <= 0)
                {
                    curPlayerHP = 0;
                    Debug.Log("�÷��̾� ���.");
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
                Debug.Log("�� ü�� ����");
                Dz.dropCheck = false;
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("�� ĳ���� ���.");
                }
                UpdateHPUI();
            }
        }
        
/*
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B �Է�");
            if (curEnermyHP > 0)
            {
                damagePerKeyPress = 3;
                curEnermyHP -= damagePerKeyPress;
                Debug.Log("�� ü�� ����");
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("�� ĳ���� ���.");
                }
                UpdateHPUI();
            }
        }
*/

    }

    public void UpdateHPUI()	//�÷��̾��� ü���� ���ҵǸ� �����̴��� ü���Ǻ����� ���� ���ҵǰ�, ���ҵ� ü���� �ؽ�Ʈ�� �ݿ��ǰ��� �޼���
    {
        playerHPSlider.value = curPlayerHP / maxPlayerHP;
        playerHPText.text = $"{curPlayerHP}/{maxPlayerHP}";

        enermyHPSlider.value = curEnermyHP / maxEnermyHP;
        enermyHPText.text = $"{curEnermyHP}/{maxEnermyHP}";
    }

    public void HPSetting()	//�÷��̾��� ü���� �ʱ�ȭ�Ͽ� ý��Ʈâ�� ��Ÿ������ �޼���
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
                Debug.Log("�� ü�� ����");
                dropIsAttack = false;
                if (curEnermyHP <= 0)
                {
                    curEnermyHP = 0;
                    Debug.Log("�� ĳ���� ���.");
                }
                UpdateHPUI();
            }
        }
    }
    */
}
