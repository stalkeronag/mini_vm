

using Executor.Interfaces;
using Core;
using System.Text;

namespace ViewStates;

public class DisplayStatesVirtualMachineToConsole : IDisplayable
{
    private string registersNames;

    public DisplayStatesVirtualMachineToConsole()
    {
        string[] registersNames = new string[]
        {
            "register A",
            "register B",
            "register C",
            "register D",
            "register E",
            "register H",
            "register L"
        };
    }
    public void Display()
    {
        var virtualMachine = VirtualMachine.GetInstance();
        Console.WriteLine("Registers General Purposes");
        var registers = GetRegisterGeneralPurposeArray(virtualMachine);
        

        for (int i = 0; i < registersNames.Length; i++)
        {
            Console.WriteLine(registersNames + registers[i][0].ToString());
        }

        Console.WriteLine("Stack pointer Register and Program Counter Register");

        Console.WriteLine("Stack pointer" + virtualMachine.RegisterPC.ToString());

        Console.WriteLine("Program Counter" + virtualMachine.RegisterPC.ToString());

        Console.WriteLine("Show ram virtual machine");

        DrawRamTable();
        
    }

    private byte[][] GetRegisterGeneralPurposeArray(VirtualMachine virtualMachine)
    {
        byte[][] result = new byte[][]
        {
            virtualMachine.RegisterA,
            virtualMachine.RegisterB,
            virtualMachine.RegisterC,
            virtualMachine.RegisterD,
            virtualMachine.RegisterE,
            virtualMachine.RegisterH,
            virtualMachine.RegisterL
        };

        return result;
    }

    private void DrawRamTable()
    {
        var virtualMachine = VirtualMachine.GetInstance();

        for (int i = 0 ; i < virtualMachine.CountBytesRam / 16; i++)
        {
            byte[] rowAddress = Encoding.UTF8.GetBytes(i.ToString());

            if (rowAddress.Length == 1)
            {
                Console.Write("  ");

                Console.Write(rowAddress[0].ToString("X2") + " ");
            }
            else
            {
                Console.Write(rowAddress[0].ToString("X2") + " ");
            }

            byte[] bytes = new byte[16];

            for (int j = 0; j < bytes.Length; j++)
            {
                bytes[i] = virtualMachine.Ram[i];
                i++;
                Console.Write(bytes[i].ToString("X2") + " ");
            }

            i--;

            Console.WriteLine();
        }
    }

}