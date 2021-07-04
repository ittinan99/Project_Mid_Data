using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CoolDown : MonoBehaviour
{
    public Text thisNumText;
    float currentCount;
    float startCount = 10;
    UseSkill_Event _EventSkill = new UseSkill_Event();
    public CoolDown_Event _EventCoolDown = new CoolDown_Event();

    void Start()
    {
        thisNumText = this.GetComponent<Text>();

        currentCount = startCount;
    }
    public void Event_CoolDownSkill(UnityAction<float> listener)
    {
        _EventCoolDown.AddListener(listener);
    }
    public void Event_LeftSkill(UnityAction<GameObject> listener)
    {
        _EventSkill.AddListener(listener);
    }
    void Update()
    {
        currentCount -= 1 * Time.deltaTime;
        SetCountToText(currentCount.ToString());
        _EventCoolDown.Invoke(currentCount);
        if (currentCount < 0)
        {            
            currentCount = startCount;            
            this.gameObject.SetActive(false);

            _EventSkill.Invoke(this.gameObject);
        }
    }
    private void SetCountToText(string count)
    {
        thisNumText.text = count;
    }
}
