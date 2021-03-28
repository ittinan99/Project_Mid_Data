using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Controller : MonoBehaviour
{
    protected float level = 1;
    protected float exp;
    protected float expCap;
    float increaseLevel;

    public Text levelText;
    public Text levelPointText;

    public static int levelPoint;

    private void Awake()
    {
        levelText = GameObject.Find("Player Level").GetComponent<Text>();
        levelPointText = GameObject.Find("Level_Point").GetComponent<Text>();
    }
    private void Start()
    {
        SetStartLevel();
        SetStartExp();
        SetStartLevelPoint();
        Set_LevelText();
        Set_LevelPointText();
    }

    public void Set_LevelPointText()
    {
        if (levelPointText == null)
        {
            levelPointText = GameObject.Find("Level_Point").GetComponent<Text>();
        }
        levelPointText.text = levelPoint.ToString();
    }
    private void SetStartLevelPoint()
    {
        if (Stage_Controller.reStage == true)
        {
            levelPoint = (int)level;
            Stage_Controller.reStage = false;
        }
        else
        {
            levelPoint = PlayerPrefs.GetInt("levelPoint");
        }
    }
    public void Set_LevelText()
    {
        if(levelText == null)
        {
            levelText = GameObject.Find("Player Level").GetComponent<Text>();
        }
        levelText.text = level.ToString();
    }
    private void SetStartLevel()
    {
        if(PlayerPrefs.GetFloat("PlayerLevel") == 0)
        {
            level = 1;
        }
        else
        {
            level = PlayerPrefs.GetFloat("PlayerLevel");
        }
    }
    private void SetStartExp()
    {
        if (PlayerPrefs.GetFloat("PlayerExp") == 0)
        {
            exp = 0;
        }
        else
        {
            exp = PlayerPrefs.GetFloat("PlayerExp");
        }
    }
    public void GetExp(float newExp)
    {
        Debug.Log(newExp);
        exp = exp + newExp;
        HowLevelUp();
        Debug.Log(PlayerPrefs.GetFloat("PlayerLevel"));
        Debug.Log(PlayerPrefs.GetFloat("PlayerExp"));
    }
    public void LevelUp(float currentLevel)
    {
        level = currentLevel++;   
    }
    public void Set_CurrentLevel(float currentLevel)
    {
        PlayerPrefs.SetFloat("PlayerLevel", currentLevel);
        PlayerPrefs.Save();
    }
    public void Set_CurrentExp(float currentExp)
    {
        PlayerPrefs.SetFloat("PlayerLevel", currentExp);
        PlayerPrefs.Save();
    }
    public void Set_CurrentLevelPoint(int currentLevelPoint)
    {
        currentLevelPoint = currentLevelPoint + PlayerPrefs.GetInt("levelPoint");
        PlayerPrefs.SetInt("levelPoint", currentLevelPoint);
        PlayerPrefs.Save();
    }
    public void Set_LevelPointTo(int currentLevelPoint)
    {
        PlayerPrefs.SetInt("levelPoint", currentLevelPoint);
        PlayerPrefs.Save();
    }
    public void HowLevelUp()
    {
        expCap = Mathf.Pow(5,level);
        Debug.Log(expCap);
        if(exp >= expCap)
        {
            increaseLevel = exp / expCap;
            for(float i = increaseLevel ; i > 0 ;i--)
            {
                if (exp >= expCap)
                {
                    Debug.Log(level);
                    expCap = Mathf.Pow(5, level);
                    level++;
                    levelPoint++;
          
                    Set_CurrentLevel(level);
                    Set_CurrentLevelPoint(1);
                    Set_LevelText();
                }
            }
        }
    }
}
