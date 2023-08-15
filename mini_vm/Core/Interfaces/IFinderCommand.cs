

namespace Core.Interfaces;

public interface IFinderInfoCommand
{
    public CommandInfo GetCommandInfoByName(string name);

    public CommandInfo GetCommandInfoByCode(int code);
}