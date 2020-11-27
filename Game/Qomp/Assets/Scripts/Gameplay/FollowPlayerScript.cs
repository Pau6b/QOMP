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
            [SerializeField] float offset;
            void Start()
            {
                Vector3 position = transform.position;
                position.x = player.transform.position.x;
                position.z = player.transform.position.z - offset;
                transform.position = position;
            }

            // Update is called once per frame
            void Update()
            {
                Vector3 position = transform.position;
                position.x = player.transform.position.x;
                position.z = player.transform.position.z - offset;
                transform.position = position;
            }
        }
    }
}
