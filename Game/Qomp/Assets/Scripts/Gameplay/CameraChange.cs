using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int m_nextCamera;
    [SerializeField] private float m_time;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float getTime()
    {
        return m_time;
    }
    public int getTran()
    {
        return m_nextCamera;
    }
}
