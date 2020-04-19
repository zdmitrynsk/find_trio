using UnityEngine;

namespace Trio
{
    [CreateAssetMenu(fileName =  "GameConfig", menuName = "Create game config")]
    public class GameConfig : ScriptableObject
    {
        public int widthGrid;
        public int heightGrid;
        public int countCardsPerType;

        private void OnValidate()
        {
            widthGrid = widthGrid < 2 ? 2 : widthGrid;
            widthGrid = widthGrid > 20 ? 20 : widthGrid;
            
            heightGrid = heightGrid < 2 ? 2 : heightGrid;
            heightGrid = heightGrid > 20 ? 20 : heightGrid;

            countCardsPerType = countCardsPerType < 2 ? 2 : countCardsPerType;
            countCardsPerType = countCardsPerType > 10 ? 10 : countCardsPerType;
        }
    }
}
