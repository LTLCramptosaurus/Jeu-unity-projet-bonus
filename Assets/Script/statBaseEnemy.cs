using System.Data;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "StatBaseEnemy", menuName = "Scriptable Objects/StatBaseEnemy")]
public class StatBaseEnemy : ScriptableObject
{
    public GameObject m_Prefab;
    public int m_BaseHP;
    public int m_BaseAtk;
    public int m_BaseXP;
    public int m_BaseGold;    //argent drop de base (pas forcement de l'or)
}

public class StatEnemy
{
    [Header("Variable Principale")]
    GameObject m_Prefab;
    int m_Hp;
    int m_CurrentHp;
    int m_Atk;
    int m_Xp;
    int m_Gold;
    string m_Nom;
    int m_Level;

    [Header("Varibalbe Secondaire")]
    [SerializeField] float m_HpPower = 1.8f;
    [SerializeField] float m_AtkPower = 1.5f;
    [SerializeField] float m_XpPower = 1.5f;
    [SerializeField] float m_GoldPower = 1.5f;

    public StatEnemy(StatBaseEnemy stat, int lvl)
    {
        m_Hp = Mathf.FloorToInt(stat.m_BaseHP * Mathf.Pow(lvl, m_HpPower));    
        m_CurrentHp = m_Hp;
        m_Atk = Mathf.FloorToInt(stat.m_BaseAtk + Mathf.Pow(lvl, m_AtkPower));
        m_Xp = Mathf.FloorToInt(stat.m_BaseXP + Mathf.Pow(lvl, m_XpPower));
        m_Gold = Mathf.FloorToInt(stat.m_BaseGold + Mathf.Pow(lvl, m_GoldPower));
        m_Nom = stat.name;
        m_Prefab = stat.m_Prefab;
        m_Level = lvl;
    }
    public GameObject GetPrefab()
    {
        return m_Prefab;
    }
    public int GetHp()
    {
        return m_Hp;
    }
    public int GetCurrentHp()
    {
        return m_CurrentHp;
    }

    public int GetAtk()
    {
        return m_Atk;
    }

    public int GetXp()
    {
        return m_Xp;
    }

    public int GetGold()
    {
        return m_Gold;
    }

    public string GetNom()
    {
        return m_Nom;
    }

    public int GetLevel()
    {
        return m_Level;
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHp -= damage;
    }
}