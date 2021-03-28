using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titan_Controller : MonoBehaviour
{
    public float titan_health;

    public Stage_Controller _stage;
    public Spawn _spawn;

    public bool funtion_NextStageCall = true;
    
    IEnumerator Wait_CallNextStage()
    {
        yield return new WaitForSeconds(0.75f);
        _stage.NextStage();
    }
    IEnumerator Wait_Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        _spawn.SpawnTitan();
    }
    IEnumerator Wait_TitanDie()
    {
        yield return new WaitForSeconds(0.5f);
        _spawn.TitanDie();
    }

    private void Update()
    {
        if(Attack.health_Value <= 0 && funtion_NextStageCall == true)
        {
            funtion_NextStageCall = false;
            StartCoroutine(Wait_TitanDie());
            StartCoroutine(Wait_CallNextStage());
            StartCoroutine(Wait_Spawn()); 
        }
    }
    private void Start()
    {
        _stage.GetThisStage();
        _spawn.prefab_titan.SetActive(false);
        _spawn.SpawnTitan();
    }
    private void Awake()
    {
        _stage = GameObject.Find("Stage_Controller").GetComponent<Stage_Controller>();
        _spawn = GameObject.Find("Spawn").GetComponent<Spawn>();
    }
}
