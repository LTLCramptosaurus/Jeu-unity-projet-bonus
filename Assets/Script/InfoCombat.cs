using UnityEngine;

[CreateAssetMenu(fileName = "InfoCombat", menuName = "Scriptable Objects/InfoCombat")]
public class InfoCombat : ScriptableObject
{
    public Sprite m_Fond;
    public AudioClip m_Music;
    public int m_lvlMax;
    public int m_lvlMin;
}

public class DetailCombat
{
    [Header("Variable importante")]
    Sprite m_Fond;
    AudioClip m_Music;
    StatEnemy[] m_Equipe;
    int m_TotalXp = 0;
    int m_TotalGold = 0;

    public DetailCombat(InfoCombat info, StatBaseEnemy[] StatEquipe)
    {
        m_Fond = info.m_Fond;
        m_Music = info.m_Music;
        m_Equipe = new StatEnemy[StatEquipe.Length];
        for(int i = 0; i < StatEquipe.Length ; i++)
        {
            m_Equipe[i] = new StatEnemy(StatEquipe[i], Random.Range(info.m_lvlMin, info.m_lvlMax + 1));
        }
        foreach(StatEnemy enemy in m_Equipe)
        {
            m_TotalGold += enemy.GetGold();
            m_TotalXp += enemy.GetXp();
        }
    }

    public Sprite GetFond()
    {
        return m_Fond;
    }

    public AudioClip GetMusic()
    {
        return m_Music;
    }

    public StatEnemy[] GetEquipe()
    {
        return m_Equipe;
    }

    public int GetTotalXp()
    {
        return m_TotalXp;
    }

    public int GetTotalGold()
    {
        return m_TotalGold;
    }
}