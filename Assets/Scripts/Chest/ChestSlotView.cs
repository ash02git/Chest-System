using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestSlotView
    {
        public Transform slotTransform;
        public SlotState slotState;
        public ChestController currentChest;

        public ChestSlotView(GameObject slotPrefab, Transform slotsParent)
        {
            slotTransform = GameObject.Instantiate(slotPrefab,slotsParent).transform;
            slotState = SlotState.Free;
            currentChest = null;
        }
    }
}