

using System.Net.Http.Headers;
using Core;
using Core.Interfaces;
using Executor.Interfaces;

namespace Executor;

public class BuilderCommand : IBuilderCommand
{

    private int countParametersNeeds;

    private IFinderInfoCommand finderCommand;

    private ICommand currentCommand;


    private Dictionary<int , ICommand> dictionaryComamndByCode;


    private Dictionary<string , ICommand> dictionaryCommandByString;

    public int CountParametersNeeds { get => countParametersNeeds; set => countParametersNeeds = value; }

    public BuilderCommand()
    {
        finderCommand = new FinderCommand();
        dictionaryComamndByCode = new Dictionary<int , ICommand>();
        dictionaryCommandByString = new Dictionary<string, ICommand>();
    }

    public BuilderCommand(IFinderInfoCommand finderCommand)
    {
        this.finderCommand = finderCommand;
    }

    public ICommand AddParameters(byte[] parameters)
    {
        currentCommand.parameters = parameters;

        return currentCommand;
    }

    public ICommand BuildCommand(byte codeCommand)
    {
        CommandInfo commandInfo = finderCommand.GetCommandInfoByCode(codeCommand);

        countParametersNeeds = commandInfo.ParametersCount;

        currentCommand = dictionaryComamndByCode[codeCommand];

        return currentCommand;
    }
}