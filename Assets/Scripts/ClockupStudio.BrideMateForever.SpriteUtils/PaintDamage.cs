using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockupStudio.BrideMateForever.SpriteUtils
{
    public class PaintDamage : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private Shader _shaderGUItext;
        private Shader _shaderSpritesDefault;
        public Color paintDamageColor = new Color32(15, 56, 15, 255);
        void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _shaderGUItext = Shader.Find("GUI/Text Shader");
            _shaderSpritesDefault = Shader.Find("Sprites/Default");
        }

        public void AddPaintDamage()
        {
            _sprite.material.shader = _shaderGUItext;
            _sprite.color = paintDamageColor;
        }

        public void RemovePaintDamage()
        {
            _sprite.material.shader = _shaderSpritesDefault;
            _sprite.color = Color.white;
        }
    }
}
