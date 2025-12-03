# Standard Numeric Format - Summary
 ## 1. Why is the output "$30.00"?
 When using the standard numeric format specifier **:C** in C#, the value is formatted as **Currency**.
 This means:- The number is converted to the local currency format.- It includes the currency symbol (e.g., $, EGP, € depending on system settings).- It prints two digits after the decimal point by default.
 Example:
 int X = 10;
 int Y = 20;
 Console.WriteLine($"Equation: {X} + {Y} = {X + Y:C}");
 (X + Y) = 30
 Formatted as currency → **$30.00**
 ## 2. What is the benefit?
 Using standard numeric formats provides:- Cleaner, professional output.- Automatic formatting according to user culture settings.- No need to manually add symbols or control decimal places.- Consistency across the entire application.
 ## 3. Another Example (Percentage Specifier ":P")
 int X = 10;
 int Y = 20;
 Console.WriteLine($"Sum = {X+Y}, Percentage = {((X+Y) / 100.0):p}");
 Explanation:- :P converts a number to a percentage.- It multiplies the value by 100 and adds the % symbol.
 (30 / 100.0) = 0.3 → formatted as **30.00%**