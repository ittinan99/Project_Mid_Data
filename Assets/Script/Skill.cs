using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public GameObject thisSkill;
    public Button Click;
    public UseSkill_Event _EventSkill = new UseSkill_Event();
    float currentTime;
    private void Awake()
    {
        thisSkill = this.GetComponent<GameObject>();
        Click = this.GetComponentInParent(typeof(Button)) as Button;
        CoolDown coolDown = GetComponent<CoolDown>();
        coolDown.Event_CoolDownSkill(Time);
        Click.onClick.AddListener(UseThisSkill);
    }
    public void Event_UseSkills(UnityAction<GameObject> listener)
    {
        _EventSkill.AddListener(listener);
    }
    public void UseThisSkill()
    {
        Debug.Log(currentTime);
        if (currentTime <= 0)
        {
            _EventSkill.Invoke(this.gameObject);
        }
    }
    public void Time(float coolDownTime)
    {
        currentTime = coolDownTime;       
    }
}
