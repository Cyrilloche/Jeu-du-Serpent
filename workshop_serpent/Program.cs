namespace workshop_serpent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int positionEnd = 50;

            List<string> listOfPlayers = ListOfPlayers();
            List<char> choiceOfChars = CharsOfPlayers(listOfPlayers);
            int[] positionOfPlayers = new int[listOfPlayers.Count];
            bool play = true;

            Console.WriteLine();

            while (play)
            {
                Display(listOfPlayers, positionOfPlayers, choiceOfChars);
                for (int i = 0; i < positionOfPlayers.Length; i++)
                {
                    Console.WriteLine("{0} débute le tour à la case {1}", listOfPlayers[i], positionOfPlayers[i]);
                }
                Move(listOfPlayers, positionOfPlayers);
                play = IsFinish(listOfPlayers,positionOfPlayers, positionEnd);
                FallInTrap(listOfPlayers, positionOfPlayers);
                Bonus(listOfPlayers, positionOfPlayers);
                for (int i = 0; i < positionOfPlayers.Length; i++)
                {
                    Console.WriteLine("{0} termine le cours à la case {1}", listOfPlayers[i], positionOfPlayers[i]);
                }
            }
        }

        public static List<string> ListOfPlayers()
        {
            int numberMaximumOfPlayers = 4;
            int numberOfPlayers = 0;
            bool exit = false;

            List<string> listOfPlayers = new List<string>();
            Console.WriteLine("Bienvenue dans le jeu du serpent !");

            while (!exit)
            {
                if(numberOfPlayers == numberMaximumOfPlayers)
                {
                    exit = true;
                    break;
                }
                Console.Write("Comment vous appelez vous :");
                string nameOfPlayer = Console.ReadLine();
                listOfPlayers.Add(nameOfPlayer);
                Console.WriteLine("Bienvenue à toi {0}", nameOfPlayer);
                numberOfPlayers++;
                Console.WriteLine("Y a-t-il d'autres joueurs ? y/n");
                string answer = Console.ReadLine();
                if (answer == "n")
                {
                    exit = true;
                    return listOfPlayers;
                }
            }
            return listOfPlayers;
        }
        public static List<char> CharsOfPlayers(List<string> listOfPlayers)
        {
            char char1 = '■';
            char char2 = '¶';
            char char3 = '%';
            char char4 = '#';

            int numberOfChoice = 0;

            List<char> choiceOfChars = [char1, char2, char3, char4];
            List<char> charsOfPlayers = new List<char>();

            Console.Write("Vous avez le choix entre 4 icônes pour jouer. Lequel voulez-vous ? 1, 2, 3, 4 ?\n");
            while (numberOfChoice != listOfPlayers.Count)
            {

                Console.WriteLine("{0} à toi de choisir ton icône !", listOfPlayers[numberOfChoice]);
                foreach (var icon in choiceOfChars)
                {
                    Console.Write(" " + icon + " ");
                }
                Console.WriteLine();
                Console.Write(" 1  2  3  4\nChoix :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        charsOfPlayers.Add(char1);
                        break;
                    case 2:
                        charsOfPlayers.Add(char2);
                        break;
                    case 3:
                        charsOfPlayers.Add(char3);
                        break;
                    case 4:
                        charsOfPlayers.Add(char4);
                        break;
                    default:
                        break;
                }
                numberOfChoice++;
            }
            return choiceOfChars;
        }
        public static int LancerDeDes()
        {
            Random rand = new Random();
            int resultat = rand.Next(1, 7);
            return resultat;
        }
        
        public static int[] Move(List<string> listOfPlayers, int[] moveOfPlayers)
        {
            int i = 0;
            foreach (var player in listOfPlayers)
            {
                int move = LancerDeDes();
                moveOfPlayers[i] += move;
                i++;
            }

            return moveOfPlayers;
        }

        public static bool IsFinish(List<string> listOfPlayers, int[] positionOfPlayers, int positionEnd)
        {
            bool victoire =false;
            for (int player = 0; player < listOfPlayers.Count; player++)
            {
                if (positionOfPlayers[player] == positionEnd)
                {
                    Console.WriteLine("Victoire pour {0}", listOfPlayers[player]);
                    victoire = true;
                    break;
                    
                }
            }
            if(victoire)
                return false;
            return true;
        }

        public static int[] FallInTrap(List<string> listOfPlayers, int[] positionOfPlayers)
        {
            for (int player = 0; player < listOfPlayers.Count; player++)
            {
                switch (positionOfPlayers[player])
                {
                    case 37:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 12", listOfPlayers[player]);
                        positionOfPlayers[player] = 12;
                        break;
                    case 14:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 7", listOfPlayers[player]);
                        positionOfPlayers[player] = 7;
                        break;
                    case 46:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 33", listOfPlayers[player]);
                        positionOfPlayers[player] = 33;
                        break;
                    case >50:
                        Console.WriteLine("Dommage {0}, vous êtes allez trop loin! Vous retombez à la case 25", listOfPlayers[player]);
                        positionOfPlayers[player] = 25;
                        break;
                    default:
                        break;
                }
            }
            return positionOfPlayers;
        }
        public static int[] Bonus(List<string> listOfPlayers, int[] positionOfPlayers)
        {
            for (int player = 0; player < listOfPlayers.Count; player++)
            {
                switch (positionOfPlayers[player])
                {
                    case 20:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 35", listOfPlayers[player]);
                        positionOfPlayers[player] = 35;
                        break;
                    case 2:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 17", listOfPlayers[player]);
                        positionOfPlayers[player] = 17;
                        break;
                    case 31:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 43", listOfPlayers[player]);
                        positionOfPlayers[player] = 43;
                        break;
                    default:
                        break;
                }
            }
            return positionOfPlayers;
        }

        public static void Display(List<string> listOfPlayers, int[] positionOfPlayers, List<char>choiceOfChars)
        {
            char[] map = new char[50];

            for (int player = 0; player < listOfPlayers.Count; player++)
            {
                for (int place = 0; place < map.Length; place++)
                {
                    Console.Write(' ');
                    if (positionOfPlayers[player] == place)
                    {
                        Console.Write(choiceOfChars[player]);
                    }
                    else
                    {
                        Console.Write('-');
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
