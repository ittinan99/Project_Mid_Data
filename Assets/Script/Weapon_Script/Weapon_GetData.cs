public class Weapon_GetData
{
    public string Name;
    float tapMultiply = 1;
    float criticalMutiply = 1;
    float criticalChange = 1;
    float allDamageMultiply = 1;
    float skillMultiply = 1;

    public Weapon_GetData(float new_TapMultiply ,float new_CriticalMutiply ,float new_CriticalChange, float new_AllDamageMultiply, float new_SkillMultiply)
    {
        TapMultiply = new_TapMultiply;
        CriticalMutiply = new_CriticalMutiply;
        CriticalChange = new_CriticalChange;
        AllDamageMultiply = new_AllDamageMultiply;
        SkillMultiply = new_SkillMultiply;
    }

    public float TapMultiply { get => tapMultiply; set => tapMultiply = value; }
    public float CriticalMutiply { get => criticalMutiply; set => criticalMutiply = value; }
    public float CriticalChange { get => criticalChange; set => criticalChange = value; }
    public float AllDamageMultiply { get => allDamageMultiply; set => allDamageMultiply = value; }
    public float SkillMultiply { get => skillMultiply; set => skillMultiply = value; }

}
