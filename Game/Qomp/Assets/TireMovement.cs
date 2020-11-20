using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMovement : MonoBehaviour
{
    public Vector3 m_direction;
    public float m_speed;
    private Rigidbody m_tireRb;
    float m_rotatedAngle;
    // Start is called before the first frame update
    void Start()
    {
        m_tireRb = GetComponent<Rigidbody>();
        m_direction.Normalize();
        m_tireRb.velocity = new Vector3(m_speed*m_direction.x,0, m_speed*m_direction.z);
        m_rotatedAngle = Vector3.Angle(new Vector3(1, 0, 0), m_direction);
        transform.rotation = Quaternion.Euler(new Vector3(0, -m_rotatedAngle, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = m_tireRb.velocity;
            velocity.z = -velocity.z;
            m_tireRb.velocity = velocity;
            m_rotatedAngle += 90;
            m_rotatedAngle %= 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, -m_rotatedAngle, 0));
        }
    }
}
