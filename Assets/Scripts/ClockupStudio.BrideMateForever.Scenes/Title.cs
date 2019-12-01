using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClockupStudio.BrideMateForever.Scenes
{
    public class Title : MonoBehaviour
    {
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}

