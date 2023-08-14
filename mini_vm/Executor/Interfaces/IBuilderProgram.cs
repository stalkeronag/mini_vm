

namespace Executor.Interfaces;

public interface IBuilderProgram
{
    public List<ICommand> BuildProgram(byte[] source, IBuilderCommand builderCommand);

    public List<ICommand> BuildProgram(string source,IBuilderCommand builderCommand);
}