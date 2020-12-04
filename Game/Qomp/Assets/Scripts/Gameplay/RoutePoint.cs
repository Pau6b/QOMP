using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutePoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 m_redirectionForward;
    [SerializeField] private Vector3 m_redirectionBackward;
    public Vector3[] Directions = new Vector3[2];
    void Start()
    {
        Directions[0] = m_redirectionForward;
        Directions[1] = m_redirectionBackward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getDir(int i_pos)
    {
        return Directions[i_pos];
    }
}
