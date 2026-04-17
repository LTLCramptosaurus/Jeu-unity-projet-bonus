using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D m_rb;
    public float m_speed = 5;
    public InputActionReference m_move;
    Vector2 m_moveDirection = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        m_move.action.Enable();
    }

    private void OnDisable()
    {
        m_move.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        m_moveDirection = m_move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        m_rb.linearVelocity = new Vector2(m_moveDirection.x * m_speed, m_moveDirection.y * m_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            iaScript iaScript = collision.GetComponent<iaScript>();
            GameManager.m_Instance.LancerCombat(iaScript.m_Info, iaScript.m_StatBaseEnemy);
            SceneManager.LoadScene("Combat");
        }
    }
}
