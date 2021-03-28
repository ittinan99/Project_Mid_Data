using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_All : Weapon
{
    protected override void NameWeapon()
    {
        weaponName = "Sword_All";
    }
    public override void SetUpStatWeapon()
    {
        tapDamage = jumAllLevel * _attack._weapon_Dic[weaponName].TapMultiply;
        criticalDamage = jumAllLevel * _attack._weapon_Dic[weaponName].CriticalMutiply;
        criticalChange = jumAllLevel * _attack._weapon_Dic[weaponName].CriticalChange;
        allDamage = jumAllLevel * _attack._weapon_Dic[weaponName].AllDamageMultiply;
        skillDamage = jumAllLevel * _attack._weapon_Dic[weaponName].SkillMultiply;
    }
}