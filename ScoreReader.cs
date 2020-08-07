using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ScoreReader
    {
        public string[] ReadFile(int lvlNr)
        {
            string[] lines = File.ReadAllLines(@"%USERPROFILE%\Documents\speedRunner\topScores.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] splitted = lines[lvlNr-1].Split(';');
                if (i == lvlNr-1)
                {
                    return splitted;
                }
            }
           
            return {splitted};
        }
    }
}

