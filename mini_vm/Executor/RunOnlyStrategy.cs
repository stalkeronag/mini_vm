
using Executor.Interfaces;

namespace Executor;

public class RunOnlyStrategy : ExecuteCommandsStrategy
{
    private int countCommandExecute;

    public RunOnlyStrategy(List<ICommand> commands) : base(commands)
    {
        countCommandExecute = commands.Count;
    }

    public RunOnlyStrategy(List<ICommand> commands, int countCommand) : base(commands)
    {
        countCommandExecute = countCommand;
    }

    public override void AddObserver(IObserverCommand observerCommand)
    {
        throw new NotImplementedException();
    }

    public override void Execute()
    {
       ICommand[] commands = Commands.ToArray();

       for (int i = 0; i < countCommandExecute; i++)
       {
        commands[i].Execute();
       } 
    }

    public override void RemoveObserver(IObserverCommand observerCommand)
    {
        throw new NotImplementedException();
    }
}