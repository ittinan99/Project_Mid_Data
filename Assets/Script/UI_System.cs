using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_System : MonoBehaviour
{
    public GameObject bossText;
    public GameObject countDownText;
    public GameObject spawnCountDownText;
    public GameObject[] coolDownSkills;

    private void Awake()
    {
        bossText = GameObject.Find("BossTextBG");
        countDownText = GameObject.Find("CountDown");
        spawnCountDownText = GameObject.Find("SpawnCountDownText");
        coolDownSkills = GameObject.FindGameObjectsWithTag("Skill_Tag");
    }
    public void Start()
    {
        Event_Controller.current.onEvent_Boss += ShowBossText;
        Event_Controller.current.onEvent_Boss += BossFight;
        Event_Controller.current.onEvent_Normal += CloseBossText;
        Event_Controller.current.onEvent_WinWithBoss += WinBoss;
        Event_Controller.current.onEvent_UseSkillDrop += ShowTimeSkillDrop;
        Event_Controller.current.onEvent_UseSkillDamage += ShowTimeSkillDamage;
        Event_Controller.current.onEvent_UseSkillTime += ShowTimeSkillTime;
        Event_Controller.current.onEvent_UseSkillRepeat += ShowTimeSkillRepeat;
        foreach(GameObject coolDownSkill in coolDownSkills)
        {
            coolDownSkill.gameObject.SetActive(false);
        }

        bossText.gameObject.SetActive(false);
        countDownText.gameObject.SetActive(false);
    }

    private void ShowBossText()
    {
        bossText.gameObject.SetActive(true);
    }
    private void CloseBossText()
    {
        bossText.gameObject.SetActive(false);
    }
    private void BossFight()
    {
        countDownText.gameObject.SetActive(true);
    }
    private void WinBoss()
    {
        countDownText.gameObject.SetActive(false);
    }
    private void ShowTimeSkillDrop()
    {
        coolDownSkills[0].gameObject.SetActive(true);
    }
    private void ShowTimeSkillDamage()
    {
        coolDownSkills[1].gameObject.SetActive(true);
    }
    private void ShowTimeSkillTime()
    {
        coolDownSkills[2].gameObject.SetActive(true);
    }
    private void ShowTimeSkillRepeat()
    {
        coolDownSkills[3].gameObject.SetActive(true);
    }
}
