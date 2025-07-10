using ChestSystem.Chest;
using System.Collections.Generic;

namespace ChestSystem.StateMachine
{
    public class GenericStateMachine<T> where T : ChestController
    {
        protected T Owner;
        protected IState currentState;
        protected Dictionary<ChestStates, IState> States = new Dictionary<ChestStates, IState>();

        public GenericStateMachine(T Owner) => this.Owner = Owner;

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(ChestStates newState) => ChangeState(States[newState]);

        protected void SetOwner()
        {
            foreach (IState state in States.Values)
                state.Owner = Owner;
        }
    }
}