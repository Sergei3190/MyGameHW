using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    #region
    // Создадим класс BaseObject, в котором зададим начальное поведение некоторых объектов.
    // Пусть это будут круги, которые при достижении края формы меняют направление движения.

    // Добавим слово abstract перед названием метода Draw.Virtual нужно убрать, так как абстрактный метод подразумевает виртуальность. Удалите тело метода Draw. 
    // Модификатор доступа конструктора абстрактного класса логичнее сделать protected, так как создать экземпляр такого класса нельзя, а унаследовать конструктор можно.
    #endregion

    /// <summary>
    /// тип делегата для обработки гибели коробля
    /// </summary>
    public delegate void Message();

    abstract class BaseObject: ICollision
    {      
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// конструктор класса BaseObject
        /// </summary>
        /// <param name="pos">координаты начального положения объекта</param>
        /// <param name="dir">координаты нового положения объекта</param>
        /// <param name="size">размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        
        /// <summary>
        /// метод рисования объекта
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// метод обновления положения объекта
        /// </summary>
        public abstract void Update();
        
        
        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)

        /// <summary>
        /// Метод проверки столкновения объектов 
        /// </summary>
        /// <param name="o">объект столкновения</param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);

        /// <summary>
        /// метод регенерации объекта при столкновении
        /// </summary>
        public virtual void Regeneretion()
        {

        }
    }
}
