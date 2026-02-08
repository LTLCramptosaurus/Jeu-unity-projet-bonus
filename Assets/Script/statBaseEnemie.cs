using System.Data;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "statBaseEnemie", menuName = "Scriptable Objects/statBaseEnemie")]
public class StatBaseEnemie : ScriptableObject
{
    public GameObject Prefab;
    public int BaseHP;
    public int BaseAtk;
    public int BaseXP;
    public int BaseGold;    //argent drop de base (pas forcement de l'or)
}

public class StatEnemie
{
    [Header("Variable Principale")]
    public int Hp;
    public int CurrentHp;
    public int Atk;
    public int Xp;
    public int Gold;
    public string Nom;
    public int Level;
    public GameObject Prefab;

    [Header("Varibalbe Secondaire")]
    [SerializeField] float HpScale = 6f;        // le [SerializeField] permet d'afficher la variable dans l'inspecteur sans la rendre public
    [SerializeField] float HpPower = 2.2f;
    [SerializeField] float AtkScale = 2.5f;
    [SerializeField] float AtkPower = 1.7f;
    [SerializeField] float XpPower = 1.5f;
    [SerializeField] float GoldPower = 1.2f;

    public void Setup(StatBaseEnemie stat, int lvl)
    {
        Hp = Mathf.FloorToInt((stat.BaseHP + HpScale) * Mathf.Pow(lvl, HpPower));    //hp en fonction du niveau : on fait hp de base + HpScale(=6) * le niveau^HpPower(=2.2) et tout ça arrondit au plus bas 
        CurrentHp = Hp;
        Atk = Mathf.FloorToInt((stat.BaseAtk + AtkScale) * Mathf.Pow(lvl, AtkPower));
        Xp = Mathf.FloorToInt(stat.BaseXP * Mathf.Pow(lvl, XpPower));
        Gold = Mathf.FloorToInt(stat.BaseGold * Mathf.Pow(lvl, GoldPower));
        Nom = stat.name;
        Prefab = stat.Prefab;
        Level = lvl;
    }
}