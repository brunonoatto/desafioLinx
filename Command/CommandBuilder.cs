using System;
using System.Linq;
using Algorithm.Logic.Types;
using System.Collections.Generic;

namespace Algorithm.Logic.Command
{
    /// <summary>
    /// Classe que guarda a regra de negócio de como monta os comandos que irão ser realizados pela classe Drone.
    /// </summary>
    public static class CommandsBuilder
    {
        public static List<DroneCommand> Create(string input)
        {
            if (!InputIsValid(input))
                return null;

            input= input.ToUpper().Trim();

            List<DroneCommand> result = new List<DroneCommand>();
            char cancelCommand = 'X';
            char command;
            for (int i = 0; i < input.Length; i++)
            {
                command = input[i];
                if (CommandIsValid(command))
                {
                    if (command == cancelCommand)
                    {
                        if (result.Any())
                        {
                            result.Remove(result.Last());
                        }
                        else
                        {
                            return null; //começou com X ou excedeu a quantidade de comandos removidos
                        }
                    }
                    else
                    {
                        int value = GetNextValue(input, ref i);
                        result.Add(
                            DroneCommand.Instance((CommandType)Enum.Parse(typeof(CommandType), command.ToString()),
                                                  value));
                    }
                }
                else
                {
                    return null; //commando inválido ou pode ter um expaço no meio
                }
            }

            if (!result.All(o => o.IsValid()))
                return null; //existe algum comando com valor inválido ou não tem tipo

            return result;
        }

        /// <summary>
        /// Recebe o índice do comando e verifica se tem algum valor específico para ele no input
        /// </summary>
        private static int GetNextValue(string input, ref int i)
        {
            int value = 1;
            if (i < input.Length - 1 && Char.IsDigit(input[i + 1]))
            {
                string commandValue = "";
                int count = 1;
                while (i + count < input.Length && Char.IsDigit(input[i + count]))
                {
                    commandValue = string.Concat(commandValue, input[i + count]);
                    count++;
                }
                i += count - 1;
                int.TryParse(commandValue, out value);
            }
            return value;
        }

        private static bool CommandIsValid(char command)
        {
            char[] validCommands = new char[] { 'N', 'S', 'L', 'O', 'X' };
            return validCommands.Contains(command);
        }
        
        private static bool InputIsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
