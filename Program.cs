namespace Assignment2;
using System.Text;
class Program
{
    static void Main(string[] args)
    {

        RunQuestion1();

        RunQuestion2();

        RunQuestion3();

        RunQuestion4();

        RunQuestion5();

        RunQuestion6();

        RunQuestion7();

        RunQuestion8();

        RunQuestion9();

        RunQuestion10();

    }

    // Start of Question 1 Logic 
    public static void RunQuestion1()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 1: ");
        int customers = 0;
        decimal monthlyPrice = 0.00m, percentageIncrease = 0.00m;
        try {
            Console.Write("Please enter the current number of customers: ");
            customers = Convert.ToInt32(Console.ReadLine() ?? "");
            Console.Write("Please enter the current monthly price per customer subscription: ");
            monthlyPrice = Convert.ToDecimal(Console.ReadLine() ?? "");
            Console.Write("Please enter the percentage price increase for the monthly subscription: ");
            percentageIncrease = Convert.ToDecimal(Console.ReadLine() ?? "");
            if(customers < 0 || monthlyPrice < 0 || percentageIncrease < 0){
                Console.WriteLine("One of the entered quantities is negative. All of the quantities provided by the user must be greater than or equal to 0");
                return;
            }
            print_subscription_revenue(customers, monthlyPrice, percentageIncrease);
        } catch (FormatException){
            Console.WriteLine("One or more of the input values was not numeric. Please enter numeric values.");
        } catch (OverflowException){
            Console.WriteLine("One or more of the input values was outside the allowable range.");
        }
    }
    public static void print_subscription_revenue(int customers, decimal monthlyPrice, decimal percentageIncrease)
    {
        decimal totalMonthlyRevenue = customers * monthlyPrice;
        decimal rateIncrease = 1.00m + (percentageIncrease / 100.00m);
        Console.WriteLine("The total current revenue is $"+totalMonthlyRevenue);
        decimal newMonthlyPrice = Math.Round(rateIncrease * monthlyPrice, 2);
        decimal projectedMonthlyRevenue = Math.Round(newMonthlyPrice * customers, 2);
        Console.WriteLine("The projected monthly revenue after the new monthly price is expected to be $"+projectedMonthlyRevenue);
        decimal additionalMonthlyRevenue = projectedMonthlyRevenue-totalMonthlyRevenue;
        decimal additionalPricePerCustomer = newMonthlyPrice - monthlyPrice;
        Console.WriteLine("The total additional monthly revenue (dollar increase) is $"+additionalMonthlyRevenue+" and the price per customer is expected to increase by $"+additionalPricePerCustomer);

    }

    // End of question 1 logic

    // Start of question 2 logic

    public static void RunQuestion2()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 2: ");
        double percentageRate = 0.00;
        try {
    
            Console.Write("Please enter an annual return rate as a percentage in order to know how much time in years it will take for the original investment to double: ");
            percentageRate = Convert.ToDouble(Console.ReadLine());
        } catch(FormatException){
            Console.WriteLine("The percentage rate must be numeric. Please make sure you entered the correct data type.");
            return;
        } catch (OverflowException){
            Console.WriteLine("One or more of the input values was outside the allowable range.");
        }

        if(percentageRate <= 0)
        {
            Console.WriteLine("Please enter a valid percentage rate. A negative percentage rate is not allowed");
            return;
        }
        double result = calculate_time_double_investment(percentageRate);
        Console.WriteLine("Specifically, the time it will take for the investment to double is "+result+" years");
    }

    public static double calculate_time_double_investment(double percentageRate)
    {
        double r = percentageRate / 100;
        double result = Math.Round(Math.Log10(2.0) / Math.Log10(1 + r), 2);
        string speed = "";
        if(result < 10)
        {
            speed = "fast";
        } else if(result <= 20)
        {
            speed = "moderate";
        } else
        {
            speed = "slow";
        }
        Console.WriteLine("The investment will double at a "+speed+" speed");
        return result;
    }

    // End of question 2 logic
    
    // Start of Question 3 Logic

    public static void RunQuestion3()
    {
    
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 3: ");
        Console.WriteLine("Welcome! In order to calculate the area of the triangle region, you will need to provide side lengths a, b, and c one at a time");
    
        double a = 0, b = 0, c = 0;
        try {
    
            Console.Write("Please enter side length of a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Now, please enter side length of b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Finally, please provide the side length of c: ");
            c = Convert.ToDouble(Console.ReadLine());
        } catch(FormatException){
            Console.WriteLine("One or more of the input side lengths provided by the user are non numeric. Please make sure that the sides lengths are all numeric. ");
            return;
        } catch (OverflowException){
            Console.WriteLine("One or more of the input values was outside the allowable range.");
        }
        if(a <= 0 || b <= 0 || c <= 0)
        {
            Console.WriteLine("All side lengths of the triangle must be greater than 0 for it to be a valid triangle");
            return;
        }
        double areaOfTriangle = 0.00;
        if(c >= a + b || b >= a + c || a >= b + c)
        {
            Console.WriteLine("The input side lengths do not make up a valid triangle. For a triangle to be valid, the sum of any two side lengths of a triangle must be greater than the remain side length of the same triangle.");
        } else
        {
            areaOfTriangle = calculateTriangleArea(a,b,c);
            Console.WriteLine("The area of the triangle is "+areaOfTriangle);
        }
    }

    public static double calculateTriangleArea(double a, double b, double c){
        double semiPerimeter = (a + b + c) / 2.0;
        double areaOfTriangle = Math.Sqrt(semiPerimeter * (semiPerimeter-a) * (semiPerimeter - b) * (semiPerimeter - c));
        return areaOfTriangle;
    }

    // End of question 3 logic

    public static void RunQuestion4()
    {
    
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 4: ");
        Console.WriteLine("Please enter the number of compute hours used: ");
        try
        {
            double numberOfHours = Convert.ToDouble(Console.ReadLine() ?? "");
            if(numberOfHours < 0)
            {
                Console.WriteLine("Number of Hours must be non negative");
                return;
            }
            decimal total_invoice = CalculateAndDisplayInvoice(numberOfHours);
            Console.WriteLine("The total invoice is: "+total_invoice);
        } catch(FormatException) {
        
            Console.WriteLine("The number of compute hours must be a numeric input. Please make sure to add a numeric input. ");
            return;
        }
    } 

    public static decimal CalculateAndDisplayInvoice(double hours){
    
        decimal usageCharge = 0.00m;
        if(hours > 500)
        {
            usageCharge = (100 * 0.12m) + (400 * 0.09m) + (Convert.ToDecimal(hours - 500) * 0.06m);
        }
        else if (hours > 100)
        {
        usageCharge = (100 * 0.12m) + (Convert.ToDecimal(hours - 100) * 0.09m);
        }
        else
        {
        usageCharge = Convert.ToDecimal(hours) * 0.12m;
        }

        usageCharge = Math.Round(usageCharge, 2);
        decimal serviceFee = Math.Round(usageCharge * 0.05m,2);
        decimal totalInvoice = usageCharge + serviceFee;
        Console.WriteLine($"Usage Charge: {usageCharge}");
        Console.WriteLine($"Service Fee (5%): {serviceFee}");
        return totalInvoice;
}


    public static decimal calculateComputerCharges(double hours)
    {

        decimal charges = 0.00m;

        int maxThreshold = 500, mediumThreshold = 100;

        if(hours > maxThreshold)
        {

            charges += 0.06m * Convert.ToDecimal(hours-maxThreshold);

            hours = maxThreshold;

        }

        if(hours > mediumThreshold)
        {
            
            charges += 0.09m * Convert.ToDecimal(hours - mediumThreshold);

            hours = mediumThreshold;

        }

        charges += 0.12m * Convert.ToDecimal(hours);

        hours = 0;

        return charges;
        
    }

    public static decimal calculateComputerChargesAgain(double hours)
    {

        double upperThreshold = 500;

        double firstThreshold = 100;
        
        decimal charges = Math.Max(0.00m, 0.06m * Convert.ToDecimal(hours-upperThreshold)) + Math.Max(0.00m, 0.09m * Convert.ToDecimal((Math.Min(upperThreshold,hours)-firstThreshold))) + 0.12m * Convert.ToDecimal(Math.Min(firstThreshold,hours));

        return charges;

    }

    public static decimal calculateServiceFee(decimal rate, decimal price)
    {
        
        return price * rate;

    }

    public static void RunQuestion5()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("Beginning of Question 5:");
        decimal dataEntry = 0.00m, totalSalesAmount = 0.00m;
        int numberOfSales = 0;
        while(dataEntry != -1.00m)
        {
            try {
            Console.WriteLine("--------------------------");
            Console.Write("Please enter a new sale amount ");
            dataEntry = Convert.ToDecimal(Console.ReadLine() ?? "");
                if(dataEntry > 0) {
                    totalSalesAmount += dataEntry;
                    numberOfSales++;
                } else if(dataEntry != -1)
                {
                
                    Console.WriteLine("Please enter a valid sales amount. A sales amount has to be positive. If you want to end the program, enter -1");
                    continue;
                }
            } catch(FormatException) {
                Console.WriteLine("Please make sure to enter a numeric sale amount. ");
            }
 
        }

        if(numberOfSales == 0)
        {
            Console.WriteLine("Either no sales were entered, or not valid sales were entered");
            return;
        }
        decimal averageAmountPerSale = totalSalesAmount / numberOfSales;
        Console.WriteLine("The total amount collected after "+numberOfSales+" total sales is "+totalSalesAmount+", and the average amount per sale is "+averageAmountPerSale);
    }

    public static void RunQuestion6()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 6: ");
        decimal initialInvestment = 0.00m;
        decimal monthlyBenefit = 0.00m;
        try {
          
            Console.Write("Please enter your initial investment: ");
            initialInvestment = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Thanks. Now please enter the monthly benefit: ");
            monthlyBenefit = Convert.ToDecimal(Console.ReadLine());
            if(initialInvestment <= 0 || monthlyBenefit <= 0)
            {
                Console.WriteLine("Both the initial investment and the monthly benefit must be greater than 0");
                return;
            }
            recoup(initialInvestment, monthlyBenefit);
        } catch(FormatException){
            Console.Write("Both the initial investment or the expected monthly benefit must be numeric. ");
        }   

    }

    public static void recoup(decimal initialInvestment, decimal monthlyBenefit)
    {
        
        decimal cumulativeBenefits = 0.00m;
        int totalMonths = 0;
        while(cumulativeBenefits < initialInvestment && totalMonths <= 600)
        {
        
            cumulativeBenefits += monthlyBenefit;
            totalMonths++;
            decimal unrecoveredBalance = initialInvestment - cumulativeBenefits;
            if(unrecoveredBalance >= 0) {
                Console.WriteLine("The current unrecovered balance after "+totalMonths+" months is "+unrecoveredBalance);
            }
        }
        if(totalMonths <= 600) {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(totalMonths+" months after the initial investment at a monthly benefit of $"+monthlyBenefit+", you will be able to get a cumulative benefit at least as big as your initial investment. Specifically, you will have accumulated "+cumulativeBenefits+" in total benefits with a profit of $"+(cumulativeBenefits-initialInvestment)+"\n");
            Console.WriteLine("If you continue on this path, you will be able to make a lot of money beyond just getting back your initial investment");
        } else
        {
            Console.WriteLine("It will take more than 600 months for the user to get his initial investment back in terms of cumulative benefits");
        }

    }


    public static void RunQuestion7()
{

    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Beginning of Question 7 ");
    Console.Write("Please enter 7 demand values, each separated by a space: ");

    string input = Console.ReadLine() ?? "";
    
    Console.WriteLine();
    
    string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    if (tokens.Length != 7){
    
        Console.WriteLine("Error: You must enter exactly 7 values.");
    
        return;

    }
    
    int[] demandValues = new int[7];
    
    int maxTens = 0;
    
    int maxLabelLength = 0;
    
    string[] labels = new string[7];
    
    for (int i = 0; i < 7; i++) {

        int value = 0;

        try {
            
            value = Convert.ToInt32(tokens[i]);

        } catch(Exception e){

            Console.Write("At least one of the daily demands entered was non numeric. Please make sure that all the daily demand values are numeric. Error: "+e);
            return;

        }

        if (value < 0){
            Console.WriteLine("Demand values cannot be negative. "+value+" is negative");
            return;
        }

        demandValues[i] = value;

        maxTens = Math.Max(maxTens, value / 10);

        labels[i] = "| Day " + (i + 1) + " | Demand Value: " + demandValues[i] + " | Tens of Demand Units: ";
        
        maxLabelLength = Math.Max(maxLabelLength, labels[i].Length);

    }
    
    int totalTableWidth = maxLabelLength + maxTens + 2;

    for (int i = 0; i < 7; i++){

        string currentLabel = labels[i];

        Console.Write(currentLabel);

        int paddingSpaces = maxLabelLength - currentLabel.Length;

        for (int j = 0; j < paddingSpaces; j++){
            Console.Write(" ");
        }

        int starsCount = demandValues[i] / 10;

        for (int j = 0; j < starsCount; j++){
            Console.Write("*");
        }
        
        int trailingSpaces = maxTens - starsCount;
        
        for (int j = 0; j < trailingSpaces; j++)
        {
            Console.Write(" ");
        }
        
        Console.WriteLine(" |");

        for (int j = 0; j < totalTableWidth; j++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
}

    public static void RunQuestion8()
    {

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 8 ");
        Console.WriteLine("Welcome. In order to assign a customer risk score method for a customer, you will need to enter different quantities. ");    
        
        int missedPayments = 0, supportTickets = 0, monthsInactive = 0;

        try {

            Console.Write("First, please enter the missed number of payments for the current client: ");

            missedPayments = Convert.ToInt32(Console.ReadLine() ?? "");

            Console.Write("Great. Now, please enter the amount of support tickets the client has requested: ");

            supportTickets = Convert.ToInt32(Console.ReadLine() ?? "");

            Console.Write("Finally, please enter the number of inactive months for the current client: ");

            monthsInactive = Convert.ToInt32(Console.ReadLine() ?? "");

            if(missedPayments < 0 || supportTickets < 0 || monthsInactive < 0)
            {
                Console.WriteLine("Please make sure that all the three quantities are greater than or equal to 0");
                return;
            }

            int riskScore = ComputeRiskScore(missedPayments, supportTickets, monthsInactive);

            Console.WriteLine("The risk score for the current client is "+riskScore);

            string classification = "";

            if(riskScore < 30)
            {
                classification = "Low";
            } else if(riskScore < 60)
            {
                classification = "Moderate";
            } else
            {
                classification = "High";
            }

            Console.WriteLine("The risk for the current client is "+classification);

        } catch(FormatException){
            
            Console.WriteLine("At least one of the required entries is not a string. Please make sure to enter only numeric quantities. ");

        }

    }

    public static int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive) {
        
        return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;

    }

    public static void RunQuestion9()
    {
        
        int transactionAmounts = 0;

        try {

            Console.Write("Welcome! Please enter the total number of transaction amounts that will be entered: ");

            transactionAmounts = Convert.ToInt32(Console.ReadLine() ?? "");

            if(transactionAmounts < 0){
                
                Console.WriteLine("The amount of transactions entered cannot be negative");

                return;

            }

        } catch(FormatException) {
            
            Console.WriteLine("The amount of transactions has to be a numeric input. Please make sure you are entering a numeric input. ");

            return;

        }

        decimal [] arr = new decimal[transactionAmounts];

        int arrIndex = 0;

        while(transactionAmounts > 0)
        {

            try {

                Console.Write("Please enter the transaction amount: ");
            
                decimal input = Convert.ToDecimal(Console.ReadLine() ?? "");

                if(input < 0)
                {
                    Console.WriteLine("The transaction amount must be positive");
                    continue;
                }

                arr[arrIndex++] = input;

            } catch(Exception e){

                Console.WriteLine("The input that was entered is non numeric. Please make sure that the input you entered is numeric. Error: "+e); 
                continue;

            }

            transactionAmounts--;

        }

        int length = arr.Length;

        decimal multiplier = 1.50m;

        decimal minimum = calculateMin(arr);

        decimal maximum = calculateMax(arr);

        decimal total = calculateTotal(arr);

        decimal average = calculateAverage(total, length);

        string identifier = "demand value";

        displayResults(minimum, maximum, total, average, identifier);

        Console.WriteLine("Labels for the different transaction amounts");

        for(int i = 0; i < length; i++)
        {

            string label = arr[i] > (multiplier * average) ? "Review" : "Normal";
            Console.WriteLine("Label for transaction "+i+" with amount "+arr[i]+" is "+label);

        }

    }

    public static void RunQuestion10(){
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 8 ");
        Console.WriteLine("Welcome! In order to get started, you will be prompted to enter 7 sales amounts, representing the sales for each day");

        int count = 7;

        decimal [] sales = new decimal[count];

        while(count > 0){

            try {

                Console.Write("Please enter a new sales amount: ");

                decimal variable = Convert.ToDecimal(Console.ReadLine() ?? "");

                if(variable < 0)
                {
                    Console.WriteLine("One of the entered sales amounts is negative. You need to make sure your sales amounts are all positive. Please try again!");
                    continue;
                }
                
                sales[sales.Length-count] = variable;

            } catch(Exception){
                
                Console.WriteLine("One of the inputted values is not numeric. Please make sure to enter numeric sales amounts.");

                continue;

            }

            count--;
            
        }

        decimal totalSales = calculateTotal(sales);

        decimal average = Math.Round(calculateAverage(totalSales, sales.Length),2);

        decimal largest = calculateMax(sales);

        decimal smallest = calculateMin(sales);

        int countAbove = calculateCountAbove(average, sales);

        string identifier = "sale";
        
        displayResults(smallest, largest, totalSales, average, identifier);

        displayCountAbove(countAbove, average);

        string label = "";

        if(countAbove > 3)
        {
            label = "Strong";
        } else if(countAbove > 1)
        {
            label = "Balanced";
        } else
        {
            label = "Concentrated";
        }
        
        Console.WriteLine("The week has a classification of "+label);

    }

    public static decimal calculateTotal(decimal [] arr) {
        
        decimal total = 0.00m;

        for(int i = 0; i < arr.Length; i++){
            total += arr[i];
        }

        return total;

    }

    public static decimal calculateAverage(decimal totalSum, int numberOfElements){

        if(numberOfElements < 0)
        {
            Console.WriteLine("Number of elements entered cannot be 0");
            return -1.0m;
        }

        return totalSum / numberOfElements;

    }

    public static decimal calculateMax(decimal [] arr){
        
        decimal largest = 0;

        for(int i = 0; i < arr.Length; i++)
        {
            
            largest = Math.Max(largest, arr[i]);

        }

        return largest;

    }

    public static decimal calculateMin(decimal [] arr){
    
        decimal smallest = Decimal.MaxValue;

        for(int i = 0; i < arr.Length; i++){
            
            smallest = Math.Min(smallest, arr[i]);
            
        }
        
        return smallest;

    }

    public static int calculateCountAbove(decimal quantity, decimal [] arr){
        
        int length = arr.Length;

        int countAbove = 0;

        for(int i = 0; i < length; i++){

            if(arr[i] > quantity)
            {
                countAbove++;
            }

        }

        return countAbove;

    }

    public static void calculateSummaryStatistics(decimal [] arr, out decimal min, out decimal max, out decimal total, out decimal average, string identifier){
        
        min = Decimal.MaxValue;
        max = 0.00m;
        total = 0.00m;
        average = 0.00m;

        if(arr.Length == 0 || arr == null)
        {
            Console.WriteLine("Array cannot be null, and array Length cannot be 0");
            return;
        }

        int length = arr.Length;

        for(int i = 0; i < length; i++){
            
            min = Math.Min(min, arr[i]);

            max = Math.Max(max, arr[i]);

            total += arr[i];

        }

        average = total / length;

        displayResults(min, max, total, average, identifier);

    }

    public static void displayResults(decimal min, decimal max, decimal total, decimal average, string identifier)
    {
        
        Console.WriteLine("The minimum "+identifier+" is "+min);
        Console.WriteLine("The maximum "+identifier+" is "+max);
        Console.WriteLine("The total "+identifier+" amounts to "+total);
        Console.WriteLine("The average "+identifier+" is "+average);

    }

    public static void displayCountAbove(int countAbove, decimal quantity)
    {
        
        Console.WriteLine("There are "+countAbove+" days above "+quantity);

    }

    
    

}
