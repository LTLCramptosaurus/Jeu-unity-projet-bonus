using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    [Header("Variable Principale")]
    public PlayerStat m_playerStat;
    public GameObject m_canvas;
    public HpBarre m_hpBarre;
    public GameObject m_UI;

    public void Setup(PlayerStat pS)
    {
        m_playerStat = pS;
        Vector3 co = transform.GetChild(0).transform.position;
        GameObject tempo = Instantiate(m_UI,co, Quaternion.identity);      
        m_canvas = GameObject.Find("Canvas");
        tempo.transform.SetParent(m_canvas.transform,false);
        tempo.transform.position = Camera.main.WorldToScreenPoint(co);      //le Camera machin truc c'est une fonction qui donne les co pour le canvas avec les co du vrai monde
        TMP_Text leTexte = tempo.GetComponentInChildren<TMP_Text>();
        leTexte.text = pS.GetNom();
        m_hpBarre = tempo.GetComponentInChildren<HpBarre>();
        m_hpBarre.UpdateSlider(pS.GetMaxHp(),pS.GetCurrentHp());
    }

    void Start()
    {
        
    }

    public void Play()
    {
        
    }

    public void TakeDamage(int degat)
    {
        m_playerStat.TakeDamage(degat);
        m_hpBarre.UpdateSlider(m_playerStat.GetMaxHp(), m_playerStat.GetCurrentHp());
    }
}
