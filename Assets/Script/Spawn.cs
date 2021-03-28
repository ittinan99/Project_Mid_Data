using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : Level_Controller
{   
    public GameObject current_Titan;
    public GameObject spawn;
    public GameObject prefab_titan;
    public GameObject health_Fill;

    public Weapon _weapon;
    public Stage_Controller _stage;
    public Titan_Controller _titan;
    public Attack _attack;
    
    public GameObject[] titan_GameObject;

    float fullHealth;
    float count_Boss;
    float forCalculate;

    public void Set_StartTitanHealth()
    {
        if(PlayerPrefs.GetFloat("titanHealth") == 0)
        {
            PlayerPrefs.SetFloat("titanHealth", 15);
        }
        //Attack.health_Value = 15;
        Attack.health_Value = PlayerPrefs.GetFloat("titanHealth");
        PlayerPrefs.SetFloat("titanHealth", Attack.health_Value);
        
        PlayerPrefs.Save();

    }
    public void Set_StartTitanHealth(float new_fullHealth)
    {
        PlayerPrefs.SetFloat("titanHealth", new_fullHealth);
        PlayerPrefs.Save();
    }
    public void Set_CountBoss(float new_countBoss)
    {
        PlayerPrefs.SetFloat("countBoss", new_countBoss);
        PlayerPrefs.Save();
    }
    public void Set_CountBoss()
    {
        if (PlayerPrefs.GetFloat("countBoss") == 0)
        {
            PlayerPrefs.SetFloat("countBoss", 1);
        }
        count_Boss = PlayerPrefs.GetFloat("countBoss");
        PlayerPrefs.SetFloat("countBoss", count_Boss);
        PlayerPrefs.Save();
    }
    public void SpawnTitan()
    {
        Set_StartTitanHealth();
        Set_CountBoss();

        current_Titan = Instantiate(titan_GameObject[Random.Range(0, titan_GameObject.Length)],spawn.transform);        

        health_Fill.GetComponent<Slider>().maxValue = Attack.health_Value;
        health_Fill.GetComponent<Slider>().value = health_Fill.GetComponent<Slider>().maxValue;

        _titan.funtion_NextStageCall = true;
    }
    public void TitanDie()
    {
        current_Titan = GameObject.FindGameObjectWithTag("Titan_Tag");
        current_Titan.gameObject.SetActive(false);
        Destroy(current_Titan.gameObject);
        if((float)_stage.GetThisStage() % 2 == 0)
        {
            fullHealth = Attack.health_Value;
            forCalculate = fullHealth / (float)_stage.GetThisStage();
            fullHealth = ((float)_stage.GetThisStage() * fullHealth) / (forCalculate / count_Boss);
            count_Boss = count_Boss++;
            //Debug.Log(fullHealth);
            Set_StartTitanHealth(fullHealth);
            Set_CountBoss(count_Boss);
        }
        int rand = Random.Range(0,50);
        if (rand < Weapon.weapon_dropRate || (float)_stage.GetThisStage() % 5f == 0)
        {
            //Debug.Log("rand : " + rand);
            //Debug.Log("DropRate : " + Weapon.weapon_dropRate);
            if (_weapon.instance_Weapon == null)
            {
                _attack._weapon.WeaponDrop();
            }
        }
    }
    private void Awake()
    {
        _weapon = GameObject.Find("Weapon_Controller").GetComponent<Weapon>();
        _attack = GameObject.Find("Canvas").GetComponent<Attack>();
        _titan = GameObject.Find("Titan_Controller").GetComponent<Titan_Controller>();
        _stage = GameObject.Find("Stage_Controller").GetComponent<Stage_Controller>();
        prefab_titan = GameObject.FindGameObjectWithTag("Titan_Tag");
    }
}
