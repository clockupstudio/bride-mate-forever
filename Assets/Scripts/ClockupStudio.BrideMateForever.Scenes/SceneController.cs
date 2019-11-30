using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClockupStudio.BrideMateForever.NPCs;
using ClockupStudio.BrideMateForever.Player;

namespace ClockupStudio.BrideMateForever.Scenes
{
    public class SceneController : MonoBehaviour
    {
        public Bride bride;
        public Movement movement;
        public GameObject text;

        private bool _started = false;
        
        void Update() {
            if(_started) {
                return;
            }

            movement.Disable(true);
            StartCoroutine("BeginGame");
            Debug.Log("Start scene");
            _started = true;
        }

        private IEnumerator BeginGame()
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("Begin scene");
            bride.Throw();
            text.SetActive(false);
        }
    }
}
