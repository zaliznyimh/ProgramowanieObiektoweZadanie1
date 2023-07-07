using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class Settings : ISettings
    {

        private string _version;
        private ConsoleColor _consoleColor;
        
        /// <summary>
        /// Ctor.
        /// </summary>
        public Settings()
        {
            _version = "1.0";
            _consoleColor = ConsoleColor.White;
        }
        
        public string Version { get => _version; set => _version = value; }
        public ConsoleColor ConsoleColor { get => _consoleColor; set => _consoleColor = value; }
    }
}
