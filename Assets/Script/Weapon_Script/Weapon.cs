using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Weapon[] _weapon;
    public Attack _attack;   
    public Inventory _inventory;

    public GameObject[] weapons;
    public GameObject spawn_Weapon;
    public GameObject instance_Weapon;
    public GameObject spawn_UseWeapon;
    public GameObject use_Weapon;
    protected string weaponName;

    public static float tapDamage = 1;
    public static float criticalDamage = 1;
    public static float criticalChange = 1;
    public static float allDamage = 1;
    public static float skillDamage = 1;
    public static float weapon_dropRate = 5;

    public Text current_LevelNormal;
    public Text current_LevelTap;
    public Text current_LevelCrit;
    public Text current_LevelAll;
    public Text current_LevelSkill;

    public Text current_Tap;
    public Text current_CritDam;
    public Text current_CritChange;
    public Text current_All;
    public Text current_Skill;

    public GameObject slash_Prefab;
    public RectTransform spawn_Slash;
    public GameObject spawnTitan;

    protected static float jumNormalLevel;
    protected static float jumTapLevel;
    protected static float jumCritLevel;
    protected static float jumAllLevel;
    protected static float jumSkillLevel;


    private void Awake()
    {
        _inventory = GameObject.Find("Weapon_Inventory").GetComponent<Inventory>();
        _attack = GameObject.Find("Canvas").GetComponent<Attack>();

        spawn_Slash = GameObject.Find("Spawn_Slash").GetComponent<RectTransform>();

        current_LevelNormal = GameObject.Find("Level_Normal").GetComponent<Text>();
        current_LevelTap = GameObject.Find("Level_Tap").GetComponent<Text>();
        current_LevelCrit = GameObject.Find("Level_Crit").GetComponent<Text>();
        current_LevelAll = GameObject.Find("Level_All").GetComponent<Text>();
        current_LevelSkill = GameObject.Find("Level_Skill").GetComponent<Text>();

        current_Tap = GameObject.Find("Weapon_Tap_Num").GetComponent<Text>();
        current_CritChange = GameObject.Find("Weapon_CritChange_Num").GetComponent<Text>();
        current_CritDam = GameObject.Find("Weapon_CritDamage_Num").GetComponent<Text>();
        current_All = GameObject.Find("Weapon_All_Num").GetComponent<Text>();
        current_Skill = GameObject.Find("Weapon_Skill_Num").GetComponent<Text>();

    }
    void Start()
    {
        NameWeapon();
        SetUpStatWeapon();
    }
    
    protected virtual void NameWeapon(){}
    public virtual void SetUpStatWeapon() {}
    public void Save_LevelWeapon(int current_LevelNormal,int current_LevelTap,int current_LevelCrit,int current_LevelAll,int current_LevelSkill)
    {
        int totalWeaponLevel = current_LevelNormal + current_LevelTap + current_LevelCrit + current_LevelAll + current_LevelSkill;
        jumNormalLevel = current_LevelNormal;
        jumTapLevel = current_LevelTap;
        jumCritLevel = current_LevelCrit;
        jumAllLevel = current_LevelAll;
        jumSkillLevel = current_LevelSkill;

        Set_WeaponText();
    }
    public void Set_WeaponText()
    {        
        current_Tap.text = tapDamage.ToString();
        current_CritDam.text = criticalDamage.ToString();
        current_CritChange.text = criticalChange.ToString();
        current_All.text = allDamage.ToString();
        current_Skill.text = skillDamage.ToString();
    }
    public void SetStartStatWeapon(float reset)
    {
        tapDamage = reset;
        criticalChange = reset;
        criticalDamage = reset;
        allDamage = reset;
        skillDamage = reset;
    }
    public void SelectNormalSword()
    {
        if (int.Parse(_inventory.weapon_Normal_Count.text) > 0)
        {
            if (use_Weapon != null)
            {
                Destroy(use_Weapon.gameObject);
            }
            use_Weapon = Instantiate(weapons[2], spawn_UseWeapon.transform);
            Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
        int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));           
        }
    }
    public void SelectTapSword()
    {
        if (int.Parse(_inventory.weapon_Tap_Count.text) > 0)
        {
            if (use_Weapon != null)
            {
                Destroy(use_Weapon.gameObject);
            }
            use_Weapon = Instantiate(weapons[4], spawn_UseWeapon.transform);
            Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
        int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }
    }
    public void SelectCritSword()
    {
        if (int.Parse(_inventory.weapon_Crit_Count.text) > 0)
        {
            if (use_Weapon != null)
            {
                Destroy(use_Weapon.gameObject);
            }
            use_Weapon = Instantiate(weapons[1], spawn_UseWeapon.transform);
            Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
        int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }       
    }
    public void SelectAllSword()
    {
        if (int.Parse(_inventory.weapon_All_Count.text) > 0)
        {
            if (use_Weapon != null)
            {
                Destroy(use_Weapon.gameObject);
            }
            use_Weapon = Instantiate(weapons[0], spawn_UseWeapon.transform);
            Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
        int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));
        }   
    }
    public void SelectSkillSword()
    {
        if (use_Weapon != null)
        {
            Destroy(use_Weapon.gameObject);
        }
        use_Weapon = Instantiate(weapons[3], spawn_UseWeapon.transform);
        Save_LevelWeapon(int.Parse(current_LevelNormal.text), int.Parse(current_LevelTap.text),
    int.Parse(current_LevelCrit.text), int.Parse(current_LevelAll.text), int.Parse(current_LevelSkill.text));      
    }
    public void WeaponDrop()
    {
        int rand = Random.Range(0, _weapon.Length);

        instance_Weapon = Instantiate(weapons[rand], spawn_Weapon.transform);
        Weapon _instance_Weapon = instance_Weapon.GetComponent<Weapon>();
        Destroy(_instance_Weapon);
    }
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500))
            {
                //if (instance_Weapon == null) { Debug.Log("Nothing.."); }
                var click = hit.transform;
                if (click.tag == "Weapon_Tag")
                {
                    if (instance_Weapon != null)
                    {
                        _inventory.Add_WeaponToInventory(instance_Weapon);
                    }
                }
                if(click.tag == "Titan_Tag")
                {
                    _attack.AttackTitan();
                    GameObject slash = Instantiate(slash_Prefab, spawn_Slash.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)),spawn_Slash.transform);
                    StartCoroutine(Wait_Destroy(slash));
                    Debug.Log("Hit");
                }
            }
        }
    }
    IEnumerator Wait_Destroy(GameObject something)
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(something.gameObject);
    }
}
