using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 m_direction;
    public float m_speed;
    Rigidbody m_tireRb;

    void Start()
    {
        m_tireRb = GetComponent<Rigidbody>();
        m_direction.Normalize();
        m_tireRb.velocity = new Vector3(m_speed * m_direction.x, 0, m_speed * m_direction.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = m_tireRb.velocity;
            velocity.z = -velocity.z;
            m_tireRb.velocity = velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            m_direction = m_tireRb.velocity.normalized;
            if (Mathf.Abs(m_tireRb.velocity.x) != Mathf.Abs(m_tireRb.velocity.z))
            {
                if (m_direction.x > 0)
                {
                    m_direction.x = 1;
                }
                else if (m_direction.x < 0)
                {
                    m_direction.x = -1;
                }
                if (m_direction.z > 0)
                {
                    m_direction.z = 1;
                }
                else if (m_direction.z < 0)
                {
                    m_direction.z = -1;
                }
                m_direction.Normalize();
                m_tireRb.velocity = new Vector3(m_speed * m_direction.x, 0, m_speed * m_direction.z);
            }
        }
    }
}
