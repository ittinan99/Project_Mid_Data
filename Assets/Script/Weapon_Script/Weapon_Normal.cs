using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Normal : Weapon
{
    protected override void NameWeapon()
    {
        weaponName = "Sword_Normal";
    }
    public override void SetUpStatWeapon()
    {
        tapDamage = jumNormalLevel * _attack._weapon_Dic[weaponName].TapMultiply;
        criticalDamage = jumNormalLevel * _attack._weapon_Dic[weaponName].CriticalMutiply;
        criticalChange = jumNormalLevel * _attack._weapon_Dic[weaponName].CriticalChange;
        allDamage = jumNormalLevel * _attack._weapon_Dic[weaponName].AllDamageMultiply;
        skillDamage = jumNormalLevel * _attack._weapon_Dic[weaponName].SkillMultiply;
    }
}
