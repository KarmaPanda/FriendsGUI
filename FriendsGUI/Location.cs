using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace FriendsGUI
{
    class Location : Window
    {
        /// <summary>
        /// Loads in the location given the parameter. Essentially starts a new day.
        /// </summary>
        /// <param name="loc"></param>
        public static void Load(Extensions.Location loc)
        {
            Extensions.Visited.Add(loc);
            MainWindow.Player.Visits += 1;

            MainWindow.Instance.Period.Visibility = Visibility.Visible;
            MainWindow.Instance.Prompt.Visibility = Visibility.Visible;
            MainWindow.Instance.YesButton.Visibility = Visibility.Hidden;
            MainWindow.Instance.NoButton.Visibility = Visibility.Hidden;
            MainWindow.Instance.NPCName.Visibility = Visibility.Hidden;
            MainWindow.Instance.ProfilePicture.Visibility = Visibility.Hidden;
            MainWindow.Instance.Life.Visibility = Visibility.Hidden;

            MainWindow.Instance.Period.Content = "Period: " + MainWindow.Player.Visits;

            if (MainWindow.Player.LimitReached)
            {
                MainWindow.DayEnd();
                return;
            }

            if (MainWindow.Player.Life == 0)
            {
                MainWindow.BadEnd();
                return;
            }

            // E-Wing Specific Code
            if (loc == Extensions.Location.EWing)
            {
                MainWindow.Player.Life -= 10;

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
            }

            if (loc == Extensions.Location.Cut)
            {
                MainWindow.Player.Life -= 20;

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
                
                MainWindow.DayEnd();

                return;
            }

            // Prints out the location description
            if (Extensions.LocationDescription.ContainsKey(loc))
            {
                MainWindow.Instance.Continue.Visibility = Visibility.Visible;

                MainWindow.Print(Extensions.LocationDescription[loc]);

                RoutedEventHandler continueHandler = null;

                MainWindow.Instance.Continue.Click += continueHandler = (s, e) =>
                {
                    MainWindow.Instance.Continue.Click -= continueHandler;

                    MainWindow.Instance.YesButton.Visibility = Visibility.Visible;
                    MainWindow.Instance.NoButton.Visibility = Visibility.Visible;
                    MainWindow.Instance.Continue.Visibility = Visibility.Hidden;
                    Friend(loc);
                };
            }
            else
            {
                return;
            }

            #region Console Version

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loc"></param>
        public static void Friend(Extensions.Location loc)
        {
            #region Friend

            // Creates friend and randomizes the output

            var friend = new Friend();
            var random = new Random().Next(0, 49);
            friend.Name = (string)Extensions.Names[random];
            random = new Random().Next(Extensions.LowerBound, Extensions.UpperBound);

            // Update Status and Unhide Status
            Player.UpdateStatus(friend.Name);
            MainWindow.Instance.Period.Visibility = Visibility.Hidden;
            MainWindow.Instance.NPCName.Visibility = Visibility.Visible;
            MainWindow.Instance.Life.Visibility = Visibility.Visible;
            MainWindow.Instance.ProfilePicture.Visibility = Visibility.Visible;

            if (random > 50)
            {
                random = new Random().Next(0, Extensions.PositiveInteractions.Count);

                // Print Interaction
                MainWindow.Print(Extensions.PositiveInteractions[random]);
                MainWindow.Player.DecisionMaking(Extensions.Relation.Positive, loc);
            }
            else
            {
                random = new Random().Next(0, Extensions.NegativeInteractions.Count);

                // Print Interaction
                MainWindow.Print(Extensions.NegativeInteractions[random]);
                MainWindow.Player.DecisionMaking(Extensions.Relation.Negative, loc);
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loc"></param>
        public static void Input(Extensions.Location loc)
        {
            #region Input

            if (MainWindow.Player.LimitReached)
            {
                MainWindow.DayEnd();
            }

            //String printResult = "Where do you want to go next:";

            // Hides Yes and No Buttons and Displays Location Input
            MainWindow.Instance.YesButton.Visibility = Visibility.Hidden;
            MainWindow.Instance.NoButton.Visibility = Visibility.Hidden;
            MainWindow.Instance.Continue.Visibility = Visibility.Hidden;
            MainWindow.Instance.Prompt.Visibility = Visibility.Hidden;
            //MainWindow.Instance.LocationInput.Visibility = Visibility.Visible;

            // TODO: Fix last comma
            /*foreach (var place in Extensions.NotVisted.Except(Extensions.Visited))
            {
                printResult = printResult + " " + place + ",";
            }

            MainWindow.Print(printResult);*/

            MainWindow.Instance.LocationList.Visibility = Visibility.Visible;
            MainWindow.Instance.TravelButton.Visibility = Visibility.Visible;

            List<Extensions.Location> locations = new List<Extensions.Location>();

            foreach (var place in Extensions.NotVisted.Except(Extensions.Visited))
            {
                locations.Add(place);
            }

            MainWindow.Instance.LocationList.ItemsSource = locations;

            RoutedEventHandler handler = null;

            MainWindow.Instance.TravelButton.Click += handler = (s, e) =>
            {
                var location = MainWindow.Instance.LocationList.SelectedItem;

                
                if (location == null)
                {

                }
                else
                {
                    var invalid = Extensions.Visited.FindAll(l => (Extensions.Location)location == l).Any();

                    MainWindow.Instance.TravelButton.Click -= handler;
                    
                    // Hide all of the buttons
                    MainWindow.Instance.YesButton.Visibility = Visibility.Hidden;
                    MainWindow.Instance.NoButton.Visibility = Visibility.Hidden;
                    MainWindow.Instance.TravelButton.Visibility = Visibility.Hidden;
                    MainWindow.Instance.LocationList.Visibility = Visibility.Hidden;

                    // Loads the new location
                    Load((Extensions.Location) location);
                }

                //var location = Extensions.ConvertString(input);

                /*if (invalid || location == Extensions.Location.Null)
                {
                    MainWindow.Instance.LocationInput.Text = "Invalid Location";
                }*/
            };

            #endregion
        }
    }
}