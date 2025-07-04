using ChestSystem.StateMachine;
using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestScriptableObject chestSO;
        private ChestView chestView;

        private ChestStateMachine stateMachine;

        public ChestController(ChestScriptableObject chestSO, ChestView chestView, Transform parent)
        {
            this.chestSO = chestSO;
            InitializeView(chestView, chestSO.chestIcon, chestSO.unlockTime, parent);
            CreateStateMachine();
            stateMachine.ChangeState(ChestStates.Locked);
        }

        private void CreateStateMachine() => stateMachine = new ChestStateMachine(this);

        private void InitializeView(ChestView prefab, Sprite chestIcon, int unlockTime, Transform parent)
        {
            chestView = GameObject.Instantiate<ChestView>(prefab, parent);
            chestView.SetController(this);
            chestView.InitializeChestView(chestIcon, unlockTime);
        }

        public void DestroyChest()
        {
            GameObject.Destroy(this.chestView);
            chestSO = null;
        }

        public void UpdateEnemy() => stateMachine.Update();

        public void StartedUnlocking() => stateMachine.ChangeState(ChestStates.Unlocking);

        public void UnlockingCompleted() => stateMachine.ChangeState(ChestStates.Unlocked);

        public void ChestCollected() => stateMachine.ChangeState(ChestStates.Collected);

        public void ShowStateComponents(ChestStates state) => chestView.ShowStateComponents(state);

        public void HideStateComponents(ChestStates state) => chestView.HideStateComponents(state);

        public int GetUnlockTime() => chestSO.unlockTime;
    }
}