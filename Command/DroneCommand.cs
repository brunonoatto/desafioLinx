using System;
using Algorithm.Logic.Types;

namespace Algorithm.Logic.Command
{
    /// <summary>
    /// Classe que armazena os dados do comando e retorna o valor que deve ser calculado para o plano cartesiano
    /// </summary>
    public class DroneCommand
    {
        public readonly CommandType CommandType;
        public readonly int Value;

        public static DroneCommand Instance(CommandType commandType, int value) => new DroneCommand(commandType, value);

        private DroneCommand(CommandType commandType, int value)
        {
            CommandType = commandType;
            Value = value;
        }

        public int GetValue()
        {
            int factor = CommandType == CommandType.S || CommandType == CommandType.O ? -1 : 1;
            return Value * factor;
        }

        public bool IsValid()
        {
            return Value < Int32.MaxValue && 
                CommandType != CommandType.None;
        }
    }
}
