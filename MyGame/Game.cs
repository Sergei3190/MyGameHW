using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; // для вывода графики

namespace MyGame
{
    // основной класс, где будут происходить все действия игры

    #region
    // Для вывода графики на форму используется класс Graphic, который содержит методы для рисования на форме.
    // Чтобы убрать мерцание в игре, будем выводить графику в промежуточный буфер. Когда графический кадр сформирован, выводим его на экран методом Render.
    // Для получения графического буфера используется класс BufferedGraphicsManager и его свойство Current.
    // Для связи буфера и графики применяем метод Allocate.

    // Внесем изменения в класс с игрой.Здесь создадим массив объектов BaseObject. Чтобы не загромождать метод Init,
    // добавим дополнительно метод Load, в котором реализуем инициализацию наших объектов:

    // Добавим в метод Draw вывод всех этих объектов на экран, а также добавим метод Update для изменения состояния объектов.

    // Добавим в Init таймер и обработчик таймера, в котором заставим вызываться Draw и Update.

    #endregion


    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static List<Asteroid> _asteroids = new List<Asteroid>();
        private static List<Bullet> _bullets = new List<Bullet>();
        private static Pharmacy pharmacy;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        private static Timer timer = new Timer(); // вынесли из метода Init чтобы заработал метод Finish
        private static Random rnd = new Random();
        public static event LogGame LogEvent; // создали событие ведения журнала
        private static int count = 0;
        private static int List_length = 3;


        // Свойства
        // Ширина и высота игрового поля 
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// статический конструктор класса Game
        /// </summary>
        static Game()
        {

        }

        /// <summary>
        /// метод соединения игры с формой 
        /// </summary>
        /// <param name="form">форма</param>
        public static void Init (Form form)
        {
            // Графическое устройство для вывода графики 
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            if (form.ClientSize.Width >= 0 && form.ClientSize.Width <= 1000 && form.ClientSize.Height >= 0 && form.ClientSize.Height <= 1000)
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            LogEvent += Log.LogConsele;
            LogEvent += Log.LogFile;
            Load();
            timer.Interval = 100;
            if (timer.Interval <= 50) throw new GameObjectException($"Cлишком высокая скорость объектов");
            timer.Start();
            
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish; // добавили обработчик события для крушения коробля
            
        }

