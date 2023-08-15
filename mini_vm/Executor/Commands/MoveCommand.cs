


using Core;
using Executor.Interfaces;

namespace Executor.Commands;

public class MoveCommand : ICommand
{
    VirtualMachine virtualMachine;

    public byte[] parameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int IndexRegisterDestination { get; set; }

    public int IndexRegisterSource { get; set;}

    public MoveCommand(int indexRegisterDestination, int indexRegisterSource)
    {
        virtualMachine = VirtualMachine.GetInstance();

        IndexRegisterDestination = indexRegisterDestination;
        IndexRegisterSource = indexRegisterSource;
    }

    public void Execute()
    {
        virtualMachine.Registers[IndexRegisterDestination][0] = virtualMachine.Registers[IndexRegisterSource][0];
    }
}