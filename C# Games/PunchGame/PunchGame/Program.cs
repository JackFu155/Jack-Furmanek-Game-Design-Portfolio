using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a puzzle game in which you need to have an exact number of moves to bring an enemy's health down to exactly zero

            Enemy e1 = new Enemy("Mel", 40);
            Enemy e2 = new Enemy("Ashton", 41);
            Enemy e3 = new Enemy("Rick", 42);
            Enemy e4 = new Enemy("Kimberly", 43);
            Enemy e5 = new Enemy("Annabelle", 44);
            Enemy e6 = new Enemy("Nordon", 45);
            Enemy e7 = new Enemy("Donovan", 46);
            Enemy e8 = new Enemy("Michael", 47);
            Enemy e9 = new Enemy("Ivan", 48);
            Enemy e10 = new Enemy("Chris", 49);
            Enemy e11 = new Enemy("Hayden", 50);
            Enemy e12 = new Enemy("Ellie", 51);
            Enemy e13 = new Enemy("Lynn", 52);
            Enemy e14 = new Enemy("Elle", 53);
            Enemy e15 = new Enemy("Ferdinand", 54);

            Console.WriteLine("Welcome to Punch-Out Exact Zero");
            Console.WriteLine("");
            Console.WriteLine("In each stage, you have a set of moves to use that inflict a set amount of damage");
            Console.WriteLine("You also have a limited number of turns to use these moves to bring down an enemy's health");
            Console.WriteLine("");
            Console.WriteLine("BE WARNED: You must get the enemy's health down to exactly Zero, any more or less will cause you to explode");
            Console.WriteLine("You also have to use all your moves as well or else you'll explode");
            Console.WriteLine("");
            Console.WriteLine("There are 3 levels with 5 stages each, good luck");
            Console.WriteLine("Plus, be sure to write down the names of the enemies you face and the steps you use to beat each stage");
            Console.WriteLine("");
            while(true)
            {
                Console.WriteLine("Pick a choice: ");
                Console.WriteLine("");
                Console.WriteLine("1 - Play");
                //Console.WriteLine("* Password");
                Console.WriteLine("2 - Quit");
                string Choice = Console.ReadLine();
                string choice = Choice.ToLower();
                if (choice == "1")
                {
                    int lives = 6;
                    Console.WriteLine("Level 1: Moveset and Damage Values:");
                    Console.WriteLine("");
                    Console.WriteLine("Punch - 4");
                    Console.WriteLine("Kick - 6");
                    Console.WriteLine("Bash - 7");
                    Console.WriteLine("");
                    
                    int t1a = 7;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 1: Stage 1 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    while (true)
                    {
                        Console.WriteLine("Stage 1: Enemy " + e1.Name + " has " + e1.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1a);
                       
                        Console.WriteLine("What do you do: Punch, Kick or Bash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if(r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e1.Name);
                            e1.TakeDamage(4);
                            t1a -= 1;
                            Console.WriteLine("");
                        }
                        else if(r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e1.Name);
                            e1.TakeDamage(6);
                            t1a -= 1;
                            Console.WriteLine("");
                        }
                        else if(r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e1.Name);
                            e1.TakeDamage(7);
                            t1a -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if(e1.Health == 0 && t1a == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e1.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if(e1.Health < 0 && t1a == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 40;
                            t1a = 7;
                        }
                        else if(e1.Health > 0 && t1a == 0)
                        {
                            Console.WriteLine("It didn't work, " + e1.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 40;
                            t1a = 7;
                        }
                        else if(e1.Health < 0 && t1a < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 40;
                            t1a = 7;
                        }
                    }
                    lives += 3;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 1: Stage 2 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1b = 6;

                    while (true)
                    {
                        Console.WriteLine("Stage 2: Enemy " + e2.Name + " has " + e2.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1b);

                        Console.WriteLine("What do you do: Punch, Kick or Bash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e2.Name);
                            e2.TakeDamage(4);
                            t1b -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e2.Name);
                            e2.TakeDamage(6);
                            t1b -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e2.Name);
                            e2.TakeDamage(7);
                            t1b -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e2.Health == 0 && t1b == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e2.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e2.Health < 0 && t1b == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 41;
                            t1b = 6;
                        }
                        else if (e2.Health > 0 && t1b == 0)
                        {
                            Console.WriteLine("It didn't work, " + e2.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 41;
                            t1b = 6;
                        }
                        else if (e2.Health < 0 && t1b < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e1.Health = 41;
                            t1b = 6;
                        }
                    }
                    lives += 3;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 1: Stage 3 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1c = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 3: Enemy " + e3.Name + " has " + e3.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1c);

                        Console.WriteLine("What do you do: Punch, Kick or Bash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e3.Name);
                            e3.TakeDamage(4);
                            t1c -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e3.Name);
                            e3.TakeDamage(6);
                            t1c -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e3.Name);
                            e3.TakeDamage(7);
                            t1c -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e3.Health == 0 && t1c == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e3.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e3.Health < 0 && t1c == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e3.Health = 42;
                            t1b = 7;
                        }
                        else if (e3.Health > 0 && t1c == 0)
                        {
                            Console.WriteLine("It didn't work, " + e1.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e3.Health = 42;
                            t1b = 7;
                        }
                        else if (e3.Health < 0 && t1c < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e3.Health = 42;
                            t1c = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 1: Stage 4 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1d = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 4: Enemy " + e4.Name + " has " + e4.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1d);

                        Console.WriteLine("What do you do: Punch, Kick or Bash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e4.Name);
                            e4.TakeDamage(4);
                            t1d -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e4.Name);
                            e4.TakeDamage(6);
                            t1d -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e4.Name);
                            e4.TakeDamage(7);
                            t1d -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e4.Health == 0 && t1d == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e4.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e4.Health < 0 && t1d == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e4.Health = 43;
                            t1d = 7;
                        }
                        else if (e4.Health > 0 && t1d == 0)
                        {
                            Console.WriteLine("It didn't work, " + e4.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e4.Health = 43;
                            t1d = 7;
                        }
                        else if (e4.Health < 0 && t1d < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e4.Health = 43;
                            t1d = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 1: Stage 5 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1e = 8;

                    while (true)
                    {
                        Console.WriteLine("Stage 5: Enemy " + e5.Name + " has " + e5.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1e);

                        Console.WriteLine("What do you do: Punch, Kick or Bash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e5.Name);
                            e5.TakeDamage(4);
                            t1e -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e5.Name);
                            e5.TakeDamage(6);
                            t1e -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e5.Name);
                            e5.TakeDamage(7);
                            t1e -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e5.Health == 0 && t1e == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e5.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e5.Health < 0 && t1e == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e5.Health = 44;
                            t1e = 8;
                        }
                        else if (e5.Health > 0 && t1e == 0)
                        {
                            Console.WriteLine("It didn't work, " + e5.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e5.Health = 44;
                            t1e = 8;
                        }
                        else if (e5.Health < 0 && t1e < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e5.Health = 44;
                            t1e = 8;
                        }
                    }
                    lives += 3;

                    Console.WriteLine("Level 1 Completed");
                    Console.WriteLine("");
                    Console.WriteLine("Level 2: Moveset and Damage Values:");
                    Console.WriteLine("");
                    Console.WriteLine("Punch - 4");
                    Console.WriteLine("Kick - 6");
                    Console.WriteLine("Bash - 7");
                    Console.WriteLine("Smash - 9");
                    Console.WriteLine("");

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 2: Stage 1 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1f = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 1: Enemy " + e6.Name + " has " + e6.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1f);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, or Smash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e6.Name);
                            e6.TakeDamage(4);
                            t1f -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e6.Name);
                            e6.TakeDamage(6);
                            t1f -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e6.Name);
                            e6.TakeDamage(7);
                            t1f -= 1;
                            Console.WriteLine("");
                        }
                        else if(r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e6.Name);
                            e6.TakeDamage(9);
                            t1f -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e6.Health == 0 && t1f == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e6.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e6.Health < 0 && t1f == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e6.Health = 45;
                            t1f = 8;
                        }
                        else if (e6.Health > 0 && t1f == 0)
                        {
                            Console.WriteLine("It didn't work, " + e6.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e6.Health = 45;
                            t1f = 8;
                        }
                        else if (e6.Health < 0 && t1f < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e6.Health = 45;
                            t1f = 8;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 2: Stage 2 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1g = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 2: Enemy " + e7.Name + " has " + e7.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1g);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, or Smash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e7.Name);
                            e7.TakeDamage(4);
                            t1g -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e7.Name);
                            e7.TakeDamage(6);
                            t1g -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e7.Name);
                            e7.TakeDamage(7);
                            t1g -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e7.Name);
                            e7.TakeDamage(9);
                            t1g -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e7.Health == 0 && t1g == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e7.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e7.Health < 0 && t1g == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e7.Health = 46;
                            t1g = 7;
                        }
                        else if (e7.Health > 0 && t1g == 0)
                        {
                            Console.WriteLine("It didn't work, " + e7.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e7.Health = 46;
                            t1g = 7;
                        }
                        else if (e7.Health < 0 && t1g < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e7.Health = 46;
                            t1g = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 2: Stage 3 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1h = 6;

                    while (true)
                    {
                        Console.WriteLine("Stage 3: Enemy " + e8.Name + " has " + e8.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1h);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, or Smash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e8.Name);
                            e8.TakeDamage(4);
                            t1h -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e8.Name);
                            e8.TakeDamage(6);
                            t1h -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e8.Name);
                            e8.TakeDamage(7);
                            t1h -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e8.Name);
                            e8.TakeDamage(9);
                            t1h -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e8.Health == 0 && t1h == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e8.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e8.Health < 0 && t1h == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e8.Health = 47;
                            t1h = 6;
                        }
                        else if (e8.Health > 0 && t1h == 0)
                        {
                            Console.WriteLine("It didn't work, " + e8.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e8.Health = 47;
                            t1h = 6;
                        }
                        else if (e8.Health < 0 && t1h < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e8.Health = 47;
                            t1h = 6;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 2: Stage 4 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1i = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 4: Enemy " + e9.Name + " has " + e9.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1i);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, or Smash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e9.Name);
                            e9.TakeDamage(4);
                            t1i -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e9.Name);
                            e9.TakeDamage(6);
                            t1i -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e9.Name);
                            e9.TakeDamage(7);
                            t1i -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e9.Name);
                            e9.TakeDamage(9);
                            t1i -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e9.Health == 0 && t1i == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e9.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e9.Health < 0 && t1i == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e9.Health = 48;
                            t1i = 7;
                        }
                        else if (e9.Health > 0 && t1i == 0)
                        {
                            Console.WriteLine("It didn't work, " + e9.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e9.Health = 48;
                            t1i = 7;
                        }
                        else if (e9.Health < 0 && t1i < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e9.Health = 48;
                            t1i = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 2: Stage 5 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1j = 6;

                    while (true)
                    {
                        Console.WriteLine("Stage 5: Enemy " + e10.Name + " has " + e10.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1j);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, or Smash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e10.Name);
                            e10.TakeDamage(4);
                            t1j -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e10.Name);
                            e10.TakeDamage(6);
                            t1j -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e10.Name);
                            e10.TakeDamage(7);
                            t1j -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e10.Name);
                            e10.TakeDamage(9);
                            t1j -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e10.Health == 0 && t1j == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e10.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e10.Health < 0 && t1j == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e10.Health = 49;
                            t1j = 6;
                        }
                        else if (e10.Health > 0 && t1j == 0)
                        {
                            Console.WriteLine("It didn't work, " + e10.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e10.Health = 49;
                            t1j = 6;
                        }
                        else if (e10.Health < 0 && t1j < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e10.Health = 49;
                            t1j = 6;
                        }
                    }
                    lives += 3;

                    Console.WriteLine("Level 2 Completed");
                    Console.WriteLine("");
                    Console.WriteLine("Level 3: Moveset and Damage Values:");
                    Console.WriteLine("");
                    Console.WriteLine("Punch - 4");
                    Console.WriteLine("Kick - 6");
                    Console.WriteLine("Bash - 7");
                    Console.WriteLine("Smash - 9");
                    Console.WriteLine("Crash - 11");
                    Console.WriteLine("");

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 3: Stage 1 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1k = 8;

                    while (true)
                    {
                        Console.WriteLine("Stage 1: Enemy " + e11.Name + " has " + e11.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1k);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, Smash, or Crash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e11.Name);
                            e11.TakeDamage(4);
                            t1k -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e11.Name);
                            e11.TakeDamage(6);
                            t1k -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e11.Name);
                            e11.TakeDamage(7);
                            t1k -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e11.Name);
                            e11.TakeDamage(9);
                            t1k -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "crash")
                        {
                            Console.WriteLine("You inflict 11 damage to " + e11.Name);
                            e11.TakeDamage(11);
                            t1k -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e11.Health == 0 && t1k == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e11.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e11.Health < 0 && t1k == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e11.Health = 50;
                            t1k = 8;
                        }
                        else if (e11.Health > 0 && t1k == 0)
                        {
                            Console.WriteLine("It didn't work, " + e11.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e11.Health = 50;
                            t1k = 8;
                        }
                        else if (e11.Health < 0 && t1k < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e11.Health = 50;
                            t1k = 8;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 3: Stage 2 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1l = 6;

                    while (true)
                    {
                        Console.WriteLine("Stage 2: Enemy " + e12.Name + " has " + e12.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1l);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, Smash, or Crash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e12.Name);
                            e12.TakeDamage(4);
                            t1l -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e12.Name);
                            e12.TakeDamage(6);
                            t1l -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e12.Name);
                            e12.TakeDamage(7);
                            t1l -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e12.Name);
                            e12.TakeDamage(9);
                            t1l -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "crash")
                        {
                            Console.WriteLine("You inflict 11 damage to " + e12.Name);
                            e12.TakeDamage(11);
                            t1l -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e12.Health == 0 && t1l == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e12.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e12.Health < 0 && t1l == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e12.Health = 51;
                            t1l = 6;
                        }
                        else if (e12.Health > 0 && t1l == 0)
                        {
                            Console.WriteLine("It didn't work, " + e12.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e12.Health = 51;
                            t1l = 6;
                        }
                        else if (e12.Health < 0 && t1l < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e12.Health = 51;
                            t1l = 6;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 3: Stage 3 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1m = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 3: Enemy " + e13.Name + " has " + e13.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1m);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, Smash, or Crash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e13.Name);
                            e13.TakeDamage(4);
                            t1m -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e13.Name);
                            e13.TakeDamage(6);
                            t1m -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e13.Name);
                            e13.TakeDamage(7);
                            t1m -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e13.Name);
                            e13.TakeDamage(9);
                            t1m -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "crash")
                        {
                            Console.WriteLine("You inflict 11 damage to " + e13.Name);
                            e13.TakeDamage(11);
                            t1m -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e13.Health == 0 && t1m == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e13.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e13.Health < 0 && t1m == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e13.Health = 52;
                            t1m = 7;
                        }
                        else if (e13.Health > 0 && t1m == 0)
                        {
                            Console.WriteLine("It didn't work, " + e13.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e13.Health = 52;
                            t1m = 7;
                        }
                        else if (e13.Health < 0 && t1m < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e13.Health = 52;
                            t1m = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 3: Stage 4 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1n = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 4: Enemy " + e14.Name + " has " + e14.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1n);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, Smash, or Crash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e14.Name);
                            e14.TakeDamage(4);
                            t1n -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e14.Name);
                            e14.TakeDamage(6);
                            t1n -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e14.Name);
                            e14.TakeDamage(7);
                            t1n -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e14.Name);
                            e14.TakeDamage(11);
                            t1n -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "crash")
                        {
                            Console.WriteLine("You inflict 11 damage to " + e14.Name);
                            e14.TakeDamage(9);
                            t1n -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e14.Health == 0 && t1n == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e14.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e14.Health < 0 && t1n == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e14.Health = 53;
                            t1n = 7;
                        }
                        else if (e14.Health > 0 && t1n == 0)
                        {
                            Console.WriteLine("It didn't work, " + e14.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e14.Health = 53;
                            t1n = 7;
                        }
                        else if (e14.Health < 0 && t1n < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e14.Health = 53;
                            t1n = 7;
                        }
                    }
                    lives += 3;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Level 3: Stage 5 /////////////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    int t1o = 7;

                    while (true)
                    {
                        Console.WriteLine("Stage 5: Enemy " + e15.Name + " has " + e15.Health + " health");

                        Console.WriteLine("Turns remaining: " + t1o);

                        Console.WriteLine("What do you do: Punch, Kick, Bash, Smash, or Crash");
                        string R1a = Console.ReadLine();
                        string r1a = R1a.ToLower();
                        if (r1a == "punch")
                        {
                            Console.WriteLine("You inflict 4 damage to " + e15.Name);
                            e15.TakeDamage(4);
                            t1o -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "kick")
                        {
                            Console.WriteLine("You inflict 6 damage to " + e15.Name);
                            e15.TakeDamage(6);
                            t1o -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "bash")
                        {
                            Console.WriteLine("You inflict 7 damage to " + e15.Name);
                            e15.TakeDamage(7);
                            t1o -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "smash")
                        {
                            Console.WriteLine("You inflict 9 damage to " + e15.Name);
                            e15.TakeDamage(9);
                            t1o -= 1;
                            Console.WriteLine("");
                        }
                        else if (r1a == "crash")
                        {
                            Console.WriteLine("You inflict 11 damage to " + e15.Name);
                            e15.TakeDamage(11);
                            t1o -= 1;
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Invalid response, please try again");
                            Console.WriteLine("");
                        }
                        if (e15.Health == 0 && t1o == 0)
                        {
                            Console.WriteLine("Congradulations, you beat " + e15.Name);
                            //Console.WriteLine("You gained 3 extra lives");
                            Console.WriteLine("Onward");
                            Console.WriteLine("");
                            break;
                        }
                        else if (e15.Health < 0 && t1o == 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e15.Health = 54;
                            t1o = 7;
                        }
                        else if (e15.Health > 0 && t1o == 0)
                        {
                            Console.WriteLine("It didn't work, " + e15.Name + " still has health left");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e15.Health = 54;
                            t1o = 7;
                        }
                        else if (e15.Health < 0 && t1o < 0)
                        {
                            Console.WriteLine("You went too far, you need to hit them exactly right");
                            Console.WriteLine("Please try again");
                            Console.WriteLine("");
                            lives -= 1;
                            e14.Health = 54;
                            t1o = 7;
                        }
                    }
                    lives += 3;



                    Console.WriteLine("Bonus Level: Now Type in the First letter of the names of each enemy in order with a space after all but the last letter");
                    string Bonus = Console.ReadLine();
                    string bonus = Bonus.ToLower();
                    if(bonus == "m a r k a n d m i c h e l e f")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Dear Mom and Dad,");
                        Console.WriteLine("");
                        Console.WriteLine("If you are reading this, it means you beat my game, and I hope you both enjoyed it. ");
                        Console.WriteLine("Take it as a sign that I'm doing well with my Gaming class and having fun with it. ");
                        Console.WriteLine("I am aware that you are both worried that I may lose my scholarship next year due to ");
                        Console.WriteLine("what happened in October, but let this game remind you that I'm doing well and am dedicated ");
                        Console.WriteLine("to my studies. I wouldn't have spent an entire day coding this game if this wasn't important to me.");
                        Console.WriteLine("I'm ready for whatever comes ahead, and I hope that this will calm your nerves.");
                        Console.WriteLine("");
                        Console.WriteLine("Loving you always and forever, your son");
                        Console.WriteLine("Jack");
                    }
                    else
                    {
                        Console.WriteLine("Too bad, please play again for another try");
                        Console.WriteLine("Hope you wrote down your solutions");
                        Console.WriteLine("Thanks for Playing");
                    }

                }
                /*else if (choice == "password")
                {

                }*/
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid response, please try again");
                    Console.WriteLine("");
                }
            }
            
        }
    }
}
