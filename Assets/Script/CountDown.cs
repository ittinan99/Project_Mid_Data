using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text thisNumText;
    float currentCount;
    float startCount = 10;
    bool skillTime = false;
    void Start()
    {
        thisNumText = this.GetComponent<Text>();

        Event_Controller.current.onEvent_Boss += BossSpawn;
        Event_Controller.current.onEvent_UseSkillTime += UseSkill;
        Event_Controller.current.onEvent_LeftSkillTime += LeftSkill;

        SetStartCountDown();
    }

    void BossSpawn()
    {
        currentCount = 10;
    }
    void LeftSkill()
    {
        skillTime = false;
    }
    void UseSkill()
    {
        skillTime = true;
        SetStartCountDown();
    }
    private void SetStartCountDown()
    {
        if (skillTime == true)
        {
            startCount = startCount * Weapon.skillDamage;
        }
        currentCount = startCount;
    }

    void Update()
    {
        currentCount -= 1 * Time.deltaTime;
        SetCountToText(currentCount.ToString());

        if(currentCount <= 0)
        {
            Event_Controller.current.Event_LostWithBoss();

            currentCount = startCount;
            this.gameObject.SetActive(false);
        }
    }

    private void SetCountToText(string count)
    {
        thisNumText.text = count;
    }
}
