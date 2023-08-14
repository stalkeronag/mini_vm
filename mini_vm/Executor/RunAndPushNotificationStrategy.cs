

using Executor.Interfaces;

namespace Executor;

public class RunAndPushNotificationStrategy : ExecuteCommandsStrategy
{
    private List<IObserverCommand> observers;

    public RunAndPushNotificationStrategy(List<ICommand> commands) : base(commands)
    {

    }

    public override void AddObserver(IObserverCommand observerCommand)
    {
        observers.Add(observerCommand);
    }

    public override void RemoveObserver(IObserverCommand observerCommand)
    {
        observers.Remove(observerCommand);
    }

    public override void Execute()
    {
        foreach (var command in Commands)
        {
            command.Execute();
            SendMessageToObservers(command);
        }
    }

    private void SendMessageToObservers(ICommand command)
    {
        foreach (var observer in observers)
        {
            observer.CommandCompleted(command);
        }
    }

}