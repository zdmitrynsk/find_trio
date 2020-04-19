using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Trio.View
{
    public class CardIconsManager : MonoBehaviour
    {
        [SerializeField] private Texture textureCardIcons = null;
        [SerializeField] private Sprite spriteCardBack = null;
        [SerializeField] private List<Sprite> spritesCardIcons = null;

        public Sprite GetSpriteCardBack()
        {
            return spriteCardBack;
        }

        public List<Sprite> GetSpritesIconCard()
        {
            return spritesCardIcons;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            SetSpritesFromTexture();
        }

        private void SetSpritesFromTexture()
        {
            if (textureCardIcons != null)
            {
                var pathTexture = AssetDatabase.GetAssetPath(textureCardIcons);
                var sprites = AssetDatabase.LoadAllAssetsAtPath(pathTexture).OfType<Sprite>().ToList();

                spriteCardBack = sprites[0];

                spritesCardIcons.Clear();
                for (var i = 1; i < sprites.Count; i++)
                    spritesCardIcons.Add(sprites[i]);
            }
        }
#endif
        
    }
}
