using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CenterCoingame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random r = new Random();
            Program prog = new Program();
            int[] cashAmts = new int[4] { 10, 10, 10, 10 };
            int betAmt;
            string bet;
            String[] players = new String[4] { "A", "B", "C", "D" };
            int pooledAmt = cashAmts[0] + cashAmts[1] + cashAmts[2] + cashAmts[3];
            String playerWish = " ";
            Console.WriteLine("Lets start the Game!!!");

            while (players.Length != 1)
            {
                if (pooledAmt <= 0)
                {
                    Console.WriteLine("Amount in the Pool is zero or less. So taking amount from all players");
                    for (int i = 0; i < cashAmts.Length; i++)
                    {
                        pooledAmt = pooledAmt + 10;
                        cashAmts[i] = cashAmts[i] - 10;
                        Console.WriteLine($"Updated amount {players[i]} : {cashAmts[i]}");
                    }
                    Console.WriteLine("Start the fresh game...!!!");
                    Console.WriteLine(" ");
                }
                for (int i = 0; i < players.Length; i++)
                {
                    if (pooledAmt == 0)
                        break;

                    Console.WriteLine($"Its {players[i]}'s turn");
                    int coin1 = r.Next(1, 90);
                    int coin2 = r.Next(1, 90);
                    //Thread.Sleep(2000);
                    Console.WriteLine($"Here are your coins {coin1} and {coin2}");
                    Console.WriteLine($"Do you want to go for bet..Y or N?");
                    playerWish = Console.ReadLine();
                    Console.WriteLine(" ");
                    //Thread.Sleep(1500);
                    if (playerWish.Equals("Y"))
                    {
                        
                        Console.WriteLine("Place your bet...");
                        bet = Console.ReadLine();
                        betAmt = int.Parse(bet);
                        //Thread.Sleep(2000);
                        if (betAmt > cashAmts[i])
                        {
                            Console.WriteLine($"Sorry you exceeded amount you have!!!You have {cashAmts[i]} in your hand. So place amount below that");
                            Console.WriteLine(" ");
                            playerWish = null;
                            bet = null;
                            betAmt = 0;
                            continue;

                        }

                        else
                        {
                            int pickedCoin = r.Next(1, 90);
                            Console.WriteLine($"coin picked from box is {pickedCoin}");
                            //Thread.Sleep(2000);
                            if ((coin1 < pickedCoin && pickedCoin < coin2) || (coin2 < pickedCoin && pickedCoin < coin1))
                            {
                                Console.WriteLine("Great!!! you won the amount");
                                pooledAmt = pooledAmt - betAmt;
                                cashAmts[i] = cashAmts[i] + betAmt;
                                Console.WriteLine($"Now the amount you have in hand is {cashAmts[i]}");
                                Console.WriteLine($"Amount in the Pool is {pooledAmt}");
                                Console.WriteLine(" ");
                                playerWish = null;
                                bet = null;
                                betAmt = 0;
                                if (pooledAmt != 0)
                                    continue;
                                else
                                    break;


                            }
                            else
                            {
                                Console.WriteLine("Sorry you lost the deal!!!");
                                pooledAmt = pooledAmt + betAmt;
                                cashAmts[i] = cashAmts[i] - betAmt;
                                if (cashAmts[i] == 0)
                                {
                                    var list = new List<String>(players);
                                    list.Remove(players[i]);
                                    players = list.ToArray();
                                    var list1 = new List<int>(cashAmts);
                                    list1.Remove(cashAmts[i]);
                                    cashAmts = list1.ToArray();
                                    Console.WriteLine($"Now the amount you have in hand is 0");
                                    Console.WriteLine($"{players[i]} eliminated from the Match");
                                    Console.WriteLine(" ");
                                    i = i - 1;
                                    continue;

                                }
                                Console.WriteLine($"Now the amount you have in hand is {cashAmts[i]}");
                                Console.WriteLine($"Amount in the Pool is {pooledAmt}");
                                Console.WriteLine(" ");
                                playerWish = null;
                                bet = null;
                                betAmt = 0;
                                continue;

                            }

                        }

                    }
                    else
                    {
                        playerWish = null;
                        Console.WriteLine(" ");
                        continue;
                    }
                }

                Console.ReadKey();

            }

            Console.WriteLine($"Winner of this match is {players[0]}");
            Console.ReadKey();


        }
        public int ValueonDice()
        {

            Random r = new Random();
            int value = r.Next(1, 90);
            return value;

        }
    }
}
