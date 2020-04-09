using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace FriendsGUI
{
    class Extensions : Window
    {
        public static int UpperBound = 100;

        public static int LowerBound = 0;

        #region Names

        public static ArrayList Names = new ArrayList()
        {
            "Jordon",
            "Devan",
            "Camille",
            "Alden",
            "Derick",
            "Arden",
            "Steve",
            "Joe",
            "Alicia",
            "Brianna",
            "Courtney",
            "Jennifer",
            "Jonathan",
            "Serena",
            "Amanda",
            "Robert",
            "Sean",
            "Elizabeth",
            "Katherine",
            "Catherine",
            "Ryan",
            "Brian",
            "Bryan",
            "Kevin",
            "Claudia",
            "Adam",
            "Tony",
            "Irene",
            "Paulina",
            "Gary",
            "Justin",
            "Rickie",
            "Kyle",
            "Tim",
            "Timothy",
            "Michael",
            "Michelle",
            "Fred",
            "Eddie",
            "Nick",
            "Jason",
            "Helen",
            "Tiffany",
            "Daniel",
            "Dean",
            "Brandon",
            "Alice",
            "Patrick",
            "Richard",
            "Patricia",
            "Alex",
            "Sal",
            "Molly",
        };

        #endregion

        public static Location ConvertString(string name)
        {
            switch (name.ToLower())
            {
                case "bandroom":
                    return Location.Bandroom;
                case "bathroom":
                    return Location.Bathroom;
                case "ewing":
                    return Location.EWing;
                case "library":
                    return Location.Library;
                case "mathclass":
                    return Location.MathClass;
                case "englishclass":
                    return Location.EnglishClass;
                case "gym":
                    return Location.Gym;
                case "computerscience":
                    return Location.ComputerScience;
                case "cut":
                    return Location.Cut;
                case "lunchroom":
                    return Location.Lunchroom;
                default:
                    return Location.Null;
            }
        }

        public enum Location
        {
            MainLobby,
            Bandroom,
            Bathroom,
            EWing,
            Library,
            MathClass,
            EnglishClass,
            Gym,
            Cut,
            ComputerScience,
            Lunchroom,
            Null
        }

        public enum Relation
        {
            Positive, Negative
        }

        public static List<Location> NotVisted = new List<Location>()
        {
            Location.Bandroom,
            Location.Bathroom,
            Location.ComputerScience,
            Location.Cut,
            Location.EWing,
            Location.EnglishClass,
            Location.Gym,
            Location.Library,
            Location.MainLobby,
            Location.MathClass,
            Location.Lunchroom
        };

        public static List<Location> Visited = new List<Location>();

        public static Dictionary<Location, string> LocationDescription = new Dictionary<Location, string>()
        {
            {Location.MainLobby, "There are people rushing to class. You look around to see someone standing by the window. You walk over to them."},
            {Location.Library, "There are people sitting at the tables and computers. Some people are on their phones and you sit down as someone approaches." },
            {Location.Bandroom, "People are playing different songs. You listen to them when suddenly someone comes over to talk to you." },
            {Location.Bathroom, "You enter the bathroom and are hit by a huge vape cloud. The smoke clears and someone goes to talk to you." },
            {Location.ComputerScience, "People are sitting at their computers, some are goofing around but others are doing their work. Someone comes over to talk to you." },
            {Location.Cut, "You sneak out of school and pass the security guards. Then someone comes over to talk to you." },
            {Location.EWing, "You go in to the dimly lit hallway. You feel as if someone is watching you and then you get tapped on the shoulder." },
            {Location.EnglishClass, "There are people reading books, others just have their phones hidden behind their books. You get approached by someone." },
            {Location.Gym, "After you change into your uniform, you go out and see people playing basketball. You talk to someone standing around not playing." },
            {Location.MathClass, "You walk in and see people working on trig problems. You sit down at an open seat and the kid next to you begins to talk to you" },
            {Location.Lunchroom, "You wait on the line to get your school lunch. You start eating when suddenly someone walks towards you." }
        };
        /*public static Dictionary<string, Relation> Interactions = new Dictionary<string, Relation>()
        {
            {"Do you want to study?", Relation.Positive},
            {"I'm going to Math Class", Relation.Positive},
            {"Can you tutor me in Math?", Relation.Positive},
            {"I need help with homework, can you help?", Relation.Positive},
            {"How are you today? I'm headed to the library.", Relation.Positive},
            {"Wanna hit?", Relation.Negative},
            {"Can I have the homework?", Relation.Negative},
            {"You want to cut last period? \n Come on it's fine", Relation.Negative},
            {"My friend can get us some of the good stuff.", Relation.Negative}
        };*/

        public static List<string> PositiveInteractions = new List<string>()
        {
            "Do you want to study?",
            "I'm going to math class",
            "Can you tutor me in math?",
            "I need help with homework, can you help?",
            "How are you today? I'm headed to the library.",
            "Hey wanna hang out and chill? Do movies sound good?",
            "Hey I'm headed to study hall, want to join me?",
            "Want to join me for a jog after school?",
            "Can you help me with this bug in my program? I can't figure it out.",
            "Do you know crack is wack?",
            "Will you come to the S.O. meeting this week?",
            "Wanna join my club? You can meet nice people and have lots of fun.",
            "Wanna come to my house after school and do the project together?",
            "I am going to go to the after school tutoring. Do you want to come too?",
            "Want to volunteer for the walk on Sunday? We can get service credits."
        };

        public static List<string> NegativeInteractions = new List<string>()
        {
            "Wanna hit?",
            "Can I have the homework?",
            "You want to cut last period? Come on it's fine",
            "My friend can get us some of the good stuff.",
            "Yo, wassup mah homie, wanna head out back and hit one together",
            "Wanna hang with da squad? We planning to cut period 4",
            "Psst! Over here. I got some of that good s**t. $5 per bag. Just try it. It is not that bad.",
            "You have any pills on you?",
            "Come join our gang. We are going to go to prank the principal.",
            "Come to my party Friday night. We are gonna get so wasted.",
            "Come hang at my house later. We gonna take turns taking a hit.",
            "Cut last period with me. We can go to my house and burn this biology textbook.",
            "Come to the bathroom with me. I got a friend who can hook us up with the stuff.",
            "Do you want to cut and prank call the school with me?",
            "I heard one of the teachers got tickets to the Bieber concert. We should try to steal them."
        };
    }
}