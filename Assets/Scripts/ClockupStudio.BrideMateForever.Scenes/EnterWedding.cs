using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClockupStudio.BrideMateForever.Scenes
{
    public class EnterWedding : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            SceneManager.LoadScene("Wedding");
        }
    }
}
