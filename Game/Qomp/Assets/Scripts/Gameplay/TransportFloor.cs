using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportFloor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 m_direction;
    [SerializeField] private int m_mode;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getDir()
    {
        return m_direction;
    }

    public int getMode()
    {
        return m_mode;
    }
}
