using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Pokemon_Go_3080
{
    public interface IModel { }

    class Game_Model : IModel
    {
        private Player Player;
    }
    class Player : IModel
    {
        private Bag Bag;
        public int Level { private set; get; }
        public int Exp_Max { private set; get; }
        public int Exp { private set; get; }
        public int[,] Position { private set; get; }
        private Player()
        { }
        static private Player instance;
        static public Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();
                return instance;
            }
        }
        public int[,] Move()
        {
            //....
            return Position;
        }

    }
    class Bag : IModel
    {
        private List<Pokemon> MyPokemons;
    }
    class Typing_Game : IModel
    {

    }
    public abstract class Pokemon : IModel
    {
        public string name
        {
            private set; get;
        }
        public string type
        {
            private set;get;
        }
        // need a field for the image
        protected BitmapImage Pokemon_image;
        private int Hp_Maximum;
        public int Hp
        {
            private set; get;
        }
        public int Cp
        {
            private set; get;
        }
        public int Damage
        {
            private set; get;
        }

        public Pokemon()
        {
        }

        public abstract void Powerup();
        public abstract void Evolved();
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
        public void PlayerSetName(string name)
        {
            this.name = name;
        }
    }

    class Pichu: Pokemon
    { // Example
        private BitmapImage Pichu_Image = new BitmapImage(new Uri("image path"));
       
        private string type = "Pichu";
        public Pichu()
        {
        }
        public override void Powerup()
        {
            throw new NotImplementedException();
        }
        public override void Evolved()
        {
            Pichu_Image.UriSource = new Uri("/Pikachu_image.jpg");
           
           // convert from pichu to pikachu obj ??

        }
        
    }
    class Pikachu : Pokemon
    { // Example
        private BitmapImage Pikachu_Image = new BitmapImage();
        private string type = "Pikachu";
        public Pikachu()
        {
        }
        public override void Powerup()
        {
            throw new NotImplementedException();
        }

        public override void Evolved()
        {
            Pikachu_Image.UriSource = new Uri("/image.jpg");
            // Pikachu as Raicuh r;         
        }

    }
    class Battle_Gym : IModel
    {
        public delegate void Callback(Pokemon winner, Pokemon loser);
        private Pokemon My_Battle_Pokemon;
        private Pokemon Enemy_Pokemon;
        public Battle_Gym(Pokemon me, Pokemon enemy)
        {
            My_Battle_Pokemon = me;
            Enemy_Pokemon = enemy;
        }
        public void Attack(Pokemon src, Pokemon target, Callback callback)
        {
            // transfer each attack into deduction of health, and callback to the presenter if one pokemon "die"
            if (target.Deduct_Health(src.Damage))
            {
                callback(src, target);
            }
        }
    }
}
