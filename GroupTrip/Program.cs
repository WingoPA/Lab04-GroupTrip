/* 
* Name: Peyton Wingo
* Course CSCI 1250, Section 002
* Assignment: Lab 04, Group Trip 
* Date: 9-28-26
* Description: Rebuilds the trip calculator with methods and arrays so it reports on a whole group instead of one person
*/

const int slicesPer = 8;
const double taxRate = 0.18;

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

Console.WriteLine("How long was the round trip in miles?");
int MilesForTrip = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("");

Console.WriteLine("What is the miles per gallon of your vehicle?");

Console.WriteLine("");

double MilesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("What is the price of gas per gallon?");

Console.WriteLine("");

double gasprice = Convert.ToDouble(Console.ReadLine());

double fuelcost = FuelCost(MilesForTrip, MilesPerGallon, gasprice);

//pizza_party


Console.WriteLine("");

Console.WriteLine("How many pizzas did you buy on your trip?");

Console.WriteLine("");

int pizzaAmount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("What is the price per pizza?");
double PricePerPerson = Convert.ToDouble(Console.ReadLine());


double totalSlices = pizzaAmount * slicesPer;

double slicesPerPerson = totalSlices / names.Length;

double costPizza = pizzaAmount * PricePerPerson;

Console.WriteLine("Total slices: " + totalSlices);

Console.WriteLine("Slices per person: " + slicesPerPerson.ToString("F2"));

Console.WriteLine("Pizza cost: " + costPizza.ToString("F2"));








// Part 1

System.Console.WriteLine("");

System.Console.WriteLine("=== Part 1: The Trip ===");

Console.WriteLine("");

Console.WriteLine($"Fuel cost: {fuelcost:C}");
Console.WriteLine($"Pizza cost: {costPizza:C}");

double tripTotal = fuelcost + costPizza;

Console.WriteLine($"Trip total: {tripTotal:C}");

Console.WriteLine("");

//Part 2



double costPerPerson = tripTotal / names.Length;

System.Console.WriteLine("=== Part 2: The Group ===");

Console.WriteLine("");

Console.WriteLine("People Going: " + names.Length);

Console.WriteLine("Slices each: " + (pizzaAmount * slicesPer) / names.Length);

Console.WriteLine("Cost per person: " + tripTotal / names.Length);

Console.WriteLine("");

//Part 3

System.Console.WriteLine("=== Part 3: Who Works How Long ===");

Console.WriteLine("");

double totalHoursWorked = 0;
double totalTakeHomePay = 0;
double longestHoursToWork = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double profitPerHour = takeHomePay / hoursWorked[i];
    double mustWork = HoursToCover(costPerPerson, profitPerHour);

    Console.WriteLine($"{names[i]}: takes home {takeHomePay:C} for {hoursWorked[i]} hours, {profitPerHour:C} per hour, must work {mustWork:F2} hours");

    totalHoursWorked += hoursWorked[i];
    totalTakeHomePay += takeHomePay;

    if (mustWork > longestHoursToWork)
    {
        longestHoursToWork = mustWork;
    }
}


System.Console.WriteLine("");

Console.WriteLine($"Total hours worked: {totalHoursWorked:F0}");
Console.WriteLine($"Total take home pay: {totalTakeHomePay:C}");
Console.WriteLine($"Longest anyone must work: {longestHoursToWork:F2}");

// Method 1

static double FuelCost(double MilesForTrip, double MilesPerGallon, double gasprice)
{
    double gallonsNeeded = MilesForTrip / (double)MilesPerGallon;
    double fuelcost = gallonsNeeded * gasprice;
    return fuelcost;
}

// Method 2


static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double gross = hours * hourlyRate; 

double withheld = gross * taxRate; 

double profit = gross - withheld;

return profit;
}

// Method 3

static double HoursToCover(double costPerPerson, double profitPerHour)
{
    double mustWork = costPerPerson / profitPerHour;
    return mustWork;
}