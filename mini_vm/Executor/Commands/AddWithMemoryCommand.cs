

using System.Reflection.PortableExecutable;
using Core;
using Executor.Interfaces;

namespace Executor.Commands;

public class AddWithMemoryCommand : ICommand
{
    public byte[] parameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Execute()
    {
        var virtualMachine = VirtualMachine.GetInstance();

        string addressString = virtualMachine.RegisterH[0].ToString() + virtualMachine.RegisterL[0].ToString();

        int address = Convert.ToInt32(addressString, 16);

        virtualMachine.RegisterA[0] += virtualMachine.Ram[address];
    }

}