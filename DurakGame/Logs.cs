using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DurakGame
{
    public  class Logs
    {
        // Where file gets placed to
        public string location = "gamelog.txt";


        // Recording Log
        public void GameLogs(string logs)
        {
            StreamWriter record = File.AppendText(location);

            record.WriteLine(logs);
            record.Close();
        }

        // Clears previous logs
        public void ClearLogs(string clear)
        {
            StreamWriter record = new StreamWriter(location);
            record.WriteLine(clear);
            record.Close();
        }

        // Grab Logs
        public void RecordLogs(Logs recordLogs)
        {
            recordLogs.GameLogs("\nRound: ");
        }
    }
}
