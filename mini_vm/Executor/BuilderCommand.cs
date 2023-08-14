

using Executor.Interfaces;

namespace Executor;

public class BuilderCommand : IBuilderCommand
{

    private int countParametersNeeds;

    private ICommand currentCommand;

    public int CountParametersNeeds { get => countParametersNeeds; set => countParametersNeeds = value; }

    public ICommand AddParameters(byte[] parameters)
    {
        currentCommand.parameters = parameters;

        return currentCommand;
    }

    public ICommand BuildCommand(byte codeCommand)
    {
        throw new NotImplementedException();
    }
}