
namespace Executor.Interfaces;

public abstract class ExecuteCommandsStrategy : IObservableCommand
{
    private List<ICommand> commands;

    public List<ICommand> Commands { get => commands; set => commands = value; }

    public ExecuteCommandsStrategy(List<ICommand> commands)
    {
        this.Commands = commands;
    }

    public abstract void Execute();

    public abstract void AddObserver(IObserverCommand observerCommand);
   

    public abstract void RemoveObserver(IObserverCommand observerCommand);
}