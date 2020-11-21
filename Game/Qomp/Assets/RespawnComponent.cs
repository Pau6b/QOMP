using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [InspectorName("First Spawner")]
    public GameObject m_spawner;
    Vector3 m_velocity;
    Rigidbody m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_velocity = m_rb.velocity;
    }

    private void OnTriggerEnter(Collider i_other)
    {
        if (i_other.gameObject.tag == "Spike")
        {
            Vector3 newPosition = m_spawner.transform.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            m_rb.velocity = m_velocity;
        }
        if (i_other.gameObject.tag == "RespawnPoint" &&  m_spawner != i_other.gameObject)
        {
            m_spawner = i_other.gameObject;
            m_velocity = m_rb.velocity;
        }
    }
}
