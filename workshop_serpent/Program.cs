namespace workshop_serpent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Créer une liste de joueur, avec un nom, et un carctère à définir
             * dans la fonction Display, permettre d'afficher les plateaux des joueurs peu importe leur nombre
             * modifier les autres fonctions pour qu'elle s'applique peu importe le nombre de joueur */

            int positionPlayer1 = 0;
            char player1 = '@';
            char player2 = '#';
            int positionPlayer2 = 0;
            int positionEnd = 50;
            int resultDe;

            bool play = true;

            Console.WriteLine();

            while (play)
            {
                /* faire une méthode pour éviter la duplication de codes*/
                Display(positionPlayer1, positionPlayer2, player1, player2);
                resultDe = LancerDeDes();
                Console.WriteLine("Le joueur 1 a obtenu un {0}", resultDe);

                positionPlayer1 += resultDe;

                resultDe = LancerDeDes();
                Console.WriteLine("Le joueur 2 a obtenu un {0}", resultDe);

                positionPlayer2 += resultDe;

                play = IsFinish(positionPlayer1, positionPlayer2, positionEnd);

                positionPlayer1 = FallInTrap(positionPlayer1);
                positionPlayer2 = FallInTrap(positionPlayer2);

                positionPlayer1 = Bonus(positionPlayer1);
                positionPlayer2 = Bonus(positionPlayer2);


                Console.WriteLine("Position du joueur 1: {0}", positionPlayer1);
                Console.WriteLine("Position du joueur 2: {0}", positionPlayer2);
            }

        }
        public static int LancerDeDes()
        {
            Random rand = new Random();
            int resultat = rand.Next(1, 7);
            return resultat;
        }
        public static bool IsFinish(int positionPlayer1, int positionPlayer2, int positionEnd)
        {
            if (positionPlayer1 == positionEnd)
            {
                Console.WriteLine("Victoire pour le joueur 1");
                Console.WriteLine("Fin de partie");
                return false;
            } else if (positionPlayer2 == positionEnd)
            {
                Console.WriteLine("Victoire pour le joueur 2");
                Console.WriteLine("Fin de partie");
            }
            return true;
        }

        public static int FallInTrap(int positionPlayer)
        {
            if (positionPlayer == 37)
            {
                Console.WriteLine("Piège, vous retombez case 12");
                return 12;
            }
            if (positionPlayer == 14)
            {
                Console.WriteLine("Piège, vous retombez case 7");
                return 7;
            }
            if (positionPlayer == 46)
            {
                Console.WriteLine("Piège, vous retombez case 33");
                return 33;
            }

            if (positionPlayer > 50)
            {
                Console.WriteLine("Dommage, vous êtes allez trop loin, vous retombés case 25");
                return 25;
            }
            return positionPlayer;
        }
        public static int Bonus(int PositionPlayer)
        {
            if (PositionPlayer == 20)
            {
                Console.WriteLine("Bonus ! Vous allez directement case 35");
                return 35;
            }
            if (PositionPlayer == 2)
            {
                Console.WriteLine("Bonus ! Vous allez directement case 17");
                return 17;
            }
            if (PositionPlayer == 31)
            {
                Console.WriteLine("Bonus ! Vous allez directement case 43");
                return 35;
            }
            return PositionPlayer;
        }

        public static void Display(int positionPlayer1, int positionPlayer2, char player1, char player2)
        {
            char[] map = new char[50];
            Console.Write("Carte joueur 1 ");
            for (int j = 0; j < map.Length; j++)
            {

                Console.Write(' ');
                if (positionPlayer1 == j)
                {
                    Console.Write(player1);
                }
                else
                {
                    Console.Write('-');
                }
                Console.Write(' ');
            }
            Console.WriteLine();
            Console.Write("Carte joueur 2 ");
            for (int j = 0; j < map.Length; j++)
            {
                Console.Write(' ');
                if (positionPlayer2 == j)
                {
                    Console.Write(player2);
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
