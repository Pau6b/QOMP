using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {

        public class SnakePartActivateComponent : MonoBehaviour
        {
            private bool m_isActive = false;

            private void OnTriggerExit(Collider other)
            {
                if (other.transform.tag == "Player")
                {
                    m_isActive = true;
                }
            }

            public bool GetIsActive()
            {
                return m_isActive;
            }
        }
    }
}
