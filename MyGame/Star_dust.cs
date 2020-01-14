using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Star_dust: BaseObject
    {
        /// <summary>
        /// конструктор создания нового объекта класса Star_dust
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Star_dust(Point pos, Point dir, Size size): base(pos,dir,size)
        {

        }

        /// <summary>
        /// метод рисования объекта класса Star_dust
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.X + Size.Width, Pos.Y + Size.Height, Size.Width, Size.Height));
            Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.Y, Pos.X, Size.Width, Size.Height));
            Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.Y + Size.Width, Pos.X + Size.Height, Size.Width, Size.Height));
        }

        /// <summary>
        /// метод обновления положения объекта класса Star_dust
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
