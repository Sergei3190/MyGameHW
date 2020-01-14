using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    //объявили делегат
    public delegate void LogGame(string s);

    class Log
    {

        /// <summary>
        /// метод вывода в консоль журнала событий
        /// </summary>
        /// <param name="message">событие</param>
        public static void LogConsele(string message)
        {
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// метод вывода в файл журнала событий 
        /// </summary>
        /// <param name="message">событие</param>
        public static void LogFile(string message)
        {
            System.IO.File.AppendAllText("log.txt", $"{message}\n");
        }

    }
}
