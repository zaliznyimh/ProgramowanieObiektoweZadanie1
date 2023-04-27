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
        private string _color; 

        public Settings()
        {
            _version = "1.0";
        }
        
        public string Version { get => _version; set => _version = value; }

        public void SetConsoleColor(string color)
        {
            _color = color;
        }
    }
}
