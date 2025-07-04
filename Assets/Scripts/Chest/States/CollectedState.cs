using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    public class CollectedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        public GenericStateMachine<T> stateMachine;

        public CollectedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() //probably destroy the chest
        {

        }

        public void Update()
        {

        }

        public void OnStateExit() //nothing much to do i guess
        {

        }
    }
}