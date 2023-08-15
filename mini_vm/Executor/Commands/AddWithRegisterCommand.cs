


using Core;
using Executor.Interfaces;

namespace Executor.Commands;

public class AddWithRegisterCommand : ICommand
{
    private byte[] parametr;

    public byte[] parameters { get => parametr; set => parametr = value; }

    public int IndexRegisterSource { get; }

    public AddWithRegisterCommand(int indexRegisterSource)
    {
        IndexRegisterSource = indexRegisterSource;
    }

    public void Execute()
    {
        var virtualMachine = VirtualMachine.GetInstance();

        virtualMachine.RegisterA[0] += virtualMachine.Registers[IndexRegisterSource][0];
    }
}