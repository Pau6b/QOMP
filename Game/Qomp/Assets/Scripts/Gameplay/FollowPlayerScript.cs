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
            [SerializeField] float offset, height, inclination;

            /*PARAMETERS TO VOLUNTARY MOVEMENT*/
            [SerializeField] private Transport m_transport;
            private bool m_moving = false;
            private Vector3 m_movingDirection;
            private float m_movingPixels, m_speed;


            void Start()
            {
                Vector3 position = transform.position;
                position.x = player.transform.position.x;
                position.z = player.transform.position.z - offset;
                position.y = player.transform.position.y + height;
                transform.position = position;
                Vector3 angular = new Vector3(45,0,0);
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x + inclination,
                    transform.eulerAngles.y,
                    transform.eulerAngles.z
                );
                m_transport.CameraMovement += CameraMove;
            }

            // Update is called once per frame
            void Update()
            {
                if (m_moving && m_movingPixels > 0)
                {
                    Vector3 act_pos = transform.position;
                    float movement = m_movingPixels / m_speed;
                    if (movement > m_movingPixels)
                    {
                        movement = m_movingPixels;
                    }
                    transform.position = act_pos +
                        new Vector3(m_movingDirection.x*movement, 
                                    m_movingDirection.y*movement, 
                                    m_movingDirection.z*movement);
                    m_movingPixels -= movement;
                }
                else if (m_movingPixels < 0)
                {
                    m_moving = false;
                }



            }

            private void CameraMove(Vector3 i_Direction, float i_Speed, float i_travel)
            {
                m_moving = true;
                m_movingDirection = i_Direction;
                m_movingPixels = i_travel;
                m_speed = i_Speed;
            }

        }
    }
}
