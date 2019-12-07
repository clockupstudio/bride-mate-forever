using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClockupStudio.BrideMateForever.Scenes
{
    public class EndingSceneUI : MonoBehaviour
    {

        public void GoToTitle()
        {
            SceneManager.LoadScene("Title");
        }
    }
}