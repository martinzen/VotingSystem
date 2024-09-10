using System.Linq;

namespace Sandbox
{

    public class Counter
    {
        private string? _name;
        private double? _percentage;

        public Counter(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        public int Count { get; private set; }
      

        public double GetPercent( int total) => _percentage ?? (_percentage = Math.Round(Count * 100.0 / total, 2)).Value;
        

        public void AddExcess(double excess) => _percentage += excess;
        
    }


    public class CounterManager 
    {
        // params check on chatGPT
        public CounterManager(params Counter[] counters) 
        {
            Counters = new List<Counter>(counters);
        }

        public List<Counter> Counters { get; set; }

        public int Total() => Counters.Sum( x => x.Count);

        public double TotalPercentage() => Counters.Sum(x => x.GetPercent(Total()));

        /* same like above
         int total = 0;
         foreach (var c in Counters)
         {
             total += c.Count;
         }
         return total;
         */

        public void AnnounceWinner() 
        {

            /* this is for that public double TotalPercentage() => Counters.Sum(x => x.GetPercent(Total()));
            var yesPercent = yes.GetPercent(manager.Total());
            var noPercent = no.GetPercent(manager.Total());
            var maybePercent = maybe.GetPercent(manager.Total());
            */


            var excess = Math.Round(100 - TotalPercentage(), 2);

           // Console.WriteLine($"Excess:{excess}");

            var biggestAmountOfVoters = Counters.Max(x => x.Count);

            var winners = Counters.Where(x => x.Count == biggestAmountOfVoters).ToList();

            if (winners.Count == 1)
            {
                var winner = winners.First();
                winner.AddExcess(excess);
                Console.WriteLine($"{winner.Name} Won!");
            }
            else
            {
                if (winners.Count != Counters.Count)
                {

                    var lowestAmountOfVotes = Counters.Min(x => x.Count);
                    var loser = Counters.First(x => x.Count == biggestAmountOfVoters);
                    loser.AddExcess(excess);
                   
                }
                Console.WriteLine(string.Join("-DRAW-", winners.Select(x => x.Name)));
               
                /*
                if (winners.Count == Counters.Count)
                {
                    string.Join(" -DRAW- ", winners.Select(x => x.Name));
                }
                string.Join(" -DRAW- ", winners.Select(x => x.Name));
                */
            }

            /*

            if (yes.Count > no.Count)
            {
                if (yesPercent > maybe.Count)
                {
                    Console.WriteLine($"Winner {yes.Name}");
                    yesPercent += excess;
                }
                else if (maybe.Count > yes.Count)
                {
                    Console.WriteLine("Winner maybe Percent");
                    maybePercent += excess;
                }
                else
                {
                    Console.WriteLine("Yes- Draw -Maybe");
                    noPercent += excess;
                }
            }
            else if (no.Count > yes.Count)
            {
                if (no.Count > maybe.Count)
                {
                    Console.WriteLine("Winner No");
                    noPercent += excess;
                }

                else if (maybe.Count > no.Count)
                {

                    Console.WriteLine("Winner maybe Percent");
                    maybePercent += excess;
                }
                else
                {
                    Console.WriteLine($"No- Draw -Maybe");
                    yesPercent += excess;
                }

            }
            else
            {
                if (maybe.Count > yes.Count)
                {
                    Console.WriteLine("Maybe Won");
                    maybePercent += excess;
                }
                else if (maybe.Count == yes.Count)
                {
                    Console.WriteLine($"No- Draw - Yes  -Draw - Maybe");

                }
                else
                {
                    Console.WriteLine($"No- Draw - Yes");
                    maybePercent += excess;
                }
            }

            foreach (var c in Counters) 
            {
                Console.WriteLine($"{c.Count}, Counts {c.Count}, Percentage: {c.GetPercent(Total())}%");
            }

            */

            foreach (var c in Counters)
            {

                Console.WriteLine($"{c.Name} Counts {c.Count}, Percentage: {c.GetPercent(Total())}%");

                /*
                Console.WriteLine($"Yes Counts {yes.Count}, Percentage: {Math.Round(yesPercent, 2)}%");
                Console.WriteLine($"No Counts {no.Count},  Percentage: {Math.Round(noPercent, 2)}%");
                Console.WriteLine($"Maybe Counts {maybe.Count},  Percentage: {Math.Round(maybePercent, 2)}%");
                Console.WriteLine($"Total Precentage:{Math.Round(yesPercent + noPercent + maybePercent, 2)}");
                */
            }
            Console.WriteLine($"Total Precentage:{Math.Round(TotalPercentage(), 2)}");
         
        }
    }

    internal class Program
    {

     
        static void Main(string[] args)
        {
            var yes = new Counter("Yes", 3);
            var no = new Counter("No", 3);
            var maybe = new Counter("Maybe",3 );
            var hopefully = new Counter("hopefully", 3);


            var manager = new CounterManager(yes, no, maybe, hopefully);

            // int total = yes.Count + no.Count + maybe.Count;

            manager.AnnounceWinner();
        }
    }
}
