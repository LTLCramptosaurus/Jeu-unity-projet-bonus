using UnityEngine;

public class GestionFond : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = GameManager.Instance.detail.Fond;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
