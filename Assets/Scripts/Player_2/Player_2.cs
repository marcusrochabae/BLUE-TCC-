using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public float m_speed = 5;
    public float m_Range = 0.005f;
    public GameObject m_X, m_X2, m_Y, m_Y2;

    private Rigidbody2D m_body;
    private float m_SmoothTime = 2f;
    private Transform m_Transform;
    private IdentificarControle m_IdentificarControle;

    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
    }

    void FixedUpdate()
    {
        MovLimit();

        // Direção horizontal
        float m_move_x = m_IdentificarControle.m_Horizontal2;

        // Direção vertical
        float m_move_y = m_IdentificarControle.m_Vertical2;

        // Efeito de flutuar
        Vector3 movement = m_Transform.position;
        movement.y += m_Range * Mathf.Sin(Time.time * m_SmoothTime);

        m_Transform.position = movement;

        if ((m_move_x >= 0.01f && m_move_x <= -0.01f) && (m_move_y >= 0.01f && m_move_y <= -0.01f))
        {
            
        } else {
            // Movimento
            m_body.velocity = new Vector2(m_move_x * m_speed, m_move_y * m_speed);
        }
    }

    // Definir limites de tela para movimento
    void MovLimit()
    {
        if (transform.position.x < m_X2.transform.position.x)
        {
            transform.position = new Vector3(m_X2.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > m_X.transform.position.x)
        {
            transform.position = new Vector3(m_X.transform.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y < m_Y2.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, m_Y2.transform.position.y, transform.position.z);
        }
        else if (transform.position.y > m_Y.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, m_Y.transform.position.y, transform.position.z);
        }
    }
}
