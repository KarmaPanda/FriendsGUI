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
using System.Threading;
using System.Windows.Threading;

namespace FriendsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        private static Player player;

        private const int NUMBEROFDAYS = 7;

        private static int currentDay = 1;

        internal static Player Player { get { return player; } set => player = value; }
        
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            Instance.Loaded += Instance_Initialized;
        }

        private void Instance_Initialized(object sender, EventArgs e)
        {
            Player = new Player
            {
                Visits = 0
            };

            Extensions.Visited = new List<Extensions.Location>();

            StartDay();
        }

        /*public static void GetControl(MainWindow window)
        {

        }*/

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Instance = null; // remove reference, so GC could collect it, but you need to be sure there is only one instance!!
        }

        /*public static void MainMethod()
        {
            StartDay();
        }*/

        public static void StartDay()
        {
            currentDay++;

            Player.Visits = 0;

            Extensions.Visited = new List<Extensions.Location>();

            if (currentDay >= 7)
            {
                GoodEnd();
            }

            Print("It is a new day of school. What could go wrong?");
            Extensions.Visited = new List<Extensions.Location>();

            Instance.YesButton.Visibility = Visibility.Hidden;
            Instance.NoButton.Visibility = Visibility.Hidden;
            Instance.Continue.Visibility = Visibility.Visible;

            RoutedEventHandler continueHandler = null;

            Instance.Continue.Click += continueHandler = (s, e) =>
            {
                Instance.Continue.Click -= continueHandler;
                Instance.Continue.Visibility = Visibility.Hidden;
                Location.Load(Extensions.Location.MainLobby);
            };
        }

        public static void DayEnd()
        {
            Print("The Bell rings! Time to go home! " + "Would you like to continue to the next day?");

            Instance.YesButton.Visibility = Visibility.Visible;
            Instance.NoButton.Visibility = Visibility.Visible;

            RoutedEventHandler yesHandler = null;
            RoutedEventHandler noHandler = null;

            Instance.YesButton.Click += yesHandler = (sender, eve) =>
            {
                Instance.YesButton.Click -= yesHandler;
                Instance.NoButton.Click -= noHandler;
                StartDay();
            };

            Instance.NoButton.Click += noHandler = (sender, eve) =>
            {
                Instance.YesButton.Click -= yesHandler;
                Instance.NoButton.Click -= noHandler;
                Application.Current.Shutdown();
            };
        }

        public static void GoodEnd()
        {
            Instance.YesButton.Visibility = Visibility.Hidden;
            Instance.NoButton.Visibility = Visibility.Hidden;
            Instance.Continue.Visibility = Visibility.Hidden;
            Instance.TravelButton.Visibility = Visibility.Hidden;
            Instance.LocationInput.Visibility = Visibility.Hidden;
            Instance.LocationList.Visibility = Visibility.Hidden;
            Instance.NPCName.Visibility = Visibility.Hidden;
            Instance.Life.Visibility = Visibility.Hidden;
            Print("Congrats you made it to the end of the 7th day! Your life: " + player.Life);
        }

        public static void BadEnd()
        {
            Instance.YesButton.Visibility = Visibility.Hidden;
            Instance.NoButton.Visibility = Visibility.Hidden;
            Instance.Continue.Visibility = Visibility.Hidden;
            Instance.TravelButton.Visibility = Visibility.Hidden;
            Instance.LocationInput.Visibility = Visibility.Hidden;
            Instance.LocationList.Visibility = Visibility.Hidden;
            Instance.NPCName.Visibility = Visibility.Hidden;
            Instance.Life.Visibility = Visibility.Hidden;
            Print("*police sirens* You get busted by the police");
        }

        public static void Print(string text)
        {
            Instance.Prompt.Text = text;
        }
    }
}
