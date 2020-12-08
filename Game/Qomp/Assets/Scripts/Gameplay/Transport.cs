using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;
    private bool m_traveling = false;
    private Vector3 m_travelDir = new Vector3(0, 0, 0);
    private int m_mode;

    public delegate void PlatformMovementOn(Vector3 i_direction);
    public event PlatformMovementOn PlataformModeOn;

    public delegate void PlatformMovementOff();
    public event PlatformMovementOff PlataformModeOff;


    public delegate void CameraMove(Vector3 i_Direction, float i_Speed, float i_travel);
    public event CameraMove CameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider i_other)
    {
        if (i_other.gameObject.tag == "Transport")
        {
            if (!m_traveling)
            {
                m_traveling = true;
                m_travelDir = i_other.GetComponent<TransportFloor>().getDir();
                m_mode = i_other.GetComponent<TransportFloor>().getMode();
                PlataformModeOn?.Invoke(m_travelDir);
            }
            else
            {
                m_traveling = false;
                PlataformModeOff?.Invoke();
            }
        }
        else if (i_other.gameObject.tag == "route" && m_traveling)
        {
            m_travelDir = i_other.GetComponent<RoutePoint>().getDir(m_mode);
            PlataformModeOn?.Invoke(m_travelDir);
        }


        else if (i_other.gameObject.tag == "Section")
        {
            Vector3 direction = i_other.GetComponent<CameraChange>().getDir();
            float velocity = i_other.GetComponent<CameraChange>().getVel();
            float transition = i_other.GetComponent<CameraChange>().getTran();
            CameraMovement?.Invoke(direction, velocity, transition);
        }
    }
}