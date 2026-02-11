using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject Spawner;
    public Transform[] EnemySpawn;
    int nbEnemy;
    public Transform[] PlayerSpawn;
    int nbPlayer;
    public List<Enemy> Enemy = new List<Enemy>();
    public List<PlayerCombat> playerCombat = new List<PlayerCombat>();
    public bool Fin = false;
    public int tour = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nbEnemy = GameManager.Instance.detail.GetEquipe().Length;
        nbPlayer = GameManager.Instance.PlayerTeam.Count;
        Position();
        for(int i=0; i < nbEnemy ; i++)
        {
            GameObject EnemyTempo = Instantiate(GameManager.Instance.detail.GetEquipe()[i].GetPrefab(),EnemySpawn[i].position,Quaternion.identity);
            Enemy.Add(EnemyTempo.GetComponent<Enemy>());
            Enemy[i].Setup(GameManager.Instance.detail.GetEquipe()[i]);
        }
        for(int i=0; i < nbPlayer ; i++)
        {
            GameObject PlayerTempo = Instantiate(GameManager.Instance.PlayerTeam[i].GetPrefab(),PlayerSpawn[i].position,Quaternion.identity);
            playerCombat.Add(PlayerTempo.GetComponent<PlayerCombat>());
            playerCombat[i].Setup(GameManager.Instance.PlayerTeam[i]);
        }
    }

    public void Position() //rempli les tableaux de spawner en fonction du nombre de joueur/enemy
    {
        EnemySpawn = new Transform[nbEnemy];
        PlayerSpawn = new Transform[nbPlayer];

        //Enemy
        if(nbEnemy == 1)
        {
            EnemySpawn[0] = Spawner.transform.GetChild(0).transform.GetChild(1);
        }else if(nbEnemy == 2)
        {
            EnemySpawn[0] = Spawner.transform.GetChild(0).transform.GetChild(0);
            EnemySpawn[1] = Spawner.transform.GetChild(0).transform.GetChild(2);
        }
        else
        {
            EnemySpawn[0] = Spawner.transform.GetChild(0).transform.GetChild(1);
            EnemySpawn[1] = Spawner.transform.GetChild(0).transform.GetChild(0);
            EnemySpawn[2] = Spawner.transform.GetChild(0).transform.GetChild(2);
        }

        //Player
        if(nbPlayer == 1)
        {
            PlayerSpawn[0] = Spawner.transform.GetChild(1).transform.GetChild(1);
        }else if(nbPlayer == 2)
        {
            PlayerSpawn[0] = Spawner.transform.GetChild(1).transform.GetChild(0);
            PlayerSpawn[1] = Spawner.transform.GetChild(1).transform.GetChild(2);
        }
        else
        {
            PlayerSpawn[0] = Spawner.transform.GetChild(1).transform.GetChild(1);
            PlayerSpawn[1] = Spawner.transform.GetChild(1).transform.GetChild(0);
            PlayerSpawn[2] = Spawner.transform.GetChild(1).transform.GetChild(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LancerCombat()
    {
        while (!Fin)
        {
            if (GameManager.Instance.JoueurStart)
            {
                for(int i=0; i < playerCombat.Count; i++)
                {
                    playerCombat[i].Play();
                }
                for(int i=0;i < Enemy.Count; i++)
                {
                    StartCoroutine(Enemy[i].Play(playerCombat));
                }
            }
            else
            {
                for(int i=0;i < Enemy.Count; i++)
                {
                    StartCoroutine(Enemy[i].Play(playerCombat));
                }
                for(int i=0; i < playerCombat.Count; i++)
                {
                    playerCombat[i].Play();
                }
            }
        }
    }
}
