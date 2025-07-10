using ChestSystem.StateMachine;

namespace ChestSystem.Chest
{
    public class ChestStateMachine : GenericStateMachine <ChestController>
    {
        public ChestStateMachine(ChestController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.ChestStates.Locked, new LockedState<ChestController>(this));
            States.Add(StateMachine.ChestStates.Unlocking, new UnlockingState<ChestController>(this));
            States.Add(StateMachine.ChestStates.Unlocked, new UnlockedState<ChestController>(this));
            States.Add(StateMachine.ChestStates.Collected, new CollectedState<ChestController>(this));
        }
    }
}