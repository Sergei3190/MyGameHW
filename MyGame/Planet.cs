using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Planet: BaseObject
    {
        /// <summary>
        /// конструктор создания нового объекта класса Planet
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Planet(Point pos, Point dir, Size size): base (pos,dir,size)
        {

        }

        /// <summary>
        /// метод рисования объекта класса Planet
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            Game.Buffer.Graphics.FillEllipse(Brushes.DarkOrange, new Rectangle(Pos.X-200, Pos.Y+300, Size.Width+30, Size.Height+30));
            Game.Buffer.Graphics.FillEllipse(Brushes.Yellow, new Rectangle(Pos.X-300, Pos.Y-100, Size.Width+50, Size.Height+50));
            Game.Buffer.Graphics.FillEllipse(Brushes.LightYellow, new Rectangle(Pos.X-100, Pos.Y+50, Size.Width-10, Size.Height-10));
            Game.Buffer.Graphics.FillEllipse(Brushes.CadetBlue, new Rectangle(Pos.X-400, Pos.Y+70, Size.Width+20, Size.Height+20));
        }


        /// <summary>
        /// метод обновления положения объекта класса Planet
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y;
        }
    }
}
