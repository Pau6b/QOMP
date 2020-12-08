using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private Vector3 m_Dir;
    [SerializeField] private float m_travel, m_speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 getDir()
    {
        return m_Dir;
    }

    public float getVel()
    {
        return m_speed;
    }

    public float getTran()
    {
        return m_travel;
    }
}
