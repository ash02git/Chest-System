using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestScriptableObject chestSO;
        private ChestView chestView;

        private ChestStates currentState;

        private ChestStateMachine stateMachine;

        private int timeLeft; //in seconds

        public ChestController(ChestScriptableObject chestSO, ChestView chestView, Transform parent)
        {
            this.chestSO = chestSO;
            timeLeft = chestSO.unlockTime * 60;

            InitializeView(chestView, chestSO.chestIcon, timeLeft, parent);
            CreateStateMachine();

            stateMachine.ChangeState(ChestStates.Locked); //initially making ChestState as locked
            currentState = ChestStates.Locked;
        }

        private void CreateStateMachine() => stateMachine = new ChestStateMachine(this);

        private void InitializeView(ChestView prefab, Sprite chestIcon, int timeLeft, Transform parent)
        {
            chestView = GameObject.Instantiate<ChestView>(prefab, parent);
            chestView.SetController(this);
            chestView.InitializeChestView(chestIcon, timeLeft);
        }

        public void DestroyChest()
        {
            GameObject.Destroy(this.chestView.gameObject);
            chestSO = null;
        }

        public ChestStates GetChestState() => currentState;

        public int GetTimeLeft() => timeLeft;

        public void SetState(ChestStates newState)  //change name of function to SetState
        {
            stateMachine.ChangeState(newState);
            currentState = newState;
        }

        public void ShowStateComponents(ChestStates state) => chestView.ShowStateComponents(state);

        public void HideStateComponents(ChestStates state) => chestView.HideStateComponents(state);

        public void StartTimer() => chestView.StartTimer(timeLeft);

        public void StopTimer() => chestView.StopTimer();

        public void UpdateTimeLeft() => timeLeft--;

        public int GetRandomGems() => UnityEngine.Random.Range(chestSO.minGems, chestSO.maxGems);

        public int GetRandomGold() => UnityEngine.Random.Range(chestSO.minGold, chestSO.maxGold);

        ~ChestController() => Debug.Log("Chest Controller Deleted");
    }
}