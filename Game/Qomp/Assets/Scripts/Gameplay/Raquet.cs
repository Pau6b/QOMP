using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_tireRb;
    public Vector3 m_direction;
    public float m_speed;
    public float m_force;
    private GameObject m_Ufo = null;
    void Start()
    {
        m_tireRb = GetComponent<Rigidbody>();
        m_Ufo = GameObject.FindGameObjectsWithTag("Ufo")[0];
        m_direction.Normalize();
        float velUfo_z = m_Ufo.GetComponent<Rigidbody>().velocity.z;
        float velUfo_x = m_Ufo.GetComponent<Rigidbody>().velocity.z;
        m_direction = new Vector3(Mathf.Sign(velUfo_x)*m_direction.x, m_direction.y, Mathf.Sign(velUfo_z)*m_direction.z);
        m_tireRb.velocity = m_speed * m_direction;
    }


    // Update is called once per frame
    void Update()
    {
        Rigidbody Ufo_body = m_Ufo.GetComponent<Rigidbody>();
        float velUfo_z = Ufo_body.velocity.z;
        float velUfo_x = Ufo_body.velocity.x;
        Vector2 pos_Ufo = new Vector2(m_Ufo.transform.position.x, m_Ufo.transform.position.z);
        Vector2 pos_Raq = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 offset = new Vector2(this.transform.localScale.x, this.transform.localScale.z);

        Vector3 new_dir_x = new Vector3(pos_Ufo.x - pos_Raq.x, 0, 0);
        Vector3 new_dir_z = new Vector3(0, 0, pos_Ufo.y - pos_Raq.y);
        new_dir_x.Normalize();
        new_dir_z.Normalize();
        m_direction = new Vector3(new_dir_x.x, m_direction.y, new_dir_z.z);
        m_direction.Normalize();
        m_tireRb.velocity = m_speed * m_direction;

        /*if (((m_direction.z > 0 && velUfo_z < 0) || (m_direction.z < 0 && velUfo_z > 0)) && 
            ((pos_Ufo.y < pos_Raq.y + offset.y/2) && (pos_Ufo.y > pos_Raq.y - offset.y/2)))
        {
            m_direction.z = -m_direction.z;
            m_tireRb.velocity = m_speed * m_direction;
        }
        else if (((m_direction.x > 0 && velUfo_x < 0) || (m_direction.x < 0 && velUfo_x > 0)) &&
            ((pos_Ufo.x < pos_Raq.x + offset.x/2) && (pos_Ufo.x > pos_Raq.x - offset.x/2)))
        {
            m_direction.x = -m_direction.x;
            m_tireRb.velocity = m_speed * m_direction;
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Wall")
        {
            m_tireRb.velocity = new Vector3(0,0,0);
        }*/
    }
}
