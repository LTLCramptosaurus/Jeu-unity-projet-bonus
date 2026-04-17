using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Objects/PlayerStatBase")]
public class PlayerStatBase : ScriptableObject
{
    public int m_BaseHp;
    public int m_BaseAtk;
    public GameObject m_Prefab;
}

public class PlayerStat
{
    [Header("Variable Principale")]
    GameObject m_Prefab;
    int m_Atk;
    int m_MaxHp;
    int m_CurrentHp;
    int m_lvl;
    string m_Nom;

    [Header("Varibalbe Secondaire")]
    // le [SerializeField] permet d'afficher la variable dans l'inspecteur sans la rendre public
    [SerializeField] float HpPower = 1.45f;
    [SerializeField] float AtkPower = 1.4f;

    public PlayerStat(PlayerStatBase playerStatBase, int level)
    {
        m_Prefab = playerStatBase.m_Prefab;
        m_Nom = playerStatBase.name;
        m_lvl = level;
        m_MaxHp = Mathf.FloorToInt(playerStatBase.m_BaseHp + Mathf.Pow(m_lvl, HpPower));    //hp en fonction du niveau : on fait hp de base * le niveau^HpPower(=1.3) et tout ça arrondit au plus bas 
        m_CurrentHp = m_MaxHp;
        m_Atk = Mathf.FloorToInt(playerStatBase.m_BaseAtk * Mathf.Pow(m_lvl, AtkPower));
    }

    public GameObject GetPrefab()
    {
        return m_Prefab;
    }

    public int GetMaxHp()
    {
        return m_MaxHp;
    }

    public int GetCurrentHp()
    {
        return m_CurrentHp;
    }

    public int GetLvl()
    {
        return m_lvl;
    }

    public int GetAtk()
    {
        return m_Atk;
    }

    public string GetNom()
    {
        return m_Nom;
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHp -= damage;
    }
    
}
