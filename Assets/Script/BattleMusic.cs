using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    public AudioSource lecteur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lecteur.clip = GameManager.Instance.detail.Music; 
        lecteur.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
