using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Star_big: BaseObject
    {
        /// <summary>
        /// конструктор создания нового объекта класса Star_big
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Star_big(Point pos, Point  dir, Size size): base(pos,dir,size)
        {

        }

        /// <summary>
        /// метод рисования объекта класса Star_big
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y);
            Game.Buffer.Graphics.DrawLine(Pens.White, (Pos.X + (Pos.X + Size.Width)) / 2, Pos.Y + Size.Height / 2, (Pos.X + (Pos.X + Size.Width)) / 2, Pos.Y - Size.Height / 2);
        }


        /// <summary>
        /// метод обновления положения объекта класса Star_big
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X > Game.Width) Pos.X = -Game.Width + Size.Width;
            if (Pos.Y > Game.Height) Pos.Y = -Game.Height + Size.Height;
           
        }
    }
}
