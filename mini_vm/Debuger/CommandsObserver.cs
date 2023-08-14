

using Executor.Interfaces;

namespace Debuger;

public class CommandsObserver : IObserverCommand
{
    private IDisplayable displayable;

    public CommandsObserver(IDisplayable displayable)
    {
        this.displayable = displayable;
    }

    public void CommandCompleted(ICommand command)
    {
        //Todo realize some logic
        displayable.Display();
    }
}