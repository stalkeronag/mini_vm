
namespace Executor.Interfaces;

public abstract class ExecuteCommandsStrategy
{
    private List<ICommand> commands;

    public List<ICommand> Commands { get => commands; set => commands = value; }

    public ExecuteCommandsStrategy(List<ICommand> commands)
    {
        this.Commands = commands;
    }

    public abstract void Execute();
}