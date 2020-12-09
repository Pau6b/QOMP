using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace Visual
    {

        public class RespawnPointAnimationScript : MonoBehaviour
        {
            // Start is called before the first frame update
            private Animator m_animator;
            void Start()
            {
                m_animator = GetComponent<Animator>();
                m_animator.SetBool("isActive", false);
            }

            public void SetActive(bool i_isActive)
            {
                m_animator.SetBool("isActive", i_isActive);
            }

            public void SetFirstAsSpawnerActive()
            {
                m_animator.SetBool("isActive", true);
                //m_animator.playbackTime = 0.3f;
            }
        }
    }
}
