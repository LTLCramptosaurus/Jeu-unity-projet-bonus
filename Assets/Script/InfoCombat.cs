using UnityEngine;

[CreateAssetMenu(fileName = "InfoCombat", menuName = "Scriptable Objects/InfoCombat")]
public class InfoCombat : ScriptableObject
{
    public Sprite Fond;
    public AudioClip Music;
    public int lvlMax;
    public int lvlMin;
}

public class DetailCombat
{
    [Header("Variable importante")]
    Sprite Fond;
    AudioClip Music;
    StatEnemy[] Equipe;
    int TotalXp = 0;
    int TotalGold = 0;

    public DetailCombat(InfoCombat info, StatBaseEnemy[] StatEquipe)
    {
        Fond = info.Fond;
        Music = info.Music;
        Equipe = new StatEnemy[StatEquipe.Length];
        for(int i = 0; i < StatEquipe.Length ; i++)
        {
            Equipe[i] = new StatEnemy(StatEquipe[i], Random.Range(info.lvlMin, info.lvlMax + 1));
        }
        foreach(StatEnemy enemy in Equipe)
        {
            TotalGold += enemy.GetGold();
            TotalXp += enemy.GetXp();
        }
    }

    public Sprite GetFond()
    {
        return Fond;
    }

    public AudioClip GetMusic()
    {
        return Music;
    }

    public StatEnemy[] GetEquipe()
    {
        return Equipe;
    }

    public int GetTotalXp()
    {
        return TotalXp;
    }

    public int GetTotalGold()
    {
        return TotalGold;
    }
}