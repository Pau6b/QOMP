using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class PlayerMovement : MonoBehaviour
        {
            public Vector3 m_direction;
            public float m_speed;
            Rigidbody m_tireRb;

            public delegate void OnDirectionChanged(Vector3 i_direction);
            public event OnDirectionChanged DirectionChanged;
            public event OnDirectionChanged DirectionChangedRequested;

            [SerializeField] private Transport m_TransportMovement;
            private bool m_fixDir = true;




            /*PARAMETERS TO INVOLUNTARI MOVEMENT*/
            [SerializeField] private Camera mainCamera;

            [SerializeField] private bool m_activateFollowPlayer;
            [SerializeField] private float m_leftOffsetCamera;
            [SerializeField] private float m_rightOffsetCamera;

            [SerializeField] private float m_transitionCamera;
            private float m_translationCameraDone;
            [SerializeField] private float m_speedCamera;
            private bool m_followingPlayer;
            private Vector3 m_DirCameraMovement;




            void Start()
            {
                m_TransportMovement.PlataformModeOn += PlatformMovementOn;
                m_TransportMovement.PlataformModeOff += PlatformMovementOff;
                m_tireRb = GetComponent<Rigidbody>();
                m_direction.Normalize();
                m_tireRb.velocity = m_speed * m_direction;
                m_DirCameraMovement = new Vector3(-1, -1, -1);
                m_translationCameraDone = 0;
            }

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space) && m_fixDir)
                {
                    Vector3 velocity = m_tireRb.velocity;
                    velocity.z = -velocity.z;
                    m_tireRb.velocity = velocity;
                    m_direction = m_tireRb.velocity.normalized;
                    DirectionChanged?.Invoke(m_direction);
                    DirectionChangedRequested?.Invoke(m_direction);
                }
            }

            void FixedUpdate()
            {
                if (m_fixDir)
                {
                    RenormalizeDirection();
                }

                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
                /*Translate plane left to the right*/
                planes[0].Translate(new Vector3(-m_rightOffsetCamera, 0, 0));
                /*Translate plane right to the left*/
                planes[1].Translate(new Vector3(m_leftOffsetCamera, 0, 0));
                Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
                m_followingPlayer = !(GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds));

                if (m_followingPlayer && m_DirCameraMovement.Equals(new Vector3(-1,-1,-1)))
                {
                    Vector3 pos_act = mainCamera.transform.position;
                    int selected = -1;
                    for (int i = 0; i < planes.Length - 2; ++i)
                    {
                        bool inside = planes[i].GetSide(transform.position);
                        if (!inside)
                        {
                            selected = i;
                            break;
                        }
                    }
                    switch (selected)
                    {
                        case 0:
                            m_DirCameraMovement = new Vector3(-1,0,0);
                            break;
                        case 1:
                            m_DirCameraMovement = new Vector3(1, 0, 0);
                            break;
                        case 2:
                            m_DirCameraMovement = new Vector3(0, 0, -1);
                            break;
                        case 3:
                            m_DirCameraMovement = new Vector3(0, 0, 1);
                            break;
                        default:
                            break;
                    }
                }

                if (m_followingPlayer && !m_DirCameraMovement.Equals(new Vector3(-1, -1, -1)))
                {
                    if (m_transitionCamera - m_translationCameraDone > 0)
                    {
                        Vector3 act_pos = mainCamera.transform.position;
                        float movement = m_transitionCamera / m_speedCamera;
                        if (movement > m_transitionCamera)
                        {
                            movement = m_transitionCamera;
                        }
                        mainCamera.transform.position = act_pos +
                            new Vector3(m_DirCameraMovement.x * movement,
                                        m_DirCameraMovement.y * movement,
                                        m_DirCameraMovement.z * movement);
                        m_translationCameraDone += movement;
                    }
                    else if (m_transitionCamera - m_translationCameraDone < 0)
                    {
                        m_followingPlayer = false;
                    }
                }
            }

            /*private void OnGUI()
            {
                Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
                GUILayout.Label("Screen pixels: " + screenPosition.x + ":" + screenPosition.y);
            }*/


            void RenormalizeDirection()
            {
                m_direction = m_tireRb.velocity.normalized;
                if (Mathf.Abs(m_tireRb.velocity.x) != Mathf.Abs(m_tireRb.velocity.z) && m_fixDir)
                {
                    if (m_direction.x > 0)
                    {
                        m_direction.x = 1;
                    }
                    else if (m_direction.x < 0)
                    {
                        m_direction.x = -1;
                    }
                    if (m_direction.z > 0)
                    {
                        m_direction.z = 1;
                    }
                    else if (m_direction.z < 0)
                    {
                        m_direction.z = -1;
                    }
                    m_direction.Normalize();
                    m_tireRb.velocity = m_speed * m_direction;
                }
            }


            private void OnCollisionEnter(Collision collision)
            {
                    DirectionChanged?.Invoke(m_direction);
            }

            private void PlatformMovementOn(Vector3 i_newDir)
            {
                m_direction = i_newDir;
                m_tireRb.velocity = m_speed * m_direction;
                GetComponent<Collider>().isTrigger = true;
                m_tireRb.useGravity = false;
                m_fixDir = false;
            }

            private void PlatformMovementOff()
            {
                float i = Mathf.Max(m_direction.x, Mathf.Max(m_direction.y, m_direction.z));
                if (i == 0.0)
                {
                    i = Mathf.Min(m_direction.x, Mathf.Min(m_direction.y, m_direction.z));
                }
                m_direction = new Vector3(i, 0, i);
                m_direction.Normalize();
                m_tireRb.velocity = m_speed * m_direction;
                GetComponent<Collider>().isTrigger = false;
                m_tireRb.useGravity = true;
                m_fixDir = true;
            }
        }

    }
}
