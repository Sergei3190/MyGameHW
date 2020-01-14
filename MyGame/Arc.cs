using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Arc: BaseObject
    {
        /// <summary>
        /// конструктор создания нового объекта класса Arc
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Arc(Point pos, Point dir, Size size): base (pos, dir, size)
        {

        }

        /// <summary>
        /// метод рисования объекта класса Arc
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawArc(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height, 45, 60);
        }

        /// <summary>
        /// метод обновления положения объекта класса Arc
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Pos.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Pos.Y;
        }
    }
}
