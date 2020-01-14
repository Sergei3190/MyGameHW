using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Asteroid: BaseObject, ICollision
    {
        Image image = Image.FromFile("Ast.jpg");
       
        public int Power { get; set; }

        /// <summary>
        /// конструктор создания нового объекта класса Asteroid
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size): base(pos,dir,size)
        {
            Power = 1;
        }

        /// <summary>
        /// метод рисования объекта класса Asteroid
        /// </summary>
        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        /// <summary>
        /// метод обновления положения объекта класса Asteroid
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }

        /// <summary>
        /// метод регенерации объекта класса Asteroid при столкновении
        /// </summary>
        public override void Regeneretion()
        {
            Pos.X = Game.Width;
            Pos.Y = Dir.Y;
        }
    }
}
