using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KidGame
{
    class Program
    {
        static int resultat;
        static bool result = false;
        static Random rand = new Random();
        static char operation;
        static int level = 0;
        static int winsInRow = 0;
        /*static int score = 0;
        static String calcul;*/
        

        static void Main(string[] args)
        {
                       
            Console.WriteLine("Hello Kids!");
            Console.WriteLine("Let's start");

            do 
             {
                setLevel();

                do
                {
                    Char operation = chooseOperation(level);
                    int number1 = chooseNumber(level);
                    int number2 = chooseNumber(level);
                    while (getResult(operation,number1,number2,level) == false )
                        {
                        number1 = chooseNumber(level);
                        number2 = chooseNumber(level);
                        getResult(operation,number1,number2,level);
                        }
                    Console.WriteLine("Niveau : " + level+" | Victoires consécutives = "+winsInRow);
                    Console.WriteLine(number1 + " " + operation + " " + number2 + " = ?");
                    string rep = Console.ReadLine();
                    if (rep =="")
                        {
                        Console.WriteLine("Erreur ! Essaye Encore");
                        Console.WriteLine(number1 + " " + operation + " " + number2 + " = ?");
                        rep = Console.ReadLine();
                        }
                    
                    int numericRep = Int32.Parse(rep);
                    verifyResult(numericRep);
                    Thread.Sleep(1500);
                    Console.Clear();

                } while (winsInRow < 5);

                winsInRow =0;
               

             } while (level <10);

        }

        static void setLevel()
        {
            level++;
            //TODO fonction qui retourne une string correspondant au niveau en prennant comme paramètre le nombre de victoire consécutive
            //Discuter s'il faut d'autres critères (Ex:nb de victoire dans un niveau) 
        }

        static char chooseOperation(int level)
        {
            //TODO choisir l'opération de type addition, multiplication
            int a = rand.Next() % 2;//Pour l'exemple du cours
            if (a == 0)
            {
                operation ='+';
            }
            if (a == 1)
            {
                operation ='-';
            }
            if (a == 2)
            {
                operation ='*';
            }
            if (a == 3)
            {
                operation ='/';
            }
            return operation;
        }

        static bool verifyResult(int res)
        {
            if (res == resultat)
            {
                result = true;
                winsInRow++;
                Console.WriteLine("Bonne réponse bravo!");
            }
            else
            {
                Console.WriteLine("Mauvaise réponse, essaye encore!");
                winsInRow = 0;
            }
            return (result);
        }

        static bool getResult(Char operation, int number1, int number2, int level)
        {
                bool valid = true;
                if (operation == 43)
                {
                    resultat = number1+number2;
                    
                }
                if (operation == 45)
                {
                    resultat = number1-number2;

                    if (number1<number2 & level < 3)
                    {
                        valid = false;
                        
                    }

               
                }

                if (operation == 42)
                {
                    resultat = number1*number2;

                    if (level <3)
                    {
                        valid = false; // TODO pb avec le * à regler
                    }
                }

                if (operation == 47)
                {
                    if ( number2 == 0 || number1%number2 != 0 || level < 4) // division par 0 ou division non entière 
                       {
                        valid = false;
                        Console.WriteLine("pb /");
                       }else
                        {
                         resultat = number1/number2;
                        }
                    
                }

                if (operation != 43 & operation != 42 & operation != 45 & operation != 47)
                {
                Console.WriteLine("operateur inconnu");
                }

                return valid;
        }

       /* static int CreateOperation(int level)
        {

            int[] nbTire = new int[level];
            char[] operateur = new char[level - 1];
            for (int i = 0; i <= level; i++)

            {
                int a = chooseNumber(level);
                calcul = calcul + a;
                nbTire[i] = a;
                if (i != level)

                {
                    calcul = calcul + operation;
                    operateur[i] = operation;
                }

                resultat = nbTire[0];

                for (int j = 0; j <= level; j++)

                {
                    if (operateur[j] == '+')
                    {
                        resultat = resultat + nbTire[i + 1];
                    }
                    if (operateur[j] == '-')
                    {
                        resultat = resultat - nbTire[i + 1];
                    }
                    if (operateur[j] == '*')
                    {
                        resultat = resultat * nbTire[i + 1];
                    }
                    //TODO A améliorer en prenant en compte le fait que resultat doit être entier , relancer le tirage si ce n'est pas le cas
                    if (operateur[j] == '/')
                    {
                        resultat = resultat / nbTire[i + 1];
                    }
                }
            }
        }*/

        static int chooseNumber(int level)

        {
            //TODO le faire en fonction du niveau choisit
            int num = rand.Next() % 10 * level;
            return num;

        }

    }
}
