

using System.Diagnostics;

namespace Executor.Interfaces;

public interface IBuilderCommand
{
    public int CountParametersNeeds {get; set;}

    public ICommand BuildCommand(byte codeCommand);

    public ICommand AddParameters(byte[] parameters);
}