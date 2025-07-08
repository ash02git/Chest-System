using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    public class UnlockedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        public GenericStateMachine<T> stateMachine { get; set; }

        public UnlockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => Owner.ShowStateComponents(ChestStates.Unlocked);

        public void OnStateExit() => Owner.HideStateComponents(ChestStates.Unlocked);
    }
}