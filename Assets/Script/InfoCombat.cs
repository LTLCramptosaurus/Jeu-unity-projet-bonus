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
    public Sprite Fond;
    public AudioClip Music;
    public StatEnemie[] Equipe;
    public int TotalXp = 0;
    public int TotalGold = 0;

    public void Setup(InfoCombat info, StatBaseEnemie[] StatEquipe)
    {
        Fond = info.Fond;
        Music = info.Music;
        Equipe = new StatEnemie[StatEquipe.Length];
        for(int i = 0; i < StatEquipe.Length ; i++)
        {
            Equipe[i] = new StatEnemie();
            Equipe[i].Setup(StatEquipe[i],Random.Range(info.lvlMin,info.lvlMax+1));
        }
        foreach(StatEnemie enemie in Equipe)
        {
            TotalGold += enemie.Gold;
            TotalXp += enemie.Xp;
        }
    }
}