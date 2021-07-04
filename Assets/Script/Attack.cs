using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class Attack : MonoBehaviour
{
    public Spawn _spawn;
    public Weapon _weapon;
    public GameObject health_Fill;
    public Animator titan_Ghost;
    public static float health_Value;
    float startdamage;
    float critdamage;
    float finaldamage;
    float damage = 1;
    bool crit = false;
    bool skillDamage = false;

    public Dictionary<string, Weapon_GetData> _weapon_Dic = new Dictionary<string, Weapon_GetData>();

    private void Awake()
    {
        ReadData();

        _weapon = GameObject.Find("Weapon_Controller").GetComponent<Weapon>();
        _spawn = GameObject.Find("Spawn").GetComponent<Spawn>();
    }
    public void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";

        try
        {
            input = File.OpenText(Path.Combine(path, "WeaponStatSetUp.csv"));

            string name = input.ReadLine();
            string value = input.ReadLine();
            while(value != null)
            {
                AssignData(value);
                value = input.ReadLine();
            }
        }
        catch(Exception ex) { Debug.Log(ex.Message); }

        finally { if (input != null) input.Close(); }
    }

    void AssignData(string value)
    {
        string[] data = value.Split(',');
        int no = int.Parse(data[0]);
        string weaponName = data[1];
        float tapMultiply = float.Parse(data[2]);
        float criticalMultiply = float.Parse(data[3]);
        float criticalChange = float.Parse(data[4]);
        float allDamageMultiply = float.Parse(data[5]);
        float skillMultiply = float.Parse(data[6]);

        Weapon_GetData _weapon = new Weapon_GetData(tapMultiply, criticalMultiply, criticalChange, allDamageMultiply, skillMultiply);
        _weapon_Dic.Add(weaponName, _weapon);
    }

    private void Start()
    {
        SetStartDamage();
        SetCritDamage();
        SetAllDamage();
        DamageCalculate(Weapon.tapDamage, Weapon.criticalDamage, Weapon.allDamage, Weapon.skillDamage);

        Event_Controller.current.onEvent_UseSkillDamage += UseSkill;
        Event_Controller.current.onEvent_LeftSkillDamage += LeftSkill;
    }

    void LeftSkill()
    {
        skillDamage = false;
    }

    void UseSkill()
    {
        skillDamage = true;
    }

    public void GetHealthFill_Value(float Get_Value)
    {
        health_Value = Get_Value;
    }
    public void SetValue_ToFill()
    {
        health_Fill.GetComponent<Slider>().value = health_Value;
    }
    public void AttackTitan()
    {
        titan_Ghost = GameObject.FindGameObjectWithTag("Titan_Tag").GetComponent<Animator>();
        if (_spawn.current_Titan.name == "Titan_Ghost(Clone)")
        {
            titan_Ghost.SetTrigger("GetHit");
        }
        if (_spawn.current_Titan.name == "Titan_Blue(Clone)")
        {
            titan_Ghost.SetTrigger("GetHit");
        }
        if (_spawn.current_Titan.name == "Titan_Green(Clone)")
        {
            titan_Ghost.SetTrigger("GetHit");
        }


        crit = CheckCrit(Weapon.criticalChange);
        DamageCalculate(Weapon.tapDamage, Weapon.criticalDamage, Weapon.allDamage, Weapon.skillDamage);

        Debug.Log("Damage = " + damage);
        health_Value = health_Value - damage;
        SetValue_ToFill();
    }
    public float DamageCalculate(float tapMultiply, float critMultiply, float allDamageMultiply, float skillMultiply)
    {
        damage = startdamage * tapMultiply * allDamageMultiply * finaldamage;
        
        if(crit == true)
        {
            damage = damage * critMultiply * critdamage;
            crit = false;
        }
        if(skillDamage == true)
        {
            damage = damage * skillMultiply;
        }
        return damage;
    }
    public bool CheckCrit(float critChange)
    {
        float rand = UnityEngine.Random.Range(1f, 100f);
        if (rand < critChange)
        {
            crit = true; 
        }
        return crit;
    }
    public void UpdateStatButton()
    {
        _weapon.Set_WeaponText();
    }
    public void UpgradeTapDamage()
    {
        if(Level_Controller.levelPoint > 0)
        {
            startdamage++;
            Level_Controller.levelPoint--;
            _weapon._inventory._level_Controller.Set_LevelPointTo(Level_Controller.levelPoint);
            _weapon._inventory._level_Controller.Set_LevelPointText();
        }
        Debug.Log(startdamage);
        SaveStartDamage(startdamage);
        DamageCalculate(Weapon.tapDamage, Weapon.criticalDamage, Weapon.allDamage, Weapon.skillDamage);
    }
    public void UpgradeCritDamage()
    {
        if (Level_Controller.levelPoint > 0)
        {
            critdamage++;
            Level_Controller.levelPoint--;
            _weapon._inventory._level_Controller.Set_LevelPointTo(Level_Controller.levelPoint);
            _weapon._inventory._level_Controller.Set_LevelPointText();
        }
        Debug.Log(critdamage);
        SaveCritDamage(critdamage);
        DamageCalculate(Weapon.tapDamage, Weapon.criticalDamage, Weapon.allDamage, Weapon.skillDamage);
    }
    public void UpgradeFinalDamage()
    {
        if (Level_Controller.levelPoint > 0)
        {
            finaldamage++;
            Level_Controller.levelPoint--;
            _weapon._inventory._level_Controller.Set_LevelPointTo(Level_Controller.levelPoint);
            _weapon._inventory._level_Controller.Set_LevelPointText();
        }
        Debug.Log(finaldamage);
        SaveAllDamage(finaldamage);
        DamageCalculate(Weapon.tapDamage, Weapon.criticalDamage, Weapon.allDamage, Weapon.skillDamage);
    }
    public void SetStartDamage()
    {
        if(PlayerPrefs.GetFloat("startDamage") == 0)
        {
            startdamage = 1;
        }
        else
        {
            startdamage = PlayerPrefs.GetFloat("startDamage");
        }
    }
    public void SaveStartDamage(float startdamage)
    {
        PlayerPrefs.SetFloat("startDamage", startdamage);
        PlayerPrefs.Save();
    }
    public void SetCritDamage()
    {
        if (PlayerPrefs.GetFloat("critDamage") == 0)
        {
            critdamage = 1;
        }
        else
        {
            critdamage = PlayerPrefs.GetFloat("critDamage");
        }
    }
    public void SaveCritDamage(float critdamage)
    {
        PlayerPrefs.SetFloat("critDamage", critdamage);
        PlayerPrefs.Save();
    }
    public void SetAllDamage()
    {
        if (PlayerPrefs.GetFloat("allDamage") == 0)
        {
            finaldamage = 1;
        }
        else
        {
            finaldamage = PlayerPrefs.GetFloat("allDamage");
        }
    }
    public void SaveAllDamage(float alldamage)
    {
        PlayerPrefs.SetFloat("allDamage", alldamage);
        PlayerPrefs.Save();
    }
}
