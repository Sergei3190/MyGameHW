using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    //будет описывать поведение снарядов
    class Bullet: BaseObject, ICollision
    {
        /// <summary>
        /// конструктор создания нового объекта класса Bullet
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
           
        }

        /// <summary>
        /// метод рисования объекта класса Bullet
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Orange, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        /// <summary>
        /// метод обновления положения объекта класса Bullet
        /// </summary>
        public override void Update()
        {
         
            if (Size.Height <= 0) Size.Height += 1;
            if (Size.Width <= 0) Size.Height += 1;
            Pos.X = Pos.X + 3;
        }

        /// <summary>
        /// метод регенерации объекта класса Bullet при столкновении
        /// </summary>
        public override void Regeneretion()
        {
            Pos.X = 0;
        }
    }
}
