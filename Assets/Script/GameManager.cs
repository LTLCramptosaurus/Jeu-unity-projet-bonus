using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    [SerializeField] private PlayerStatBase[] m_joueur;
    private List<PlayerStat> m_PlayerTeam = new List<PlayerStat>();
    private bool m_PlayerStart = false;
    private DetailCombat m_detail;

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

    public void LancerCombat(InfoCombat Info, StatBaseEnemy[] StatEquipe)
    {
        m_detail = new DetailCombat(Info, StatEquipe);    // pour être sur de remettre à zero m_detail à chaque combat
    }

    public DetailCombat Detail => m_detail;

    public GameObject GetPrefabEnemy(int id)
    {
        return m_detail.GetEquipe()[id].GetPrefab();
    }

    public GameObject GetPrefabAllier(int id)
    {
        return m_PlayerTeam[id].GetPrefab();
    }

    public List<PlayerStat> PlayerTeam => m_PlayerTeam;

    public bool PlayerStart => m_PlayerStart;
}
