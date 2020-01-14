using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    // будет представлять наш космический корабль
    class Ship: BaseObject, ICollision
    {
        // событие возникающее при гибели коробля
        public static event Message MessageDie;

        private int _energy = 100;
        public int Energy => _energy;

        /// <summary>
        /// метод пожирания энергии корабля
        /// </summary>
        /// <param name="n">кол-во сжираемой энергии</param>
        public void EnergeLow(int n)
        {
            _energy -= n;
        }

        /// <summary>
        /// метод добавления энергии корабля
        /// </summary>
        /// <param name="n">кол-во добавляемой энергии</param>
        public void EnergeUp(int n)
        {
            _energy += n;
            if (_energy > 100) _energy = 100;
        }

        /// <summary>
        /// конструктор создания нового объекта класса Ship
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        public Ship(Point pos, Point dir, Size size) : base(pos,dir,size)
        {
                
        }

        /// <summary>
        /// метод рисования объекта класса Ship
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        /// <summary>
        /// метод обновления положения объекта класса Asteroid
        /// </summary>
        public override void Update()
        {

        }

        /// <summary>
        /// метод перемещения корабля вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        /// <summary>
        /// метод перемещения корабля вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        /// <summary>
        /// метод крушения корабля
        /// </summary>
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
