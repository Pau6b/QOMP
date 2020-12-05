using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    namespace Gameplay
    {
        public class EndLevelScript : MonoBehaviour
        {
            [SerializeField] private DetectAndInformCollision m_endLevelPoint;
            [SerializeField] private Core.SceneLoader.SceneType m_nextSceneName;

            private void Start()
            {
                m_endLevelPoint.Collided += OnCollisionInformed;
            }

            private void OnDestroy()
            {
                m_endLevelPoint.Collided -= OnCollisionInformed;
            }

            void OnCollisionInformed(Collision i_other)
            {
                if (i_other.gameObject.tag == "Player")
                {
                    Core.SceneLoader.LoadScene(m_nextSceneName);
                }
            }


        }
    }
}
