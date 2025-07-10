using UnityEngine;

namespace ChestSystem.Chest
{
    [CreateAssetMenu(fileName = "Chest Scriptable Object", menuName = "ScriptableObjects/NewChestScriptableObject")]
    public class ChestScriptableObject : ScriptableObject
    {
        public Sprite chestIcon;
        public ChestType chestType;
        public int minGold;
        public int maxGold;
        public int minGems;
        public int maxGems;
        public int unlockTime; //in minutes
    }
}