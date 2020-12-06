using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace Visual
    {
        public class ParticleDieWhenStopEmit : MonoBehaviour
        {
            // Start is called before the first frame update
            private ParticleSystem m_particleSystem;
            void Start()
            {
                m_particleSystem = GetComponent<ParticleSystem>();
            }

            // Update is called once per frame
            void Update()
            {
                if (!m_particleSystem.IsAlive(false))
                {
                    GameObject.Destroy(transform.gameObject);
                }
            }
        }
    }
}
