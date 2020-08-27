using Game1.ScoreHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ScoreSaver
    {
        ScoreReader scoreReader;
        readonly string location;
        readonly string path;
        readonly string fileName;

        public ScoreSaver(string path, string fileName )
        {
            this.path = path;
            this.fileName = fileName;
            this.location = path+"\\"+fileName;
            scoreReader = new ScoreReader(path, fileName);
        }

        private List<double> getTopScores(int lvlNr, double score)
        {
            List<double> currentScores = scoreReader.GetScore(lvlNr); 
            currentScores.Add(score);            
            currentScores.Sort();            
            return currentScores.Take(3).ToList();
        }

        private void insertScore(List<double> currentScores, int lvlNr)
        {
            var allScores = scoreReader.getAllLines();
            string[] newScores;
            ScoreHelper scoreHelper = new ScoreHelper();
            if (lvlNr > allScores.Length)
            {
                newScores = new string[lvlNr+1];
            }
            else
            {
                newScores = new string[allScores.Length+1];
            }

            for (int i = 0; i < newScores.Length; i++)
            {                               
                if (i == lvlNr)
                {
                    newScores[i] = String.Join(";",scoreHelper.doubleListToStringArray(currentScores));
                }
                else
                {
                    //Console.WriteLine("should not be here");

                    if (!(allScores.Length<=i))
                    {                      
                        newScores[i] = allScores[i];
                    }
                }
            }

            File.WriteAllLines(location, newScores);
        }

        public void SaveTopScore(int lvlNr, double score)
        {
           insertScore(getTopScores(lvlNr, score), lvlNr);
        }
    }
}
