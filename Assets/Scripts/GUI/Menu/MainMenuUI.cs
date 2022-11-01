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
            SceneManager.LoadScene(sceneData.MainGame);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }

}