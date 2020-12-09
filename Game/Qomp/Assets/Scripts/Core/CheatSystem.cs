using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    namespace Core
    {
        public class CheatSystem : MonoBehaviour
        {
            // Start is called before the first frame update
            [SerializeField] private Gameplay.RespawnComponent m_playerRespawnComponent;
            private int m_currentScene = -1;

            void Start()
            {
                m_currentScene = SceneManager.GetActiveScene().buildIndex;
                m_playerRespawnComponent.SetCanDie(Cheats.CheatInformationHolder.isGodModeEnabled);
            }

            // Update is called once per frame
            void Update()
            {
                if(Input.GetKeyDown(KeyCode.G))
                {
                    Cheats.CheatInformationHolder.isGodModeEnabled = !Cheats.CheatInformationHolder.isGodModeEnabled;
                    if (m_playerRespawnComponent != null)
                    {
                        m_playerRespawnComponent.SetCanDie(Cheats.CheatInformationHolder.isGodModeEnabled);
                    }
                }

                if ((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) && m_currentScene != 1)
                {
                    SceneLoader.LoadScene(SceneLoader.SceneType.Level1);
                }
                else if ((Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) && m_currentScene != 2)
                {
                    SceneLoader.LoadScene(SceneLoader.SceneType.Level2);
                }
                else if ((Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) && m_currentScene != 3)
                {
                    SceneLoader.LoadScene(SceneLoader.SceneType.Level3);
                }
                else if ((Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) && m_currentScene != 4)
                {
                    SceneLoader.LoadScene(SceneLoader.SceneType.Level4);
                }
                else if ((Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) && m_currentScene != 5)
                {
                    SceneLoader.LoadScene(SceneLoader.SceneType.Level5);
                }
            }
        }
    }
}
