using System.Linq;
using Algorithm.Logic.Types;
using Algorithm.Logic.Command;
using System.Collections.Generic;

namespace Algorithm.Logic
{
    /// <summary>
    /// Classe que contém a regra de negócio de como os comandos são utilizados para movimentar o drone
    /// </summary>
    public class Drone
    {
        private int LocationX {get; set;}
        private int LocationY { get; set; }
        private readonly string InvalidInput = "(999, 999)";

        private List<DroneCommand> ListCommands;

        public Drone()
        {
            LocationX = 0;
            LocationY = 0;
        }
        
        /// <summary>
        /// Recebe o input, monta os comandos, seta o plano cartesiano e o formata para retorno
        /// </summary>
        public string Move(string input)
        {
            ListCommands = CommandsBuilder.Create(input);

            if (ListCommands == null)
                return InvalidInput;

            SetLocations();

            return GetLocation();
        }

        /// <summary>
        /// Retorna o plano cartesiano formatado
        /// </summary>
        private string GetLocation()
        {
            return $"({LocationX}, {LocationY})";
        }
        
        /// <summary>
        /// Seta o plano cartesiano
        /// </summary>
        private void SetLocations()
        {
            LocationX = GetXItems().Sum(o => o.GetValue());
            LocationY = GetYItems().Sum(o => o.GetValue());
        }
        
        private List<DroneCommand> GetXItems()
        {
            return ListCommands
                .Where(o => o.CommandType == CommandType.O || o.CommandType == CommandType.L)
                .ToList();
        }
        
        private List<DroneCommand> GetYItems()
        {
            return ListCommands
                    .Where(o => o.CommandType == CommandType.S || o.CommandType == CommandType.N)
                    .ToList();
        }
    }
}
