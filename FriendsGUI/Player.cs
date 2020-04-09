using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FriendsGUI
{
    class Player
    {
        private const int VisitLimit = 8;

        public int Life = 100;

        public int Visits = 0;

        public bool LimitReached => Visits == VisitLimit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public static void UpdateStatus(string name)
        {
            MainWindow.Instance.NPCName.Content = "Name: " + name;
            MainWindow.Instance.Life.Content = "Your GPA: " + MainWindow.Player.Life;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/FriendsGUI;component/Resources/" + name + ".jpg", UriKind.Relative);
            image.EndInit();
            MainWindow.Instance.ProfilePicture.Source = image;
        }

        /// <summary>
        /// Decision Making Randomizer
        /// </summary>
        /// <param name="relation"></param>
        public void DecisionMaking(Extensions.Relation relation, Extensions.Location loc)
        {
            #region Button Processing

            RoutedEventHandler yesHandler = null;
            RoutedEventHandler noHandler = null;

            MainWindow.Instance.NoButton.Click += noHandler = (s, e) => {
                MainWindow.Instance.YesButton.Click -= yesHandler;
                MainWindow.Instance.NoButton.Click -= noHandler;

                // Code goes here
                if (relation == Extensions.Relation.Positive)
                {
                    Extensions.UpperBound -= 10;
                    if (Extensions.UpperBound < 50)
                    {
                        Extensions.UpperBound = 50;
                    }
                    Extensions.LowerBound -= 5;
                    if (Extensions.LowerBound > 0)
                    {
                        Extensions.LowerBound = 0;
                    }
                    MainWindow.Player.Life -= 10;

                    Location.Input(loc);
                }
                else
                {
                    Extensions.LowerBound += 10;
                    if (Extensions.LowerBound > 50)
                    {
                        Extensions.LowerBound = 49;
                    }
                    Extensions.UpperBound += 5;
                    if (Extensions.UpperBound > 100)
                    {
                        Extensions.UpperBound = 100;
                    }
                    MainWindow.Player.Life += 10;

                    Location.Input(loc);
                }
            };

            MainWindow.Instance.YesButton.Click += yesHandler = (s, e) => {
                MainWindow.Instance.YesButton.Click -= yesHandler;
                MainWindow.Instance.NoButton.Click -= noHandler;

                // Code goes here
                if (relation == Extensions.Relation.Positive)
                {
                    Extensions.LowerBound += 10;
                    if (Extensions.LowerBound > 50)
                    {
                        Extensions.LowerBound = 49;
                    }
                    Extensions.UpperBound += 5;
                    if (Extensions.UpperBound > 100)
                    {
                        Extensions.UpperBound = 100;
                    }
                    MainWindow.Player.Life += 10;

                    Location.Input(loc);
                }
                else
                {
                    Extensions.UpperBound -= 10;
                    if (Extensions.UpperBound < 50)
                    {
                        Extensions.UpperBound = 50;
                    }
                    Extensions.LowerBound -= 5;
                    if (Extensions.LowerBound > 0)
                    {
                        Extensions.LowerBound = 0;
                    }
                    MainWindow.Player.Life -= 10;

                    Location.Input(loc);
                }
            };

            #endregion
        }
    }
}