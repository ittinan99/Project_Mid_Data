using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Tap : Weapon
{
    protected override void NameWeapon()
    {
        weaponName = "Sword_Tap";
    }
    public override void SetUpStatWeapon()
    {
        tapDamage = jumTapLevel * _attack._weapon_Dic[weaponName].TapMultiply;
        criticalDamage = jumTapLevel * _attack._weapon_Dic[weaponName].CriticalMutiply;
        criticalChange = jumTapLevel * _attack._weapon_Dic[weaponName].CriticalChange;
        allDamage = jumTapLevel * _attack._weapon_Dic[weaponName].AllDamageMultiply;
        skillDamage = jumTapLevel * _attack._weapon_Dic[weaponName].SkillMultiply;
    }
}
