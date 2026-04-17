using UnityEngine;

public class GestionFond : MonoBehaviour
{
    public SpriteRenderer m_spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_spriteRenderer.sprite = GameManager.m_Instance.Detail.GetFond();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
