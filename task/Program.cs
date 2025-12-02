// small => 25
// large => 35
// salles rate  = 6%
// estimates are valid for 30 days

Console.WriteLine("Number of small carpets:");
int no_small = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Number of large carpets:");
int no_big = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Price per small room: $25");
Console.WriteLine("Price per large room: $35");
int cost = no_small * 25 + no_big * 35;
double rate =  0.06;
double tax = cost * rate;
double total = cost + tax;
Console.WriteLine("Cost: $" + cost);
Console.WriteLine("Tax: $" + tax);
Console.WriteLine("=================================");
Console.WriteLine("Total estimate: $" + total);
Console.WriteLine("This estimate is valid for 30 days.");

