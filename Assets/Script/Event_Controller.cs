using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Event_Controller : MonoBehaviour
{
    public static Event_Controller current;
    private void Awake()
    {
        current = this;
    }

    public event Action onEvent_LeftSkillDrop;
    public void Event_LeftSkillDrop()
    {
        if (onEvent_LeftSkillDrop != null)
        {
            onEvent_LeftSkillDrop();
        }
    }

    public event Action onEvent_LeftSkillDamage;
    public void Event_LeftSkillDamage()
    {
        if (onEvent_LeftSkillDamage != null)
        {
            onEvent_LeftSkillDamage();
        }
    }

    public event Action onEvent_LeftSkillTime;
    public void Event_LeftSkillTime()
    {
        if (onEvent_LeftSkillTime != null)
        {
            onEvent_LeftSkillTime();
        }
    }

    public event Action onEvent_LeftSkillRepeat;
    public void Event_LeftSkillRepeat()
    {
        if (onEvent_LeftSkillRepeat != null)
        {
            onEvent_LeftSkillRepeat();
        }
    }

    public event Action onEvent_UseSkillDrop;
    public void Event_UseSkillDrop()
    {
        if (onEvent_UseSkillDrop != null)
        {
            onEvent_UseSkillDrop();
        }
    }

    public event Action onEvent_UseSkillDamage;
    public void Event_UseSkillDamage()
    {
        if (onEvent_UseSkillDamage != null)
        {
            onEvent_UseSkillDamage();
        }
    }

    public event Action onEvent_UseSkillTime;
    public void Event_UseSkillTime()
    {
        if (onEvent_UseSkillTime != null)
        {
            onEvent_UseSkillTime();
        }
    }

    public event Action onEvent_UseSkillRepeat;
    public void Event_UseSkillRepeat()
    {
        if (onEvent_UseSkillRepeat != null)
        {
            onEvent_UseSkillRepeat();
        }
    }

    public event Action onEvent_Boss;
    public void Event_Boss()
    {
        if(onEvent_Boss != null)
        {
            onEvent_Boss();
        }
    }

    public event Action onEvent_Normal;
    public void Event_Normal()
    {
        if (onEvent_Normal != null)
        {
            onEvent_Normal();
        }
    }

    public event Action onEvent_LostWithBoss;
    public void Event_LostWithBoss()
    {
        if (onEvent_LostWithBoss != null)
        {
            onEvent_LostWithBoss();
        }
    }

    public event Action onEvent_WinWithBoss;
    public void Event_WinWithBoss()
    {
        if (onEvent_WinWithBoss != null)
        {
            onEvent_WinWithBoss();
        }
    }   
}
