using ChestSystem.Main;
using ChestSystem.StateMachine;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class CollectedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        public GenericStateMachine<T> stateMachine;

        public CollectedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            int gemsObtained = Owner.GetRandomGems();
            int goldObtained = Owner.GetRandomGold();

            GameService.Instance.EventService.OnGemsChanged.InvokeEvent(gemsObtained);
            GameService.Instance.EventService.OnGoldChanged.InvokeEvent(goldObtained);

            OnStateExit();
        }

        public void OnStateExit() //nothing much to do i guess
        {
            GameService.Instance.EventService.OnChestCollected.InvokeEvent(Owner);
        }
    }
}