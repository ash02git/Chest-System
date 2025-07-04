using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    public class LockedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public LockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => Owner.ShowStateComponents(ChestStates.Locked);

        public void Update() { } //in locked state, no need to update anything

        public void OnStateExit() => Owner.HideStateComponents(ChestStates.Locked);
    }
}