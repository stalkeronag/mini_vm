
namespace Executor.Interfaces;

public interface ICommand
{
    public byte[] parameters {get; set;}

    public void Execute();
}