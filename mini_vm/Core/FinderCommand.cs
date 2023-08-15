

using Core.Interfaces;

namespace Core;

public class FinderCommand : IFinderInfoCommand
{
    private Dictionary<int, CommandInfo> dictionaryCommandInfoWithKeyCodeCommand;

    private Dictionary<string, CommandInfo> dicitonaryCommandInfoWithKeyNameCommand;
    public FinderCommand()
    {
        //Todo fill dictionary
    }

    public CommandInfo GetCommandInfoByCode(int code)
    {
        if (dictionaryCommandInfoWithKeyCodeCommand.ContainsKey(code))
        {
            return dictionaryCommandInfoWithKeyCodeCommand[code];
        }

        return null;
    }

    public CommandInfo GetCommandInfoByName(string name)
    {
        if (dicitonaryCommandInfoWithKeyNameCommand.ContainsKey(name))
        {
            return dicitonaryCommandInfoWithKeyNameCommand[name];
        }

        return null;
    }
}