using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject m_UI;
    public StatEnemy m_statEnemy;
    public GameObject m_canvas;
    public HpBarre m_hpBarre;

    public void Setup(StatEnemy sE)
    {
        m_statEnemy = sE;
        Vector3 co = transform.GetChild(0).transform.position;
        GameObject tempo = Instantiate(m_UI,co, Quaternion.identity);      
        m_canvas = GameObject.Find("Canvas");
        tempo.transform.SetParent(m_canvas.transform,false);
        tempo.transform.position = Camera.main.WorldToScreenPoint(co);      //le Camera machin truc c'est une fonction qui donne les co pour le canvas avec les co du vrai monde
        TMP_Text leTexte = tempo.GetComponentInChildren<TMP_Text>();
        leTexte.text = m_statEnemy.GetNom()+" lvl:"+m_statEnemy.GetLevel().ToString();
        m_hpBarre = tempo.GetComponentInChildren<HpBarre>();
        m_hpBarre.UpdateSlider(m_statEnemy.GetHp(),m_statEnemy.GetCurrentHp());
    }

    public void TakeDamage(int degat)
    {
        m_statEnemy.TakeDamage(degat);
        m_hpBarre.UpdateSlider(m_statEnemy.GetHp(),m_statEnemy.GetCurrentHp());
    }

    public IEnumerator Play(List<PlayerCombat> playerCombat)
    {
        int targetChoice = Random.Range(0,playerCombat.Count);
        yield return new WaitForSeconds(10);
        playerCombat[targetChoice].TakeDamage(m_statEnemy.GetAtk());
        yield return new WaitForSeconds(10);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
