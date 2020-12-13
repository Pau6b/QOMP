using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace GUI
    {
        public class MainMenu : MonoBehaviour
        {
            public void OnPlayButtonPressed()
            {
                Core.SceneLoader.LoadScene(Core.SceneLoader.SceneType.Level1);
            }

            public void OnQuitButtonPressd()
            {
                Application.Quit();
            }
        }
    }
}
