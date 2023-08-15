

namespace Core;

public class CommandInfo
{
    private int code;

    private string name;

    private int parametersCount;

    public int Code { get => code; set => code = value; }
    public string Name { get => name; set => name = value; }
    public int ParametersCount { get => parametersCount; set => parametersCount = value; }
}