using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject m_vue;
    public Transform[] m_EnemySpawn;
    int m_nbEnemy;
    public Transform[] m_PlayerSpawn;
    int m_nbPlayer;
    public List<Enemy> m_Enemy = new List<Enemy>();
    public List<PlayerCombat> m_playerCombat = new List<PlayerCombat>();
    private bool m_Fin = false;
    public int m_tour = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_nbEnemy = GameManager.m_Instance.m_detail.GetEquipe().Length;
        m_nbPlayer = GameManager.m_Instance.m_PlayerTeam.Count;
        Position(m_vue);
        for(int i=0; i < m_nbEnemy ; i++)
        {
            GameObject Enemy = Instantiate(GameManager.m_Instance.m_detail.GetEquipe()[i].GetPrefab(),m_EnemySpawn[i].position,Quaternion.identity);
            m_Enemy.Add(Enemy.GetComponent<Enemy>());
            m_Enemy[i].Setup(GameManager.m_Instance.m_detail.GetEquipe()[i]);
        }
        for(int i=0; i < m_nbPlayer ; i++)
        {
            GameObject Player = Instantiate(GameManager.m_Instance.m_PlayerTeam[i].GetPrefab(),m_PlayerSpawn[i].position,Quaternion.identity);
            m_playerCombat.Add(Player.GetComponent<PlayerCombat>());
            m_playerCombat[i].Setup(GameManager.m_Instance.m_PlayerTeam[i]);
        }

        StartCoroutine(LancerCombat());
    }

    public void Position(GameObject vue) //rempli les tableaux de spawner en fonction du nombre de joueur/enemy
    {
        m_EnemySpawn = new Transform[m_nbEnemy];
        m_PlayerSpawn = new Transform[m_nbPlayer];

        //Enemy
        if(m_nbEnemy == 1)
        {
            m_EnemySpawn[0] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1);
        }else if(m_nbEnemy == 2)
        {
            m_EnemySpawn[0] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
            m_EnemySpawn[1] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2);
        }
        else
        {
            m_EnemySpawn[0] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1);
            m_EnemySpawn[1] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
            m_EnemySpawn[2] = vue.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2);
        }

        //Player
        if(m_nbPlayer == 1)
        {
            m_PlayerSpawn[0] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(1);
        }else if(m_nbPlayer == 2)
        {
            m_PlayerSpawn[0] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0);
            m_PlayerSpawn[1] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(2);
        }
        else
        {
            m_PlayerSpawn[0] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(1);
            m_PlayerSpawn[1] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0);
            m_PlayerSpawn[2] = vue.transform.GetChild(0).transform.GetChild(1).transform.GetChild(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            
    }

    public IEnumerator LancerCombat()
    {
        if (GameManager.m_Instance.m_JoueurStart)
        {
            for (int i=0; i < m_playerCombat.Count; i++)
            {
                m_playerCombat[i].Play();
                yield return new WaitForSeconds(10); ;
            }
            for(int i=0;i < m_Enemy.Count; i++)
            {
                StartCoroutine(m_Enemy[i].Play(m_playerCombat));
                yield return new WaitForSeconds(10); ;
            }
        }
        else
        {
            for (int i=0;i < m_Enemy.Count; i++)
            {
                Debug.Log("5");
                StartCoroutine(m_Enemy[i].Play(m_playerCombat));
                yield return new WaitForSeconds(10); ;
            }
            for(int i=0; i < m_playerCombat.Count; i++)
            {
                Debug.Log("7");
                m_playerCombat[i].Play(); 
                yield return new WaitForSeconds(10); ;
            }
        }
        if (!m_Fin)
        {
            StartCoroutine(LancerCombat());
        }
    }
}
