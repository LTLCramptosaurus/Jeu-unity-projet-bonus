using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    public PlayerStatBase[] m_joueur;
    public List<PlayerStat> m_PlayerTeam = new List<PlayerStat>();
    public bool m_JoueurStart = false;

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
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
        for(int i=0;i< m_joueur.Length;i++)
        {
           m_PlayerTeam.Add(new PlayerStat(m_joueur[i], 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DetailCombat m_detail;
    public void LancerCombat(InfoCombat Info, StatBaseEnemy[] StatEquipe)
    {
        m_detail = new DetailCombat(Info, StatEquipe);    // pour être sur de remettre à zero m_detail à chaque combat
    }
}
