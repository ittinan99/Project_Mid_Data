using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Skill : Weapon
{
    protected override void NameWeapon()
    {
        weaponName = "Sword_Skill";
    }
    public override void SetUpStatWeapon()
    {
        tapDamage = jumSkillLevel * _attack._weapon_Dic[weaponName].TapMultiply;
        criticalDamage = jumSkillLevel * _attack._weapon_Dic[weaponName].CriticalMutiply;
        criticalChange = jumSkillLevel * _attack._weapon_Dic[weaponName].CriticalChange;
        allDamage = jumSkillLevel * _attack._weapon_Dic[weaponName].AllDamageMultiply;
        skillDamage = jumSkillLevel * _attack._weapon_Dic[weaponName].SkillMultiply;
    }
}
