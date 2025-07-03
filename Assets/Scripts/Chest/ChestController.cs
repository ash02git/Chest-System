using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestScriptableObject chestSO;
        private ChestView chestView;

        public ChestController(ChestScriptableObject chestSO, ChestView chestView, Transform slot)
        {
            this.chestSO = chestSO;

            this.chestView = GameObject.Instantiate<ChestView>(chestView, slot);

            this.chestView.SetController(this);
        }

        public void DestroyChest()
        {
            GameObject.Destroy(this.chestView);
            chestSO = null;
        }
    }
}