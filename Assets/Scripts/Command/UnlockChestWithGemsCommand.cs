using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.StateMachine;

namespace ChestSystem.Commands
{
    public class UnlockChestWithGemsCommand : ICommand
    {
        private ChestController chestController;
        private ChestStates previousState;
        private int gemsRequired;

        public UnlockChestWithGemsCommand(ChestController chestController, int gems)
        {
            this.chestController = chestController;
            gemsRequired = gems;
        }

        public void Execute()
        {
            previousState = chestController.GetChestState();
            
            chestController.SetState(ChestStates.Unlocked);
            GameService.Instance.PlayerResourcesService.UpdateGems(-gemsRequired);
        }

        public void Undo()
        {
            chestController.SetState(previousState);
            GameService.Instance.PlayerResourcesService.UpdateGems(+gemsRequired);
        }
    }
}