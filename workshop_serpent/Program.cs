namespace workshop_serpent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*TO DO*/
            /* Créer une fonction qui ajoute dynamiquement un nombre de joueur en fonction du nombres de nom entrés */
            /* Refaire le fonction display*/

            //char player1 = '@';
            //char player2 = '#';
            int positionEnd = 50;

            List<string> listOfPlayers = new List<string>();
            listOfPlayers.Add("Leila");
            listOfPlayers.Add("Cyril");

            int[] positionOfPlayers = new int[listOfPlayers.Count];
            bool play = true;

            Console.WriteLine();

            while (play)
            {
                Move(listOfPlayers, positionOfPlayers);
                for (int i = 0; i < positionOfPlayers.Length; i++)
                {
                    Console.WriteLine("{0} a avancé(e) de {1} case(s)", listOfPlayers[i], positionOfPlayers[i]);
                }
                play = IsFinish(positionEnd, positionOfPlayers, listOfPlayers);
                FallInTrap(positionOfPlayers, listOfPlayers);
                Bonus(positionOfPlayers, listOfPlayers);
            }

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

        public static bool IsFinish(int positionEnd, int[] positionOfPlayers, List<string> listOfPlayers)
        {
            bool victoire =false;
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                if (positionOfPlayers[i] == positionEnd)
                {
                    Console.WriteLine("Victoire pour le joueur {0}", listOfPlayers[i]);
                    victoire = true;
                    break;
                    
                }
            }
            if(victoire)
                return false;
            return true;
        }

        public static int[] FallInTrap(int[] positionOfPlayers, List<string> listOfPlayers)
        {
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                switch (positionOfPlayers[i])
                {
                    case 37:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 12", listOfPlayers[i]);
                        positionOfPlayers[i] = 12;
                        break;
                    case 14:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 7", listOfPlayers[i]);
                        positionOfPlayers[i] = 7;
                        break;
                    case 46:
                        Console.WriteLine("Dommage {0}, vous tombez dans un piège. Retour à la case 33", listOfPlayers[i]);
                        positionOfPlayers[i] = 33;
                        break;
                    case >50:
                        Console.WriteLine("Dommage {0}, vous êtes allez trop loin! Vous retombez à la case 25", listOfPlayers[i]);
                        positionOfPlayers[i] = 25;
                        break;
                    default:
                        break;
                }
            }
            return positionOfPlayers;
        }
        public static int[] Bonus(int[] positionOfPlayers, List<string> listOfPlayers)
        {
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                switch (positionOfPlayers[i])
                {
                    case 20:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 35", listOfPlayers[i]);
                        positionOfPlayers[i] = 35;
                        break;
                    case 2:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 17", listOfPlayers[i]);
                        positionOfPlayers[i] = 17;
                        break;
                    case 31:
                        Console.WriteLine("Bonus pour {0}! Vous allez directment à la case 43", listOfPlayers[i]);
                        positionOfPlayers[i] = 43;
                        break;
                    default:
                        break;
                }
            }
            return positionOfPlayers;
        }

        //public static void Display(int positionPlayer1, int positionPlayer2, char player1, char player2)
        //{
        //    char[] map = new char[50];
        //    Console.Write("Carte joueur 1 ");
        //    for (int j = 0; j < map.Length; j++)
        //    {

        //        Console.Write(' ');
        //        if (positionPlayer1 == j)
        //        {
        //            Console.Write(player1);
        //        }
        //        else
        //        {
        //            Console.Write('-');
        //        }
        //        Console.Write(' ');
        //    }
        //    Console.WriteLine();
        //    Console.Write("Carte joueur 2 ");
        //    for (int j = 0; j < map.Length; j++)
        //    {
        //        Console.Write(' ');
        //        if (positionPlayer2 == j)
        //        {
        //            Console.Write(player2);
        //        }
        //        else
        //        {
        //            Console.Write('-');
        //        }
        //        Console.Write(' ');
        //    }
        //    Console.WriteLine();
        //}
    }
}