        /// <summary>
        /// обработчик движения коробля 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(3, 0), new Size(4, 1)));
            }

            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        static int i = 0;

        /// <summary>
        /// Обработчик таймера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            i++;

            int x = rnd.Next(30, 120);
            if (i >= x)
            {
                pharmacy = new Pharmacy(new Point(10, rnd.Next(10,Game.Height)), new Point(0, 0), new Size(15, 12));
                i = 0;
            }
            
            Draw();
            Update();

            #region !!!
            ////будем очищать принудительно память с помощью GC.Collect,но это не самый выгодный вариант, тк требуется много ресерсов для сбора и очистки.
            //if (i == 100)
            //{ GC.Collect(); i = 0; }
            #endregion
        }

        /// <summary>
        /// метод вывода объектов в форму 
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            foreach  (Bullet b in _bullets)
            {
                b?.Draw();
            }
            pharmacy?.Draw();
            _ship?.Draw();

            if (_ship != null)
                Buffer.Graphics.DrawString($"Energy: {_ship.Energy}",SystemFonts.DefaultFont, Brushes.White,0,0);

            Buffer.Graphics.DrawString($"Shot down: {count}", SystemFonts.DialogFont, Brushes.White, 0, 20);

            Buffer.Render();
        }

        /// <summary>
        /// метод вывода обновленного положения объектов в форму 
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }

            foreach (Bullet b in _bullets)
            {
                b?.Draw();
            }

            if (pharmacy != null)
            {
                if (_ship.Collision(pharmacy))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    _ship.EnergeUp(rnd.Next(1, 10));
                    pharmacy = null;
                    i = 0; 
                }
            }

            for (int i = 0; i < _asteroids.Count; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _bullets.RemoveAt(j);
                        j--;
                        count++;
                        LogEvent($"{DateTime.Now.ToString()} уничтожен {_asteroids} !!!");                   
                    }
                }

                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                else if(_asteroids[i] != null && _ship.Collision(_asteroids[i]))
                {
                    _ship?.EnergeLow(rnd.Next(1, 10));
                    System.Media.SystemSounds.Asterisk.Play();
                    _asteroids.RemoveAt(i);
                }

                if (_ship.Energy <= 0)
                {
                    _ship.Die();
                    LogEvent($"{DateTime.Now.ToString()} уничтожен {_ship} !!!");
                }
            }

            if (_asteroids == null)
            {
                List_length++;
                for (int i = 0; i < List_length; i++)
                {
                    int r = rnd.Next(0, 50);
                    _asteroids.Add(new Asteroid(new Point(1000, rnd.Next(0, maxValue: Height)), new Point(-r / 5, r), new Size(r, r)));
                }
            }


            #region HW3
            //    if (_asteroids[i] == null) continue;
            //    _asteroids[i].Update();
            //    if(_bullet != null && _bullet.Collision(_asteroids[i]))
            //    {
            //        System.Media.SystemSounds.Hand.Play();
            //        _asteroids[i] = null;
            //        _bullet= null;
            //        count++;
            //        LogEvent($"{DateTime.Now.ToString()} уничтожен {_asteroids} !!!");
            //        continue;
            //    }

            //    if (_ship.Collision(_asteroids[i]))
            //    {
            //        _ship?.EnergeLow(rnd.Next(1, 10));
            //        System.Media.SystemSounds.Asterisk.Play();

            //    }

            //    if (_ship.Energy <= 0)
            //    {
            //        _ship.Die();
            //        LogEvent($"{DateTime.Now.ToString()} уничтожен {_ship} !!!");
            //    }
            //}
            #endregion

            #region HW2
            //foreach  (Asteroid a in _asteroids)
            //{
            //    a.Update();

            //    if (a.Collision(_bullet))
            //    { SystemSounds.Hand.Play();
            //        a.Regeneretion();
            //        _bullet.Regeneretion();
            //    }
            //    _bullet.Update();
            //}
            #endregion
        }



            /// <summary>
            /// метод инициализации выводимых в форму объектов
            /// </summary>
            public static void Load()
        {
            _objs = new BaseObject[30];
            
            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, maxValue:Height)), new Point(-r, r), new Size(3, 3));
            }
            for (int i = 0; i < List_length; i++)
            {
                int r = rnd.Next(0, 50);
                _asteroids.Add( new Asteroid(new Point(1000, rnd.Next(0, maxValue: Height)), new Point(-r / 5, r), new Size(r, r)));
            }
    
            LogEvent($"{DateTime.Now.ToString()} инициализировали объекты формы");

            #region HW1
            //for (int i = 0; i < _objs.Length / 3; i++)
            //{
            //    //_objs[i] = new BaseObject(new Point(r.Next(800), i * 20), new Point(-i, -i), new Size(10, 10));
            //}
            //for (int i = _objs.Length / 3; i < _objs.Length - 10; i++)
            //{
            //    _objs[i] = new Star(new Point(600, i * 25), new Point(i, 0), new Size(5, 5));
            //}
            //for (int i = _objs.Length - 10; i < _objs.Length - 7; i++)
            //{
            //    _objs[i] = new Star_big(new Point(0, i * 2), new Point(i, i+2), new Size(20, 20));
            //}
            //for (int i = _objs.Length - 7; i < _objs.Length - 4; i++)
            //{
            //    _objs[i] = new Arc(new Point(700, 20), new Point(i / 2, -i ), new Size(60, 40));
            //}
            //for (int i = _objs.Length - 4; i < _objs.Length; i++)
            //{
            //    _objs[i] = new Star_dust(new Point(200, 100), new Point(i , -i*10 ), new Size(3, 3));
            //    _objs[_objs.Length - 1] = new Planet(new Point(600, 100), new Point(0, 0), new Size(50, 50));
            //}
            #endregion

        }

        /// <summary>
        /// метод гибели коробля
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString($"The end ", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White,200,100);
            Buffer.Render();
        }

    }
}
