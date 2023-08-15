

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Debuger;
using Executor;
using Executor.Interfaces;
using ViewStates;

namespace EntryPointProgram;

public class FacadeProgram
{
    private IBuilderProgram builderProgram;

    private IBuilderCommand builderCommand;

    private IDisplayable displayable;

    private List<IObserverCommand> observers;

    public FacadeProgram()
    {
        builderProgram = new BuilderProgram();
        builderCommand = new BuilderCommand();
        displayable = new DisplayStatesVirtualMachineToConsole();
        observers = new List<IObserverCommand>();
    }

    public void CompileProgram(string path)
    {

    }

    public void ExecuteProgramWithResultViewEndStateVm(string path)
    {
        List<ICommand> commands = builderProgram.BuildProgram(path, builderCommand);
        ExecuteCommandsStrategy executeCommandsStrategy = new RunOnlyStrategy(commands);
        executeCommandsStrategy.Execute();
        displayable.Display();
    }

    public void ExecuteProgramWithViewEachStateVm(string path)
    {
        List<ICommand> commands = builderProgram.BuildProgram(path, builderCommand);
        
        ExecuteCommandsStrategy executeCommandsStrategy = new RunAndPushNotificationStrategy(commands);

        if (observers.Count ==0)
        {
            IObserverCommand observerCommand = new CommandsObserver(displayable);
            observers.Add(observerCommand);
        }
        
        foreach (var observer in observers)
        {
            executeCommandsStrategy.AddObserver(observer);
        }

        executeCommandsStrategy.Execute();
    }

    public void AddBuilderCommand(IBuilderCommand builderCommand)
    {
        this.builderCommand = builderCommand;
    }

    public void AddBuilderProgram(IBuilderProgram builderProgram)
    {
        this.builderProgram = builderProgram;
    }

    public void AddResultView(IDisplayable displayable)
    {
        this.displayable = displayable;
    }

    public void AddObserver(IObserverCommand observer)
    {
        observers.Add(observer);
    }
}