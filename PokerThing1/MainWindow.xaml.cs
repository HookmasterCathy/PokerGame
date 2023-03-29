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

namespace PokerThing1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          

        }



        public List<ImageSource> Deck1 = new List<ImageSource>();
        public List<ImageSource> DiscardPile = new List<ImageSource>();
        public ImageSource OppHand1;
        public ImageSource OppHand2;
        
        

        public void StartDuelButton_Click(object sender, RoutedEventArgs e)
        {
           
            StartDuelButton.Visibility = Visibility.Hidden;
            List<ImageSource> Deck2 = new List<ImageSource>() { TwoOfClubs.Source, TwoOfDiamonds.Source, TwoOfHearts.Source, TwoOfSpades.Source, ThreeOfClubs.Source, ThreeOfDiamonds.Source, ThreeOfHearts.Source, ThreeOfSpades.Source, FourOfClubs.Source, FourOfDiamonds.Source, FourOfHearts.Source, FourOfSpades.Source, FiveOfClubs.Source, FiveOfDiamonds.Source, FiveOfHearts.Source, FiveOfSpades.Source, SixOfClubs.Source, SixOfDiamonds.Source, SixOfHearts.Source, SixOfSpades.Source, SevenOfClubs.Source, SevenOfDiamonds.Source, SevenOfHearts.Source, SevenOfSpades.Source, EightOfClubs.Source, EightOfDiamonds.Source, EightOfHearts.Source, EightOfSpades.Source, NineOfClubs.Source, NineOfDiamonds.Source, NineOfHearts.Source, NineOfSpades.Source, TenOfClubs.Source, TenOfDiamonds.Source, TenOfHearts.Source, TenOfSpades.Source, JackOfClubs.Source, JackOfDiamonds.Source, JackOfHearts.Source, JackOfSpades.Source, QueenOfClubs.Source, QueenOfDiamonds.Source, QueenOfHearts.Source, QueenOfSpades.Source, KingOfClubs.Source, KingOfDiamonds.Source, KingOfHearts.Source, KingOfSpades.Source, AceOfClubs.Source, AceOfDiamonds.Source, AceOfHearts.Source, AceOfSpades.Source };
            foreach(ImageSource s in Deck2)
            {
                Deck1.Add(s);
            }
                  
            
            Shuffle();
            Deal();



        }
        public void Deal()
        {
            if(Deck1.Count < 4)
            {
                ShuffleDiscardPile();
            }
            Hand1Art.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);

            Hand2Art.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);

            OppHand1 = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            OppHand2 = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);

            MessageBox.Text = "Would you like to see the Flop?";
            MessageBoxButton.Visibility = Visibility.Visible;
            
        }
        public void DealFlop()
        {
            if(Deck1.Count < 3)
            {
                ShuffleDiscardPile();
            }

            Flop1Art.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            Flop2Art.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            Flop3Art.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            MessageBox.Text = "Would you like to see the turn?";
        }
        public void DealTurn()
        {
            if (Deck1.Count == 0)
            {
                ShuffleDiscardPile();
            }
            TurnArt.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            MessageBox.Text = "Would you like to see the river?";
        }
        public void DealRiver()
        {
            if (Deck1.Count == 0)
            {
                ShuffleDiscardPile();
            }
            RiverArt.ImageSource = Deck1[0]; DiscardPile.Add(Deck1[0]); Deck1.Remove(Deck1[0]);
            MessageBox.Text = "Would you like to reveal the cards?";
        }
        public void EndRound()
        {
            OpponentsHand1Art.ImageSource = OppHand1;
            OpponentsHand2Art.ImageSource = OppHand2;

        }
        public String EvaluateYourHand()
        {
            
            string HandValue = "";
            List<String> CardsInPlay = new List<String>();
            CardsInPlay.Add(Hand1Art.ImageSource.ToString()); CardsInPlay.Add(Hand2Art.ImageSource.ToString()); CardsInPlay.Add(Flop1Art.ImageSource.ToString()); CardsInPlay.Add(Flop2Art.ImageSource.ToString()); CardsInPlay.Add(Flop3Art.ImageSource.ToString()); CardsInPlay.Add(TurnArt.ImageSource.ToString()); CardsInPlay.Add(RiverArt.ImageSource.ToString());
            int ticker = 0;
            
            List<String> ListOfValues = new List<String>() { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            List<String> ListOfSuits = new List<String>() { "Clubs", "Spades", "Diamonds", "Hearts" };
            //Flush?
            
            foreach(String flusher in ListOfSuits)
            {
                ticker = 0;
                foreach(String card in CardsInPlay)
                {
                    if (card.Contains(flusher)) { ticker++; }
                }
                if (ticker >= 5) { HandValue = " Flush "; return HandValue; }
            }
            
            //Four of a kind?
            foreach (String i in ListOfValues) 
            {
                ticker = 0;
                foreach(String j in CardsInPlay)
                {
                    if (j.Contains(i))
                    {
                        ticker++;
                    }
                    if(ticker == 4)
                    {
                        HandValue = ("Four of a kind: " + i);
                        return HandValue;
                    }
                }
            }




            return HandValue;
            
        }
        public void MessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Text == "Would you like to see the Flop?")
            {
                DealFlop();
            }
            else if(MessageBox.Text == "Would you like to see the turn?")
            {
                DealTurn();
            }
            else if(MessageBox.Text == "Would you like to see the river?")
            {
                DealRiver();
            }
            else if(MessageBox.Text == "Would you like to reveal the cards?")
            {
                EndRound();
            }
        }
        public void Shuffle()
        {
            List<ImageSource> Shuffled = new List<ImageSource>();
            Shuffled = Deck1;

            Random rnd = new Random();
            int doot = rnd.Next(5, 10);
            for (int i = 0; i < doot; i++)
            {
                List<ImageSource> half1 = new List<ImageSource>();
                List<ImageSource> half2 = new List<ImageSource>();

                int doodle = 0;

                foreach (ImageSource s in Shuffled)
                {
                    doodle = rnd.Next(0, 9);
                    if (doodle <= 4)
                    {
                        half1.Add(s);
                    }
                    else
                    {
                        half2.Add(s);
                    }
                }
                foreach (ImageSource s in half1) { half2.Add(s); }
                Shuffled = half2;
            }
            Deck1 = Shuffled;
        }
        public void ShuffleDiscardPile()
        {
            foreach(ImageSource s in DiscardPile)
            {
                Deck1.Add(s);
            }
            Shuffle();
            DiscardPile.Clear();
        }

        private void Debugger_Click(object sender, RoutedEventArgs e)
        {
            List<ImageSource> Deck2 = new List<ImageSource>() { TwoOfClubs.Source, TwoOfDiamonds.Source, TwoOfHearts.Source, TwoOfSpades.Source, ThreeOfClubs.Source, ThreeOfDiamonds.Source, ThreeOfHearts.Source, ThreeOfSpades.Source, FourOfClubs.Source, FourOfDiamonds.Source, FourOfHearts.Source, FourOfSpades.Source, FiveOfClubs.Source, FiveOfDiamonds.Source, FiveOfHearts.Source, FiveOfSpades.Source, SixOfClubs.Source, SixOfDiamonds.Source, SixOfHearts.Source, SixOfSpades.Source, SevenOfClubs.Source, SevenOfDiamonds.Source, SevenOfHearts.Source, SevenOfSpades.Source, EightOfClubs.Source, EightOfDiamonds.Source, EightOfHearts.Source, EightOfSpades.Source, NineOfClubs.Source, NineOfDiamonds.Source, NineOfHearts.Source, NineOfSpades.Source, TenOfClubs.Source, TenOfDiamonds.Source, TenOfHearts.Source, TenOfSpades.Source, JackOfClubs.Source, JackOfDiamonds.Source, JackOfHearts.Source, JackOfSpades.Source, QueenOfClubs.Source, QueenOfDiamonds.Source, QueenOfHearts.Source, QueenOfSpades.Source, KingOfClubs.Source, KingOfDiamonds.Source, KingOfHearts.Source, KingOfSpades.Source, AceOfClubs.Source, AceOfDiamonds.Source, AceOfHearts.Source, AceOfSpades.Source };
            foreach (ImageSource s in Deck2)
            {
                Deck1.Add(s);
            }
            Hand1Art.ImageSource = Deck1[0];
        }
    }


}

