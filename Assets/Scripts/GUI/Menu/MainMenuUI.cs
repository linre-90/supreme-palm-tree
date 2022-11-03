using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Footkin.GUI
{
    public class MainMenuUI : MonoBehaviour
    {
        public SceneData sceneData;
        public void PlayGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneData.MainGame);
        }

        public void PlayMainMenu()
        {
            SceneManager.LoadScene(sceneData.MainMenu);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}