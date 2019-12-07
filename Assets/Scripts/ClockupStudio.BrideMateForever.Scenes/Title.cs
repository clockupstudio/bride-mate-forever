using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClockupStudio.BrideMateForever.Scenes
{
    public class Title : MonoBehaviour
    {

        public void ToGameScene()
        {
            SceneManager.LoadScene("Game");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}

