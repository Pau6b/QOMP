using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody m_tireRb;
    [SerializeField] private Vector3 m_direction;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_Ufo;
    void Start()
    {
        m_tireRb = GetComponent<Rigidbody>();
        Vector3 vel = new Vector3(1, 0, 1);
        vel.Normalize();
        m_tireRb.velocity = new Vector3(vel.x*m_direction.x, 0, vel.z*m_direction.z);
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 pos_Ufo = new Vector2(m_Ufo.transform.position.x, m_Ufo.transform.position.z);
        Vector2 pos_Raq = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 offset = new Vector2(this.transform.localScale.x, this.transform.localScale.z);

        Vector3 new_dir_x = new Vector3(pos_Ufo.x - pos_Raq.x, 0, 0);
        Vector3 new_dir_z = new Vector3(0, 0, pos_Ufo.y - pos_Raq.y);
        new_dir_x.Normalize();
        new_dir_z.Normalize();
        Vector3 speed = new Vector3(new_dir_x.x, 0, new_dir_z.z);
        speed.Normalize();
        speed = speed * m_speed;
        speed = new Vector3(speed.x * m_direction.x, 0, speed.z * m_direction.z);
        m_tireRb.velocity = speed;


        /*Vector2 offset = new Vector2(this.transform.localScale.x, this.transform.localScale.z);
        float velUfo_z = m_Ufo.GetComponent<Rigidbody>().velocity.z;
        float velUfo_x = m_Ufo.GetComponent<Rigidbody>().velocity.z;
        Vector2 pos_Ufo = new Vector2(m_Ufo.transform.position.x, m_Ufo.transform.position.z);
        Vector2 pos_Raq = new Vector2(this.transform.position.x, transform.position.z);

        if (m_direction.z != 0 && ((m_direction.z > 0 && velUfo_z < 0) || (m_direction.z < 0 && velUfo_z > 0)) && 
            ((pos_Ufo.y < pos_Raq.y + offset.y/2) && (pos_Ufo.y > pos_Raq.y - offset.y/2)))
        {
            //m_direction.z = -m_direction.z;
            //m_tireRb.velocity = m_speed * m_direction;
            m_speed -= m_speed;
        }
        else if (m_direction.x != 0 && ((m_direction.x > 0 && velUfo_x < 0) || (m_direction.x < 0 && velUfo_x > 0)) &&
            ((pos_Ufo.x < pos_Raq.x + offset.x/2) && (pos_Ufo.x > pos_Raq.x - offset.x/2)))
        {
            //m_direction.x = -m_direction.x;
            //m_tireRb.velocity = m_speed * m_direction;
            m_speed -= m_speed;
        }*/

    }

}
