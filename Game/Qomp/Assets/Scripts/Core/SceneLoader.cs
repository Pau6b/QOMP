using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    namespace Core
    {
        public class SceneLoader
        {
            public enum SceneType
            {
                MainMenu,
                Level1,
                Level2,
                Level3,
                Level4,
                Level5
            }

            static public void LoadScene(SceneType i_sceneType)
            {
                switch (i_sceneType)
                {
                    case SceneType.MainMenu:
                        SceneManager.LoadScene("MainMenu");
                        break;
                    case SceneType.Level1:
                        SceneManager.LoadScene("CityLevel");
                        break;
                    case SceneType.Level2:
                        SceneManager.LoadScene("DesertLevel");
                        break;
                    case SceneType.Level3:
                        SceneManager.LoadScene("AsianLevel");
                        break;
                    case SceneType.Level4:
                        SceneManager.LoadScene("MedievalLevel");
                        break;
                    case SceneType.Level5:
                        SceneManager.LoadScene("SpaceLevel");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
