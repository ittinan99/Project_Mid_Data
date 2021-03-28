using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Inventory : MonoBehaviour
{
    public Text weapon_Normal_Count;
    public Text weapon_Tap_Count;
    public Text weapon_Crit_Count;
    public Text weapon_All_Count;
    public Text weapon_Skill_Count;

    public Level_GetData _levelData;
    public Level_Controller _level_Controller;
    public Weapon _weapon;

    public Text current_LevelNormal;
    public Text current_LevelTap;
    public Text current_LevelCrit;
    public Text current_LevelAll;
    public Text current_LevelSkill;

    string json;

    private void Awake()
    {
        CreateJson();
        LoadJson();
        _level_Controller = GameObject.Find("Level_Controller").GetComponent<Level_Controller>();
        _weapon = GameObject.Find("Weapon_Controller").GetComponent<Weapon>();
    }
    void CreateJson()
    {
        if (PlayerPrefs.GetString("json_Data") != "")
        {
            LoadJson();
        }
        else
        {
            Level_GetData _levelData = new Level_GetData();
            _levelData.weapon_Normal_level = 1;
            _levelData.weapon_Normal_Count = 0;
            _levelData.weapon_Tap_level = 1;
            _levelData.weapon_Tap_Count = 0;
            _levelData.weapon_Crit_level = 1;
            _levelData.weapon_Crit_Count = 0;
            _levelData.weapon_All_level = 1;
            _levelData.weapon_All_Count = 0;
            _levelData.weapon_Skill_level = 1;
            _levelData.weapon_Skill_Count = 0;

            json = JsonUtility.ToJson(_levelData);
            PlayerPrefs.SetString("json_Data", json);
            File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/WeaponConf.json", PlayerPrefs.GetString("json_Data"));
        }
    }
    public void Save()
    {
        Level_GetData _levelData = new Level_GetData();
        _levelData.weapon_Normal_level = int.Parse(current_LevelNormal.text);
        _levelData.weapon_Normal_Count = int.Parse(weapon_Normal_Count.text);
        _levelData.weapon_Tap_level = int.Parse(current_LevelTap.text);
        _levelData.weapon_Tap_Count = int.Parse(weapon_Tap_Count.text);
        _levelData.weapon_Crit_level = int.Parse(current_LevelCrit.text);
        _levelData.weapon_Crit_Count = int.Parse(weapon_Crit_Count.text);
        _levelData.weapon_All_level = int.Parse(current_LevelAll.text);
        _levelData.weapon_All_Count = int.Parse(weapon_All_Count.text);
        _levelData.weapon_Skill_level = int.Parse(current_LevelSkill.text);
        _levelData.weapon_Skill_Count = int.Parse(weapon_Skill_Count.text);
        json = JsonUtility.ToJson(_levelData);
        PlayerPrefs.SetString("json_Data", json);
        File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/WeaponConf.json", PlayerPrefs.GetString("json_Data"));
        PlayerPrefs.Save();
    }
    void LoadJson()
    {
        string jsonFormFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/WeaponConf.json");
        Level_GetData _levelData = JsonUtility.FromJson<Level_GetData>(PlayerPrefs.GetString("json_Data"));

        current_LevelNormal.text = _levelData.weapon_Normal_level.ToString(); ;
        weapon_Normal_Count.text = _levelData.weapon_Normal_Count.ToString();

        current_LevelTap.text = _levelData.weapon_Tap_level.ToString();
        weapon_Tap_Count.text = _levelData.weapon_Tap_Count.ToString();

        current_LevelCrit.text = _levelData.weapon_Crit_level.ToString();
        weapon_Crit_Count.text = _levelData.weapon_Crit_Count.ToString();

        current_LevelAll.text = _levelData.weapon_All_level.ToString();
        weapon_All_Count.text = _levelData.weapon_All_Count.ToString();

        current_LevelSkill.text = _levelData.weapon_Skill_level.ToString();
        weapon_Skill_Count.text = _levelData.weapon_Skill_Count.ToString();
    }
    public void SetJsonTo(string json)
    {
        PlayerPrefs.SetString("json_Data", json);
        PlayerPrefs.Save();
    }
    public void Add_WeaponToInventory(GameObject weaponName)
    {
        if(weaponName.name == "Sword_Normal(Clone)")
        {
            int weapon_Count = int.Parse(weapon_Normal_Count.text);
            weapon_Count++;
            weapon_Normal_Count.text = weapon_Count.ToString();
        }
        if(weaponName.name == "Sword_Crit(Clone)")
        {
            int weapon_Count = int.Parse(weapon_Crit_Count.text);
            weapon_Count++;
            weapon_Crit_Count.text = weapon_Count.ToString();
        }
        if (weaponName.name == "Sword_Tap(Clone)")
        {
            int weapon_Count = int.Parse(weapon_Tap_Count.text);
            weapon_Count++;
            weapon_Tap_Count.text = weapon_Count.ToString();
        }
        if (weaponName.name == "Sword_All(Clone)")
        {
            int weapon_Count = int.Parse(weapon_All_Count.text);
            weapon_Count++;
            weapon_All_Count.text = weapon_Count.ToString();
        }
        if (weaponName.name == "Sword_Skill(Clone)")
        {
            int weapon_Count = int.Parse(weapon_Skill_Count.text);
            weapon_Count++;
            weapon_Skill_Count.text = weapon_Count.ToString();
        }
        Destroy(weaponName);
    }
    public void UpgradeNormalWeapon()
    {
        int this_Weapon_Count = int.Parse(weapon_Normal_Count.text);
        int this_Weapon_Level = int.Parse(current_LevelNormal.text);
        if (this_Weapon_Count >= 5)
        {
            this_Weapon_Count = this_Weapon_Count - 5;
            weapon_Normal_Count.text = this_Weapon_Count.ToString();
            this_Weapon_Level++;
            current_LevelNormal.text = this_Weapon_Level.ToString();

            _weapon.Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text), 
                int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
    public void UpgradeTapWeapon()
    {
        int this_Weapon_Count = int.Parse(weapon_Tap_Count.text);
        int this_Weapon_Level = int.Parse(current_LevelTap.text);
        if (this_Weapon_Count >= 5)
        {
            this_Weapon_Count = this_Weapon_Count - 5;
            weapon_Tap_Count.text = this_Weapon_Count.ToString();
            this_Weapon_Level++;

            current_LevelTap.text = this_Weapon_Level.ToString();
            _weapon.Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
    int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
    public void UpgradeCritWeapon()
    {
        int this_Weapon_Count = int.Parse(weapon_Crit_Count.text);
        int this_Weapon_Level = int.Parse(current_LevelCrit.text);
        if (this_Weapon_Count >= 5)
        {
            this_Weapon_Count = this_Weapon_Count - 5;
            weapon_Crit_Count.text = this_Weapon_Count.ToString();
            this_Weapon_Level++;

            current_LevelCrit.text = this_Weapon_Level.ToString();
            _weapon.Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
    int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
    public void UpgradeAllWeapon()
    {
        int this_Weapon_Count = int.Parse(weapon_All_Count.text);
        int this_Weapon_Level = int.Parse(current_LevelAll.text);
        if (this_Weapon_Count >= 5)
        {
            this_Weapon_Count = this_Weapon_Count - 5;
            weapon_All_Count.text = this_Weapon_Count.ToString();
            this_Weapon_Level++;

            current_LevelAll.text = this_Weapon_Level.ToString();
            _weapon.Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
    int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
    public void UpgradeSkillWeapon()
    {
        int this_Weapon_Count = int.Parse(weapon_Skill_Count.text);
        int this_Weapon_Level = int.Parse(current_LevelSkill.text);
        if (this_Weapon_Count >= 5)
        {
            this_Weapon_Count = this_Weapon_Count - 5;
            weapon_Skill_Count.text = this_Weapon_Count.ToString();
            this_Weapon_Level++;

            current_LevelSkill.text = this_Weapon_Level.ToString();
            _weapon.Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
    int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
}

