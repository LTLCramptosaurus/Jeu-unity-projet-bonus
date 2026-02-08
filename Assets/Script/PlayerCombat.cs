using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    [Header("Variable Principale")]
    public PlayerStat playerStat;
    public GameObject canvas;
    public HpBarre hpBarre;
    public GameObject UI;

    public void Setup(PlayerStat pS)
    {
        playerStat = pS;
        Vector3 co = transform.GetChild(0).transform.position;
        GameObject tempo = Instantiate(UI,co, Quaternion.identity);      
        canvas = GameObject.Find("Canvas");
        tempo.transform.SetParent(canvas.transform,false);
        tempo.transform.position = Camera.main.WorldToScreenPoint(co);      //le Camera machin truc c'est une fonction qui donne les co pour le canvas avec les co du vrai monde
        TMP_Text leTexte = tempo.GetComponentInChildren<TMP_Text>();
        leTexte.text = pS.Nom;
        hpBarre = tempo.GetComponentInChildren<HpBarre>();
        hpBarre.UpdateSlider(pS.MaxHp,pS.CurrentHp);
    }

    void Start()
    {
        
    }

    public void Jouer()
    {
        
    }

    public void PrendreDegat(int degat)
    {
        playerStat.CurrentHp -= degat;
        hpBarre.UpdateSlider(playerStat.MaxHp,playerStat.CurrentHp);
    }
}
