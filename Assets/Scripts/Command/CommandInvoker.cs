namespace ChestSystem.Commands
{
    public class CommandInvoker
    {
        private ICommand command;

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        public void RegisterCommand(ICommand commandToRegister) => command = commandToRegister;

        public void Undo() => command.Undo();
    }
}