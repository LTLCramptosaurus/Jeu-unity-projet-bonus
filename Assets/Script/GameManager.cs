using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerStatBase[] joueur;
    public List<PlayerStat> PlayerTeam = new List<PlayerStat>();
    public bool JoueurStart = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0;i<3;i++)
        {
            PlayerTeam.Add(new PlayerStat(joueur[i], 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DetailCombat detail;
    public void LancerCombat(InfoCombat Info, StatBaseEnemy[] StatEquipe)
    {
        detail = new DetailCombat(Info, StatEquipe);    // pour être sur de remettre à zero detail à chaque combat
    }
}
