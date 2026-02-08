using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Scriptable Objects/PlayerStatBase")]
public class PlayerStatBase : ScriptableObject
{
    public int BaseHp;
    public int BaseAtk;
    public GameObject Prefab;
}

public class PlayerStat
{
    [Header("Variable Principale")]
    public GameObject Prefab;
    public int Atk;
    public int MaxHp;
    public int CurrentHp;
    public int lvl;
    public string Nom;

    [Header("Varibalbe Secondaire")]
    // le [SerializeField] permet d'afficher la variable dans l'inspecteur sans la rendre public
    [SerializeField] float HpPower = 1.3f;
    [SerializeField] float AtkPower = 1.24f;

    public void Setup(PlayerStatBase playerStatBase, int level)
    {
        Prefab = playerStatBase.Prefab;
        Nom = playerStatBase.name;
        lvl = level;
        MaxHp = Mathf.FloorToInt(playerStatBase.BaseHp * Mathf.Pow(lvl, HpPower));    //hp en fonction du niveau : on fait hp de base * le niveau^HpPower(=1.3) et tout ça arrondit au plus bas 
        CurrentHp = MaxHp;
        Atk = Mathf.FloorToInt(playerStatBase.BaseAtk * Mathf.Pow(lvl, AtkPower));
    }
    
}
