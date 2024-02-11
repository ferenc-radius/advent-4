var watch = new System.Diagnostics.Stopwatch();
watch.Start();

var filePath = "configurations/input.cards";
var lines = File.ReadLines(filePath).ToArray();

var totalPoints = 0;
// Copies uses the fact that c# defaults everything to 0.
var copies = new int[lines.Length];

var i = 0;
foreach (var line in lines)
{
    var cards = line.Split(":")[1].Split("|");
    var winningCards = cards[0].Trim().Split(" ").Where(c=> c.Trim().Length > 0).ToArray();
    var yourCards = cards[1].Trim().Split(" ").Where(c=> c.Trim().Length > 0).ToArray();
    var wins = yourCards.Where(t => winningCards.Contains(t)).ToList();

    // The first match makes the card worth one point and each match after the first doubles the point value of that card.
    totalPoints +=  wins.Count > 0 ? (int) Math.Pow(2, wins.Count - 1) : 0;
 
    for (var j = i + 1; j < i + wins.Count + 1; j++)
    {
        // copies copy the wins too.
        copies[j] += 1 + copies[i];
    }
    
    i++;
}

var total = copies.Sum() + lines.Length;

Console.WriteLine($"part 1: {totalPoints}");
Console.WriteLine($"Total part 2: {total}");

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
Console.WriteLine("Time elapsed (ns): {0}", watch.Elapsed.TotalMilliseconds * 1000000);