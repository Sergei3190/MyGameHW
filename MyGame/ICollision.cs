using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    interface ICollision
    {
        //закладывает поведение, по которому два объекта, поддерживающие данный интерфейс, могут определить, столкнулись ли они.
         bool Collision(ICollision obj);

        //Для определения столкновения используем метод IntersectsWith структуры Rect
        Rectangle Rect { get; }
    }
}
