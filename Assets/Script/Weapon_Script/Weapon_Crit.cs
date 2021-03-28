using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Crit : Weapon
{
    protected override void NameWeapon()
    {
        weaponName = "Sword_Crit";
    }
    public override void SetUpStatWeapon()
    {
        tapDamage = jumCritLevel * _attack._weapon_Dic[weaponName].TapMultiply;
        criticalDamage = jumCritLevel * _attack._weapon_Dic[weaponName].CriticalMutiply;
        criticalChange = jumCritLevel * _attack._weapon_Dic[weaponName].CriticalChange;
        allDamage = jumCritLevel * _attack._weapon_Dic[weaponName].AllDamageMultiply;
        skillDamage = jumCritLevel * _attack._weapon_Dic[weaponName].SkillMultiply;
    }
}
