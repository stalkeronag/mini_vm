

namespace Executor.Interfaces;

public interface IObservableCommand
{
    void AddObserver(IObserverCommand observerCommand);

    void RemoveObserver(IObserverCommand observerCommand);
}