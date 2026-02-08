using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameObject UI;
    public StatEnemie statEnemie;
    public GameObject canvas;
    public HpBarre hpBarre;

    public void Setup(StatEnemie sE)
    {
        statEnemie = sE;
        Vector3 co = transform.GetChild(0).transform.position;
        GameObject tempo = Instantiate(UI,co, Quaternion.identity);      
        canvas = GameObject.Find("Canvas");
        tempo.transform.SetParent(canvas.transform,false);
        tempo.transform.position = Camera.main.WorldToScreenPoint(co);      //le Camera machin truc c'est une fonction qui donne les co pour le canvas avec les co du vrai monde
        TMP_Text leTexte = tempo.GetComponentInChildren<TMP_Text>();
        leTexte.text = statEnemie.Nom+" lvl:"+statEnemie.Level.ToString();
        hpBarre = tempo.GetComponentInChildren<HpBarre>();
        hpBarre.UpdateSlider(statEnemie.Hp,statEnemie.CurrentHp);
    }

    public void PrendreDegat(int degat)
    {
        statEnemie.CurrentHp -= degat;
        hpBarre.UpdateSlider(statEnemie.Hp,statEnemie.CurrentHp);
    }

    public void Jouer()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
