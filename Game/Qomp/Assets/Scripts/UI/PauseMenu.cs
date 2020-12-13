using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gui
    {

        public class PauseMenu : MonoBehaviour
        {
            private bool m_isPaused = false;
            [SerializeField] private GameObject m_pauseMenuUI;

            // Update is called once per frame
            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (m_isPaused)
                    {
                        Resume();
                    }
                    else 
                    {
                        m_pauseMenuUI.SetActive(true);
                        Time.timeScale = 0;
                        m_isPaused = true;
                    }
                }
            }

            public void Resume()
            {
                m_pauseMenuUI.SetActive(false);
                Time.timeScale = 1;
                m_isPaused = false;
            }

            public void GoToMainMenu()
            {
                Resume();
                Core.SceneLoader.LoadScene(Core.SceneLoader.SceneType.MainMenu);
            }

        }
    }
}
