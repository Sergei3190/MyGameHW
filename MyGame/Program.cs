using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // для вывода графики 
using System.Drawing;
using System.Diagnostics;


#region HW1
// Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
// * Заменить кружочки картинками, используя метод DrawImage.
#endregion

#region HW2
// 1.Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
// 2.Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
// 3.Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, 
//   выбросить исключение ArgumentOutOfRangeException().
//*4.Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект с неправильными характеристиками(например, отрицательные размеры, 
//   слишком большая скорость или неверная позиция).
#endregion

#region HW3

//1. Добавить космический корабль, как описано в уроке.
//2. Доработать игру «Астероиды»:
//  a) Добавить ведение журнала в консоль с помощью делегатов;
//  b) * добавить это и в файл.
//3. Разработать аптечки, которые добавляют энергию.
//4. Добавить подсчет очков за сбитые астероиды.
//5. * Добавить в пример Lesson3 обобщенный делегат.

#endregion

#region HW4

//1. Добавить в программу коллекцию астероидов.Как только она заканчивается(все астероиды сбиты), формируется новая коллекция, в которой на один астероид больше.

#endregion
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height,
                ClientSize = new Size(1000, 1000),
                
            };

            Game.Init(form); // игра в этой форме 
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);


        }
    }
}
