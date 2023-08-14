

using Executor.Interfaces;

namespace Debuger;

public class WriterStatesVirtualMachines : IDisplayable
{
    private string path;

    public WriterStatesVirtualMachines(string path)
    {
        this.path = path;
    }

    public void Display()
    {
        throw new NotImplementedException();
    }
}