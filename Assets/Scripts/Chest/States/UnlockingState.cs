using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    public class UnlockingState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        public GenericStateMachine<T> stateMachine;

        public UnlockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => Owner.ShowStateComponents(ChestStates.Unlocking);

        public void Update()
        {

        }

        public void OnStateExit() => Owner.HideStateComponents(ChestStates.Unlocking);
    }
}