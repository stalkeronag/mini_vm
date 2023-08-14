

namespace Executor.Interfaces;

public interface IObserverCommand
{
    void CommandCompleted(ICommand command);
}