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
                Level1
            }
            static public void LoadScene(SceneType i_sceneType)
            {
                switch (i_sceneType)
                {
                    case SceneType.MainMenu:
                        SceneManager.LoadScene("MainMenu");
                        break;
                    case SceneType.Level1:
                        SceneManager.LoadScene("Game1Scene");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
