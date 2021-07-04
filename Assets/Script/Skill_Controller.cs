using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Controller : MonoBehaviour
{
    public static GameObject weaponSkill;
    public static GameObject damageSkill;
    public static GameObject timeSkill;
    public static GameObject repeatSkill;

    public GameObject[] SkillsArray;

    UnOrderInt array = new UnOrderInt();

    private void Awake()
    {
        GameObject[] skills = GameObject.FindGameObjectsWithTag("Skill_Tag");
        EventSkillListener(skills);
        EventLeftSkillListener(skills);
    }
    public void EventSkillListener(GameObject[] skills)
    {
        foreach(GameObject skill in skills)
        {
            Skill _skill = skill.GetComponent<Skill>();
            _skill.Event_UseSkills(UseSkillListener);
        }
    }
    public void EventLeftSkillListener(GameObject[] skills)
    {
        foreach (GameObject skill in skills)
        {
            CoolDown _skill = skill.GetComponent<CoolDown>();
            _skill.Event_LeftSkill(LeftSkillListener);
        }
    }

    void UseSkillListener(GameObject skill)
    {
        if(skill.name == SkillsArray[0].name)
        {
            Debug.Log("Use Drop skill");
            array.Add(0);
            Event_Controller.current.Event_UseSkillDrop();
        }
        else if(skill.name == SkillsArray[1].name)
        {
            Debug.Log("Use Damage skill");
            array.Add(1);
            Event_Controller.current.Event_UseSkillDamage();
        }
        else if (skill.name == SkillsArray[2].name)
        {
            Debug.Log("Use Time skill");
            array.Add(2);
            Event_Controller.current.Event_UseSkillTime();
        }
        else if (skill.name == SkillsArray[3].name)
        {
            Debug.Log("Use Repeat skill");

            Debug.Log(array.ToString());
            int check = array.LastInIndex();
            if(check == 0)
            {
                Event_Controller.current.Event_UseSkillDrop();
                Event_Controller.current.Event_UseSkillRepeat();
            }
            if(check == 1)
            {
                Event_Controller.current.Event_UseSkillDamage();
                Event_Controller.current.Event_UseSkillRepeat();
            }
            if(check == 2)
            {
                Event_Controller.current.Event_UseSkillTime();
                Event_Controller.current.Event_UseSkillRepeat();
            }
        }
    }

    void LeftSkillListener(GameObject skill)
    {
        if (skill.name == SkillsArray[0].name)
        {
            Event_Controller.current.Event_LeftSkillDrop();
        }
        else if (skill.name == SkillsArray[1].name)
        {
            Event_Controller.current.Event_LeftSkillDamage();
        }
        else if (skill.name == SkillsArray[2].name)
        {
            Event_Controller.current.Event_LeftSkillTime();
        }
        else if (skill.name == SkillsArray[3].name)
        {
            Event_Controller.current.Event_LeftSkillRepeat();
        }
    }
}
