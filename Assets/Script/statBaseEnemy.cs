using System.Data;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "statBaseEnemy", menuName = "Scriptable Objects/statBaseEnemy")]
public class StatBaseEnemy : ScriptableObject
{
    public GameObject Prefab;
    public int BaseHP;
    public int BaseAtk;
    public int BaseXP;
    public int BaseGold;    //argent drop de base (pas forcement de l'or)
}

public class StatEnemy
{
    [Header("Variable Principale")]
    GameObject Prefab;
    int Hp;
    int CurrentHp;
    int Atk;
    int Xp;
    int Gold;
    string Nom;
    int Level;

    [Header("Varibalbe Secondaire")]
    [SerializeField] float HpPower = 1.8f;
    [SerializeField] float AtkPower = 1.5f;
    [SerializeField] float XpPower = 1.5f;
    [SerializeField] float GoldPower = 1.5f;

    public StatEnemy(StatBaseEnemy stat, int lvl)
    {
        Hp = Mathf.FloorToInt(stat.BaseHP * Mathf.Pow(lvl, HpPower));    
        CurrentHp = Hp;
        Atk = Mathf.FloorToInt(stat.BaseAtk + Mathf.Pow(lvl, AtkPower));
        Xp = Mathf.FloorToInt(stat.BaseXP + Mathf.Pow(lvl, XpPower));
        Gold = Mathf.FloorToInt(stat.BaseGold + Mathf.Pow(lvl, GoldPower));
        Nom = stat.name;
        Prefab = stat.Prefab;
        Level = lvl;
    }
    public GameObject GetPrefab()
    {
        return Prefab;
    }
    public int GetHp()
    {
        return Hp;
    }
    public int GetCurrentHp()
    {
        return CurrentHp;
    }

    public int GetAtk()
    {
        return Atk;
    }

    public int GetXp()
    {
        return Xp;
    }

    public int GetGold()
    {
        return Gold;
    }

    public string GetNom()
    {
        return Nom;
    }

    public int GetLevel()
    {
        return Level;
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
    }
}