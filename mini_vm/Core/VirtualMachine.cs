

namespace Core;

public class VirtualMachine
{
    private static VirtualMachine instance { get; set; }
    public byte[] RegisterA { get => registerA; set => registerA = value; }
    public byte[] RegisterB { get => registerB; set => registerB = value; }
    public byte[] RegisterC { get => registerC; set => registerC = value; }
    public byte[] RegisterD { get => registerD; set => registerD = value; }
    public byte[] RegisterE { get => registerE; set => registerE = value; }
    public byte[] RegisterH { get => registerH; set => registerH = value; }
    public byte[] RegisterL { get => registerL; set => registerL = value; }
    public byte[] RegisterSP { get => registerSP; set => registerSP = value; }
    public byte[] RegisterPC { get => registerPC; set => registerPC = value; }
    public byte[] Ram { get => ram; set => ram = value; }
    public byte[] Ports { get => ports; set => ports = value; }
    public byte[] RegisterFlags { get => registerFlags; set => registerFlags = value; }
    public int CountBytesRam { get => countBytesRam; set => countBytesRam = value; }
    public byte[][] Registers { get => registers; set => registers = value; }

    public const int countPorts = 256;

    public const int sizeInBytesValueCell = 1;

    public const int sizeInBytesAddressCell = 2;

    private int countBytesRam = 65536;

    private byte[] registerA;

    private byte[] registerB;

    private byte[] registerC;

    private byte[] registerD;

    private byte[] registerE;

    private byte[] registerH;

    private byte[] registerL;

    private byte[] registerSP;

    private byte[] registerPC;

    private byte[] registerFlags;

    private byte[] ram;

    private byte[] ports;

    private byte[][] registers;

    private VirtualMachine()
    {
        Ram = new byte[CountBytesRam];
        ports = new byte[countPorts];
        registerA = new byte[sizeInBytesValueCell];
        registerB = new byte[sizeInBytesValueCell];
        registerC = new byte[sizeInBytesValueCell];
        registerD = new byte[sizeInBytesValueCell];
        registerE = new byte[sizeInBytesValueCell];
        registerH = new byte[sizeInBytesValueCell];
        registerL = new byte[sizeInBytesValueCell];
        registerFlags = new byte[sizeInBytesValueCell];
        registerSP = new byte[sizeInBytesAddressCell];
        registerPC = new byte[sizeInBytesAddressCell];
        Registers = new byte[][]
        {
            registerA,
            registerB,
            registerC,
            registerD,
            registerE,
            registerH,
            registerL
        };
    }

    public static VirtualMachine GetInstance()
    {
        if (instance == null)
        {
            instance = new VirtualMachine();
        }
        return instance;
    }
}