using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Web.Script.Serialization;

namespace DurakClient
{
    public class Logs
    {
    //    // Where file gets placed to
    //    public string STATS_PATH= "Log/gamestats.json";
    //    public string LOG_PATH = "Log/gamelog.txt";

    //    // Using json and using directory to load the text file to display the logs while game is progressiing


    //    /* NEED TO WORK ON THIS */
    //    // Recording Log
    //    public static void WriteGameStat(string logs)
    //    {
    //        if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
    //            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Log");

    //        using(StreamWriter writeFile = new StreamWriter(STATS_PATH))
    //        {
    //            if(player != null)
    //            {
    //                writeFile.WriteLine(player.toJson());
    //            }
    //            writeFile.Close();
    //        }
    //    }

    //    // Clears previous logs
    //    public void ClearLogs(string clear)
    //    {
    //         if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
    //            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Log");

    //        using(StreamWriter writeFile = new StreamWriter(LOG_PATH, true))
    //        {
    //            writeFile.WriteLine(toWrite);
    //            writeFile.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
    //        }
    //    }

    //    // Grab Logs
    //    public void RecordLogs(Logs recordLogs)
    //    {
    //        PlayerStats aPlayerStats = new PlayerStats();

    //        // Specifiying directory to use to load into domain
    //        if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Log"))
    //        {
    //            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + STATS_PATH))
    //            {
    //                // Read File from path
    //                using (StreamReader readFile = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + STATS_PATH))
    //                {
    //                    string json = readFile.ReadToEnd();
    //                    var serializer = new JavaScriptSerializer();
    //                    aPlayerStats = serializer.Deserialize<PlayerStats>(json);
    //                    if (aPlayerStats == null)
    //                        aPlayerStats = new PlayerStats();
    //                    reader.Close();
    //                }
    //            }
    //        } 
    //        else
    //        {
    //            aPlayerStats = new PlayerStats("", 0, 0, 0, 0, 0);
    //        }


    //        return aPlayerStats;
    //    }
    }
}
