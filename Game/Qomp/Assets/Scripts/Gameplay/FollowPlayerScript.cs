using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class FollowPlayerScript : MonoBehaviour
        {

            // Start is called before the first frame update
            public GameObject player;

            /*PARAMETERS TO VOLUNTARY MOVEMENT*/
            [SerializeField] private Transport m_transport;
            private float m_time;
            private bool m_moving = false;
            private int m_actualCamera;

            [SerializeField] List<GameObject> m_CameraPoints;
            private Vector3 m_translation, m_initialPos;
            private Quaternion m_rotation, m_initialRot;

            private float m_initTime;

            void Start()
            {
                m_transport.CameraMovement += CameraMove;

                m_actualCamera = 0;
                this.transform.position = m_CameraPoints[m_actualCamera].transform.position;
                this.transform.rotation = m_CameraPoints[m_actualCamera].transform.rotation;
            }

            // Update is called once per frame
            void Update()
            {
                if (m_moving)
                {
                    m_initTime += Time.deltaTime;
                    if (m_initTime > m_time)
                    {
                        m_initTime = m_time;
                        m_moving = false;
                    }
                    Vector3 movement = new Vector3(Mathf.Lerp(0, m_translation.x, m_initTime / m_time),
                                                Mathf.Lerp(0, m_translation.y, m_initTime / m_time),
                                                Mathf.Lerp(0, m_translation.z, m_initTime / m_time));

                    Quaternion rotation = Quaternion.Lerp(m_initialRot, m_rotation, m_initTime / m_time);

                    Vector3 pos_act = m_initialPos - movement;
                    this.transform.position = pos_act;
                    this.transform.rotation = rotation;
                }
            }
            private void CameraMove(float i_time, int i_travel)
            {
                m_moving = i_travel != m_actualCamera;
                if (m_moving)
                {
                    m_actualCamera = i_travel;
                    m_initTime = 0;
                    m_time = i_time;
                    m_translation = this.transform.position - m_CameraPoints[m_actualCamera].transform.position;
                    m_initialPos = this.transform.position;
                    m_initialRot = this.transform.rotation;
                    m_rotation = m_CameraPoints[m_actualCamera].transform.rotation;
                }
            }
        }
    }
}
