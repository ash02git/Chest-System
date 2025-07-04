using ChestSystem.Main;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private List<ChestSlotView> slots;
        private int maxChestsSlots = 4;

        private ChestView chestPrefab;

        private List<ChestScriptableObject> chestSOList;

        public ChestService(GameObject chestSlotView, Transform chestSystemParent, ChestView chestPrefab, 
            List<ChestScriptableObject> chestSOList)
        {
            this.chestSOList = chestSOList;
            slots = new List<ChestSlotView>();
            this.chestPrefab = chestPrefab;
            CreateChestSlots(chestSlotView, chestSystemParent);
            this.chestSOList = chestSOList;
        }

        private void CreateChestSlots(GameObject chestSlotView, Transform chestSystemParent)
        {
            for(int i=0; i < maxChestsSlots; i++)
            {
                ChestSlotView newSlot = new ChestSlotView(chestSlotView, chestSystemParent);
                slots.Add(newSlot);
            }
        }

        public void TryAddChest()
        {
            foreach(ChestSlotView slot in slots)
            {
                if (slot.slotState == SlotState.Free)
                {
                    slot.currentChest = CreateChest(slot.slotTransform.transform);
                    slot.slotState = SlotState.Occupied;
                    return;
                }
            }

            GameService.Instance.PopupService.DisplayErrorText();
        }

        private ChestController CreateChest( Transform slot)
        {
            ChestScriptableObject chestSO = getRandomChestScriptableObject();
            ChestController newChest = new ChestController(chestSO, chestPrefab, slot);
            return newChest;
        }

        public void RemoveChest(ChestController chestController)
        {
            foreach(ChestSlotView slot in slots)
            {
                if(slot.currentChest == chestController)
                {
                    chestController.DestroyChest();
                    slot.currentChest = null;
                    slot.slotState = SlotState.Free;
                }
            }
        }

        private ChestScriptableObject getRandomChestScriptableObject() => chestSOList[Random.Range(0,chestSOList.Count)];
    }
}