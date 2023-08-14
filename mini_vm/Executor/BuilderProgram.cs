

using System.Runtime.Serialization.Formatters;
using Executor.Interfaces;

namespace Executor;

public class BuilderProgram : IBuilderProgram
{
    private List<ICommand> commands;

    public BuilderProgram()
    {
        commands = new List<ICommand>();
    }

    public List<ICommand> BuildProgram(byte[] source, IBuilderCommand builderCommand)
    {
        for (int i = 0; i < source.Length; i++)
        {
            ICommand command = builderCommand.BuildCommand(source[i]);
            
            if (command == null)
            {
                return commands;
            }

            if (builderCommand.CountParametersNeeds > 0)
            {
                int countParameters = builderCommand.CountParametersNeeds;
                byte[] parameters = new byte[countParameters];

                for (int j = 0 ; j < countParameters; j++)
                {
                    parameters[j] = source[++i];
                }

                command =  builderCommand.AddParameters(parameters);
                commands.Add(command);
            }

        }

        return commands;
    }

    public List<ICommand> BuildProgram(string source, IBuilderCommand builderCommand)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(source, FileMode.Open)))
        {
           while (reader.PeekChar() > 0)
           {
                byte codeCommand = reader.ReadByte();

                ICommand command = builderCommand.BuildCommand(codeCommand);

                if (command == null)
                    return commands;
                
                if (builderCommand.CountParametersNeeds > 0)
                {
                    int countParameters = builderCommand.CountParametersNeeds;

                    byte[] parameters = reader.ReadBytes(countParameters);

                    command = builderCommand.AddParameters(parameters);

                    commands.Add(command);
                }
           }
        }

        return commands;
    }
}