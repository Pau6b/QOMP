using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportFloor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 m_direction;
    [SerializeField] private int m_mode;
    [SerializeField] private bool m_canMoveUFO = true;
    [SerializeField] private List<GameObject> m_objectsToActivate;
    [SerializeField] private List<GameObject> m_objectsToDeactivate;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<GameObject> GetObjectsToActivate()
    {
        return m_objectsToActivate;
    }

    public List<GameObject> GetObjectsToDeactivate()
    {
        return m_objectsToDeactivate;
    }

    public bool CanMoveUFO()
    {
        return m_canMoveUFO;
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
