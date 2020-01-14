using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Pharmacy: BaseObject,ICollision
    {
        Image image = Image.FromFile("farm.png");
        
        /// <summary>
        /// конструктор создания нового объекта класса Pharmacy
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Pharmacy(Point pos, Point dir, Size size): base (pos, dir, size)
        {

        }

        /// <summary>
        /// метод рисования объекта класса Pharmacy
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        /// <summary>
        /// метод обновления положения объекта класса Pharmacy
        /// </summary>
        public override void Update()
        {
            
        }
    }
}
