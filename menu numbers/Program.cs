List<int> arr = [];


Console.WriteLine("Main Menu");
Console.WriteLine("""
    p- print numbers
    a- add a number
    h- display mean of the number
    s- display the smallest number
    l- display the largest number
    f- find a number
    c- clear the whole list
    q- quite
    >>>>
    """);
bool isQuite = false;
while (!isQuite)
{
    Console.WriteLine("Choose an operation from the menu");
    String input = Console.ReadLine();
    switch (input.ToLower())
    {
        case "p":
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");
            }
            else
            {
                Console.WriteLine("[ "+string.Join(" ",arr)+" ]");
            }
                break;
        case "a":
            Console.WriteLine("Enter the number");
            int newItem = Convert.ToInt32(Console.ReadLine());
            arr.Add(newItem);
            Console.WriteLine($"{newItem} is added");
            break;
        case "q":
            isQuite = true;
            Console.WriteLine("quite successed!");
            break;
        case "h":
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");
            }
            else
            {

                int sum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
            };
            int avg = sum / arr.Count();
            Console.WriteLine($"avg of the list = {avg}");
            }
            break;
        case "s":
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");
            }
            else
            {

                int smallest = arr[0];
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                };
            }
            Console.WriteLine($"the smallest item is {smallest}");
            }
            break;
        case "l":
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");

            }
            else
            {
                if (arr.Count() == 0)
                {
                    Console.WriteLine(" []- list is empty");
                }
                else { 
                    int largest = arr[0];
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] > largest)
                    {
                        largest = arr[i];
                    }
                    ;

                }
                Console.WriteLine($"the largest item = {largest}");
            }
           
                };
            break;
        case "f":
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");
            }
            else
            {

                Console.WriteLine("Enter the number to search");
            int searchItem = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == searchItem)
                {
                    Console.WriteLine($"the item {searchItem} is exist in index {i}");
                }
            };
            }; 
            break;
        case "c":
            arr = [];
            if (arr.Count() == 0)
            {
                Console.WriteLine(" []- list is empty");
            }
            break;
        default:
            Console.WriteLine("Choose correct operation");
            break;
    }
};