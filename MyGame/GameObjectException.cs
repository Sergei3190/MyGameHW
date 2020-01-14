using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameObjectException : Exception
    {
        /// <summary>
        /// конструктор создания исключения класса GameObjectException
        /// </summary>
        /// <param name="message"></param>
        public GameObjectException(string message): base (message)
        {

        }
    }
}
