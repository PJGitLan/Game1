using Game1.ScoreHandler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ScoreReader
    {
        string path;
        string fileName;
        string location;

        public ScoreReader(string path, string fileName)
        {
            this.path = path;
            this.fileName = fileName;
            this.location = path + "\\" + fileName;
        }

        public string[] getAllLines()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(location))
            {
                Console.WriteLine(location);
                File.Create(location).Close();
            }
            return File.ReadAllLines(location);
            //@"%USERPROFILE%\Documents\speedRunner\topScores.txt");
        }
        private List<string[]> ReadFile() //reads file and puts it in list object
        {
            List<string[]> lvlScores = new List<string[]>();
            string[] lines = getAllLines();
            for (int i = 0; i < lines.Length; i++)
            {
                lvlScores.Add(lines[i].Split(';'));
            }
            return lvlScores;
        }

        public List<double> GetScore(int lvlNr)
        {
            var list = ReadFile();
            //Console.WriteLine("List:" + list.ToString());
            string[] array;
            if (list == null || list.Count <= lvlNr)
            {
                array = new string[]{};
            }
            else
            {
                Console.WriteLine("lvlNr: " +lvlNr);
                array = list[lvlNr];
            }
            
            ScoreHelper scoreHelper = new ScoreHelper();
            return scoreHelper.stringArrayToDoubleList(array);
        }
    }
}

