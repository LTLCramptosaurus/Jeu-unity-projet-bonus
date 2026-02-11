using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject UI;
    public StatEnemy statEnemy;
    public GameObject canvas;
    public HpBarre hpBarre;

    public void Setup(StatEnemy sE)
    {
        statEnemy = sE;
        Vector3 co = transform.GetChild(0).transform.position;
        GameObject tempo = Instantiate(UI,co, Quaternion.identity);      
        canvas = GameObject.Find("Canvas");
        tempo.transform.SetParent(canvas.transform,false);
        tempo.transform.position = Camera.main.WorldToScreenPoint(co);      //le Camera machin truc c'est une fonction qui donne les co pour le canvas avec les co du vrai monde
        TMP_Text leTexte = tempo.GetComponentInChildren<TMP_Text>();
        leTexte.text = statEnemy.GetNom()+" lvl:"+statEnemy.GetLevel().ToString();
        hpBarre = tempo.GetComponentInChildren<HpBarre>();
        hpBarre.UpdateSlider(statEnemy.GetHp(),statEnemy.GetCurrentHp());
    }

    public void PrendreDegat(int degat)
    {
        statEnemy.TakeDamage(degat);
        hpBarre.UpdateSlider(statEnemy.GetHp(),statEnemy.GetCurrentHp());
    }

    public IEnumerator Play(List<PlayerCombat> playerCombat)
    {
        int targetChoice = Random.Range(0,playerCombat.Count);
        yield return new WaitForSeconds(30);
        playerCombat[targetChoice].TakeDamage(statEnemy.GetAtk());
        yield return new WaitForSeconds(30);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
