using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    public AudioSource m_lecteur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_lecteur.clip = GameManager.m_Instance.m_detail.GetMusic(); 
        m_lecteur.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
