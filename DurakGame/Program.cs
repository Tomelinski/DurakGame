/* Program.cs - Entry Point for the Durak Console App. The Program.cs calls the StartGame
 *            method of the DurakConsole Class.
 *         
 * Author(s): Aadithkeshev Anushayamunaithuraivan,
 *            Menushan Karunakaran,
 *            Calvin May,
 *            Tom Zielinski
 *            
 * Last Modified: 04/15/2021
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;
using DurakGame;

namespace DurakGame
{


    class Program
    {
        static void Main(string[] args)
        {
            // Start the Durak Game
            DurakConsole.StartGame();

           

            Console.ReadKey();
        }
    }
}
