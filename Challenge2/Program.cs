using System;
namespace Challenge2
{
    public class Program
    {
        public static List<int> dice = new List<int>();
        public static string path = $@"{Environment.CurrentDirectory}\diceRolls.csv";
        public static void Main()
        {
            if(File.Exists(path))
            {
                using StreamReader file = new StreamReader(path);
                string line;
                while((line = file.ReadLine()) != null)
                {
                    string[] temp = line.Split(',');
                    int[] parts = Array.ConvertAll(temp, s=> int.Parse(s));
                    dice.Add(parts[0]);
                }
                file.Close();
            }
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\n\n 1. Add Dice To List \n 2. analyse dice \n 3. save rolls \n 4. read rolls from file");
                var kp = Console.ReadKey().Key.ToString();
                switch(kp)
                {
                    case "D1":
                        Console.Clear();
                        rollDice();
                        Console.ReadKey();
                        continue;

                    case "D2":
                        Console.Clear();
                        diceAnalytics();
                        Console.ReadKey();
                        continue;
                    case "D3":
                        Console.Clear();
                        saveRolls();
                        Console.ReadKey();
                        continue;
                    case "D4":
                        Console.Clear();
                        Console.WriteLine(String.Join(',',readDice()));
                        Console.ReadKey();
                        continue;
                    default:
                        Console.Clear();
                        break;
                }
            }
            Console.WriteLine(" Thank you for using our app !");


        }
        // rolls the dice 
        static void  rollDice()
        {
            // rand is scoped to this function
            Random rand = new Random();
            Console.WriteLine(" enter number of dice you would like to roll");
            Console.Write(" > ");
            int diceNum;
            int.TryParse(Console.ReadLine(), out diceNum);
            if (diceNum <= 0 || diceNum >= 2501)
                return;
            for(int i = 0; i<diceNum; i++)
            {
            dice.Add(rand.Next(1,7));
            }
            while(true)
            {
                Console.WriteLine(" Would you like to roll again ?");
                Console.Write(" (y/n) > ");
                string choice = Console.ReadLine().ToUpper();
                if(choice == "Y" || choice == "YES")
                {
                    rollDice();
                }
                else if(choice == "N" || choice == "NO")
                {
                    Console.WriteLine(" Thank you for rolling");
                    return;
                }
                else 
                {
                    Console.WriteLine(" Error in input please try again !");
                }

            }
            
        }
        static void diceAnalytics()
        {
            int average = 0;
            int total = 0;
            foreach(var item in dice)
            {
                total += item;
            }
            string allDice = string.Format(" [ {0} ]", String.Join(',', dice));
            while(true)
            {
                Console.Clear();
                Console.WriteLine(" 1. Average Dice \n 2. Total Dice \n 3. Write all dice");
                var kp2 = Console.ReadKey().Key.ToString();
                switch(kp2)
                {
                    case "D1":
                        Console.Clear();
                        double t = (double) total;
                        int c = dice.Count();
                        double a = t /= (double) c;
                        average = (int) a; 
                        Console.WriteLine(average);
                        Console.ReadKey();
                        continue;
                    case "D2":
                        Console.Clear();
                        Console.WriteLine(total);
                        Console.ReadKey();
                        continue;

                    case "D3":
                        Console.Clear();
                        Console.WriteLine(allDice);
                        Console.ReadKey();
                        continue;
                    default:
                        return;
                }

            }
        } 

        static void saveRolls() 
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (var item in dice)
            {
                writer.WriteLine(String.Format("{0}", item));
            }
            writer.Close();

        }
        public static List<int> readDice() 
        {
            List<int> parts = new List<int>();
            StreamReader reader = new StreamReader(path);
            string line;
            while((line = reader.ReadLine())!=null)
            {
                    string[] temp = line.Split(',');
                    parts.Add(int.Parse(temp[0]));
            }
            reader.Close();
            return parts;
        }

    }
}