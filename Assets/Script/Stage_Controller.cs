using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_Controller : MonoBehaviour
{
    int start_Stage;     
    int stage_Text_int;

    static Text stage_Text;

    public Spawn _spawn;
    public Inventory _inventory;
    public Level_Controller _level_Controller;
    public static bool reStage;

    Scene currentScene;

    private void Awake()
    {       
        _level_Controller = GameObject.Find("Level_Controller").GetComponent<Level_Controller>();
        _inventory = GameObject.Find("Weapon_Inventory").GetComponent<Inventory>();
        _spawn = GameObject.Find("Spawn").GetComponent<Spawn>();
        currentScene = SceneManager.GetActiveScene();
    }
    private void Start()
    {
        stage_Text = GameObject.Find("Stage_Text").GetComponent<Text>();
        SetStartStage();
        stage_Text.text = start_Stage.ToString();
        SetStage_int();       
    }
    private void SetStage_int()
    {
        stage_Text_int = int.Parse(stage_Text.text);
    }
    private void SetStage_int(int setStageTo)
    {
        stage_Text_int = setStageTo;
    }
    public void SetStage()
    {
        stage_Text.text = stage_Text_int.ToString();
        //Debug.Log(stage_Text_int);
    }
    public void NextStage()
    {
        SetStage_int();
        stage_Text_int = stage_Text_int + 1;
        SetStage();
        SaveCurrentStage(stage_Text_int);
    }
    public int GetThisStage()
    {
        stage_Text = GameObject.Find("Stage_Text").GetComponent<Text>();
        string stage = stage_Text.text;
        int stage_int = int.Parse(stage);
        return stage_int;
    }
    public void SetStartStage()
    {
        start_Stage = PlayerPrefs.GetInt("CurrentStage");
    }
    void SaveCurrentStage(int currentStage)
    {
        PlayerPrefs.SetInt("CurrentStage", currentStage);
        PlayerPrefs.Save();
    }
    public void ResetStage()
    {
        reStage = true;
        _level_Controller.GetExp(GetThisStage()*(GetThisStage()/0.5f) - 2);

        _spawn._attack.SaveStartDamage(0);
        _spawn._attack.SaveCritDamage(0);
        _spawn._attack.SaveAllDamage(0);
        _spawn._weapon.SetStartStatWeapon(1);
        _inventory.Save();
        _spawn.Set_StartTitanHealth(0);
        _spawn.Set_CountBoss(0);
        SceneManager.LoadScene(currentScene.name);
        _level_Controller.Set_LevelPointTo((int)PlayerPrefs.GetFloat("PlayerLevel"));

        stage_Text_int = Mathf.FloorToInt(GetThisStage()*0.25f);
        if(stage_Text_int == 0)
        {
            stage_Text_int = 1;
        }
        SetStage_int(stage_Text_int);
        SetStage();
        PlayerPrefs.SetInt("CurrentStage", stage_Text_int);
        PlayerPrefs.Save();
    }
    public void ResetStage(int everything)
    {
        reStage = true;
        _level_Controller.Set_CurrentLevel(1);
        _level_Controller.Set_LevelPointTo(1);
        _level_Controller.Set_CurrentExp(0);
        _inventory.SetJsonTo("");
        _spawn._attack.SaveStartDamage(0);
        _spawn._attack.SaveCritDamage(0);
        _spawn._attack.SaveAllDamage(0);
        _spawn._weapon.SetStartStatWeapon(1);

        stage_Text_int = everything;
        if (stage_Text_int == 0)
        {
            stage_Text_int = 1;
        }
        SetStage_int(stage_Text_int);
        SetStage();
        PlayerPrefs.SetInt("CurrentStage", stage_Text_int);
        PlayerPrefs.Save();

        SceneManager.LoadScene(currentScene.name);
    }
    public void ResetSave()
    {
        _spawn.Set_StartTitanHealth(0);
        _spawn.Set_CountBoss(0);
        ResetStage(0);
    }
}
