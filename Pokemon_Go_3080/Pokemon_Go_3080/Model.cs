using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Pokemon_Go
{
    class Game_Model
    {
        public static List<double> Exist_Position = new List<double>();
        static Boolean Exist = false;
        public Player Player { get; private set; }
        public List<Pokemon_Stop> Pokemon_Stops { get; private set; }
        public Game_Model()
        {
            if (!Exist)
            {
                Player = new Player();
                Exist = true;
                Pokemon_Stops = new List<Pokemon_Stop>();
                for(int i=0; i<3; i++)
                {
                    Pokemon_Stops.Add(new Pokemon_Stop());
                }
            }
        }
    }
    class Pokemon_Stop
    {
        public double Position { get; private set; }
        private DispatcherTimer Timer;
        private int Count;
        private Boolean Explored;
        private Random rnd = new Random();
        public Pokemon_Stop()
        {
            Count = 10;
            Explored = false;
            double temp = (double)rnd.Next(30,470);
            while (Game_Model.Exist_Position.Contains(temp)){
                temp = (double)rnd.Next(30,470);
            }
            Position = temp;
            Game_Model.Exist_Position.Add(Position);
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1.0);
            Timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Count--;
            if(Count == 0)
            {
                Explored = false;
                Timer.Stop();
            }
        }
        public int Explore_Stop()
        {
            int num = rnd.Next(1, 3);
            Count = 10;
            Timer.Start();
            Explored = true;
            return num;
        }
    }
    class Player 
    {
        public Bag Bag { get; private set; }
        public double Position { get; private set; }
        public int Level { get; private set; }
        public int EXP { get; private set; }
        public int EXP_Max { get; private set; }
        public Player()
        {
            Bag = new Bag();
            Position = 0.0;
            Level = 1;
            EXP = 0;
            EXP_Max = 10;
        }
        public void MoveRight(double x, double max)
        {
            if(Position + x <= max)
            {
                Position += x;
            }
        }
        public void MoveLeft(double x, double min)
        {
            if(Position - x >= min)
            {
                Position -= x;
            }
        }
    }
    class Bag 
    {
        private List<Pokemon> MyPokemons;
    }
    class Typing_Game 
    {

    }
    class Pokemon 
    {
        public string name { get; private set; }
        public string type { get; private set; }
        // need a field for the image
        public int Hp_Maximum { get; private set; }
        public int Hp { get;  private set; }
        public int Cp { get; private set; }
        public int Damage { get; private set; }
        public string skill;
        public Pokemon()
        { }

        public virtual void Powerup() { }
        public virtual void Envolved() { }
        public bool Deduct_Health(int deduct_num)
        {
            // Deduct the health, after the operation, return true is Hp <= 0
            Hp -= deduct_num;
            if (Hp <= 0)
            {
                Hp = 0;
                return true;
            }
            return false;
        }
        
    }
    class Pichu : Pokemon
    { 
        private BitmapImage Pichu_Image = new BitmapImage(new Uri("Resources/pichu.png"));
       // private Random rnd = new Random();
        public new string name;
        public new string type = "Pichu";
        public new int Hp = 30;
        public new int Cp = 24;
        public new int Hp_Maximum = 200;
        public new string skill = "Electrical shock";
        public Pichu(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 30;
            Cp = Cp + 25;
        }
        public override void Envolved()
        {
            type = "Pikachu";
            Hp_Maximum = 400;
            skill = "Powered Electrical shock";
        }

    }
    class Pikachu : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage(new Uri("Resources/pikachu.png"));
       // private Random rnd = new Random();
        public new string name;
        public new string type = "Pikachu";
        public new int Hp = 30;
        public new int Cp = 24;
        public new int Hp_Maximum = 400;
        public new string skill = " Powered Electrical shock";
        public Pikachu(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 50;
            Cp = Cp + 30;
        }
        public override void Envolved()
        {      }

    }
    class Charmander : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage(new Uri("Resources/charmander.png"));
        // private Random rnd = new Random();
        public new string name;
        public new string type = "Charmander";
        public new int Hp = 25;
        public new int Cp = 40;
        public new int Hp_Maximum = 180;
        public new string skill = "Fireball";
        public Charmander(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 27;
            Cp = Cp + 13;
        }
        public override void Envolved()
        {
            type = "Charmeleon";
            Hp_Maximum = 450;
            skill = "Fire tornado";
        }

    }

    class Charmeleon : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage(new Uri("Resources/charmeleon.png"));
        // private Random rnd = new Random();
        public new string name;
        public new string type = "Charmeleon";
        public new int Hp = 120;
        public new int Cp = 70;
        public new int Hp_Maximum = 450;
        public new string skill = "Fire tornado";
        public Charmeleon(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 20;
            Cp = Cp + 33;
        }
        public override void Envolved()
        {
        }

    }
    class Squirtle : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage(new Uri("Resources/squirtle.png"));
        // private Random rnd = new Random();
        public new string name;
        public new string type = "Charmander";
        public new int Hp = 23;
        public new int Cp = 22;
        public new int Hp_Maximum = 190;
        public new string skill = "Waterfall";
        public Squirtle(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 34;
            Cp = Cp + 23;
        }
        public override void Envolved()
        {
            type = "wartortle";
            Hp_Maximum = 380;
            skill = "Water canon";
        }

    }
    class Wartortle : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage(new Uri("Resources/charmander.png"));
        // private Random rnd = new Random();
        public new string name;
        public new string type = "Wartortle";
        public new int Hp = 25;
        public new int Cp = 40;
        public new int Hp_Maximum = 180;
        public new string skill = "Water canon";
        public Wartortle(string name)
        { this.name = name; }
        public override void Powerup()
        {
            if (Hp != Hp_Maximum)
                Hp = Hp + 27;
            Cp = Cp + 13;
        }
        public override void Envolved()
        {

        }

    }


 
    class Battle_Gym 
    {
        public delegate void Callback(Pokemon winner, Pokemon loser);
        public Pokemon My_Battle_Pokemon { get; private set; }
        public Pokemon Enemy_Pokemon { get; private set; }
        public Battle_Gym(Pokemon me, Pokemon enemy)
        {
            My_Battle_Pokemon = me;
            Enemy_Pokemon = enemy;
        }
        public void Attack(Pokemon src,Pokemon target, Callback callback)
        {
            // transfer each attack into deduction of health, and callback to the presenter if one pokemon "die"
            if (target.Deduct_Health(src.Damage))
            {
                callback(src, target);
            }
        }
    }
}
