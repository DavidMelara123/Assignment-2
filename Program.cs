namespace Assignment2;
using System.Text;
class Program
{

    public static string closingMessage = "You have decided to finish the program early";
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
        
        Console.WriteLine("-----------------------");
        Console.WriteLine("Beginning of Question 1");

        decimal customers = convertToDecimal("Number of customers");

        if(customers == -1)
        {
            Console.WriteLine("You have decided to finish the program");
            return;
        }

        decimal monthlyPrice = convertToDecimal("Monthly Price");

        if(monthlyPrice == -1)
        {
            Console.WriteLine("You have decided to finish the program");
            return;
        }

        decimal percentageIncrease = convertToDecimal("Percentage Increase");

        if(monthlyPrice == -1)
        {
            Console.WriteLine(closingMessage);
        }

        print_subscription_revenue(customers, monthlyPrice, percentageIncrease);
            
    }

    public static void print_subscription_revenue(decimal customers, decimal monthlyPrice, decimal percentageIncrease)
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
        Console.Write("Please enter an annual return rate as a percentage in order to know how much time in years it will take for the original investment to double. If you want to end the program, enter -1 ");

        double percentageRate = convertToDouble("percentage rate");

        if(percentageRate == -1.00)
        {
            Console.WriteLine("You have chosen to end the program");
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
        Console.WriteLine("\nThe investment will double to its initial amount at a "+speed+" speed");
        return result;
    }

    // End of question 2 logic
    
    // Start of Question 3 Logic

    public static void RunQuestion3(){
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 3: ");
        Console.WriteLine("Welcome! In order to calculate the area of the triangle region, you will need to provide side lengths a, b, and c one at a time. If you instead want to end the program, please enter -1.");
    
        double areaOfTriangle = -1.00; // invalid and impossible result, so -1 as placeholder

        while(areaOfTriangle == -1.00) {

            double a = convertToDouble("side length a");

            if(a == -1)
            {
                Console.WriteLine(closingMessage);
            }

            double b = convertToDouble("side length b");

            if(b == -1)
            {
                Console.WriteLine(closingMessage);
            }

            double c = convertToDouble("side length c");

            if(c == -1)
            {
                Console.WriteLine(closingMessage);
            }

            areaOfTriangle = calculateTriangleArea(a,b,c);

        }


        Console.WriteLine("\nThe area of the triangle is: "+areaOfTriangle);

    }

    public static double obtainSideLength(string identifier)
    {

        double sideLength = 0.00;

        Console.Write("\nPlease enter side length for side "+identifier+": ");

        while(sideLength <= 0.00) {
        
            try {

                sideLength = Convert.ToDouble(Console.ReadLine() ?? "");

                if(sideLength <= 0.00)
                {
                    Console.WriteLine("\nEach side length of any valid triangle must be greater than 0. Please try again for side length "+identifier+": ");
                }

            } catch(FormatException) {
                
                Console.WriteLine("\nThe data type of the entered side length must be double. Please try again for side length "+identifier+": ");

            } catch(OverflowException) {
                
                Console.WriteLine("\nPlease make sure that the side length that you entered fits within the range [0,"+Double.MaxValue+"] in order to prevent overflow. Please try again: ");

            }

        }
        
        return sideLength;

    }

    public static double calculateTriangleArea(double a, double b, double c){
        if(a >= b + c || b >= a + c || c >= a + b)
        {
            Console.WriteLine("\nPlease make sure that you enter valid side lengths for your triangle. A triangle must follow the triangle inequality theorem. Any two side lengths of a triangle must add up to strictly more than the remaining side of the same triangle. ");
            return -1.00; // invalid area to communicate to the while loop for the user to try again
        }
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

        double numberOfHours = convertToDouble("number of hours");

        if(numberOfHours == -1){
            Console.WriteLine("You have chosen to end the program");
        }

        decimal total_invoice = CalculateAndDisplayInvoice(numberOfHours);
        Console.WriteLine("The total invoice is: "+total_invoice);


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

/*

   The version below this comment is the first version I created, but i was not really convinced, so I wrote
   the version where I make use of Math.Max and Math.Min to make a one liner (which I think is a lot more
   elegant). That said, since the requirement was to add if else if and else statements, I did another solution, but I think
   my one liner is better than the one that uses if else if and else statements. It is just tht the requirement
   was to make a solution that uses if else if and else statements.

*/

    public static decimal calculateComputerCharges(double hours){

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

    // most efficient solution I was able to come up with for question 4.

    public static decimal calculateComputerChargesElegantly(double hours)
    {

        double upperThreshold = 500, firstThreshold = 100; 

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
        Console.WriteLine("--------------------------");
        Console.Write("Please enter a new sale amount ");
        while(dataEntry != -1.00m){

            dataEntry = convertToDecimal("sale amount");

            if(dataEntry > 0){
                totalSalesAmount += dataEntry;
                numberOfSales++;
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

    public static void RunQuestion6(){
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 6: ");
        decimal initialInvestment = convertToDecimal("initial investment");
        decimal monthlyBenefit = convertToDecimal("monthly benefit");

        if(initialInvestment == -1 || monthlyBenefit == -1)
        {
            Console.WriteLine("You have decided to finish the program");
        }

        recoup(initialInvestment, monthlyBenefit);

    }

    /*

        Please note that just as I mentioned in the google doc, the below calculation
        takes O(initialInvestment / monthlyBenefit) time complexity. A faster approach
        would be to just do Math.Round(initialInvestment / monthlyBenefit), which would
        take O(1) (i.e constant) time complexity. However, because we need to display
        (for each month) how much money is left before we can get back as much in 
        cumulative benefits as our initial investment, that is why it is a requirement
        to do a while loop. But if that requirement was not there, we could just do 
        a Math.Round(initialInvestment / monthlyBenefit) in O(1) time complexity
        to solve it in one line.

    */

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


    public static void RunQuestion8(){
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beginning of Question 8 ");
        Console.WriteLine("Welcome. In order to assign a customer risk score method for a customer, you will need to enter different quantities. ");    
        
        int missedPayments = convertToInt("missed payments");

        int supportTickets = convertToInt("support tickets");

        int monthsInactive = convertToInt("months inactive");

        int riskScore = ComputeRiskScore(missedPayments, supportTickets, monthsInactive);

        Console.WriteLine("The risk score for the current client is: "+riskScore);

        string classification = "";

        if(riskScore < 30){
            classification = "Low";
        } else if(riskScore < 60) {
            classification = "Moderate";
        } else {
            classification = "High";
        }

        Console.WriteLine("The risk for the current client is "+classification);

    }

    public static int convertToInt(string label){
        
        int variable = -1;

        Console.Write("Please enter the "+label+": ");

        while(variable <= 0){

            try {
            
                variable = Convert.ToInt32(Console.ReadLine() ?? "");

                if(variable <= 0)
                {
                    Console.WriteLine("Please make sure that the integer you entered for "+label+" is positive. Please try again: ");
                }

            } catch(FormatException){

                Console.WriteLine("Please make sure that you entered an integer for "+label+". Please try again: ");
                
            } catch(OverflowException){
                
                Console.WriteLine("Please make sure that the integer you entered is in the range [0,"+Int32.MaxValue+"]. Please try again: ");

            }


        }

        return variable;

    }

    public static double convertToDouble(string label){
        
        double variable = -1.0;

        Console.Write("Please enter the "+label);

        while(variable <= 0){
            
            try
            {

                variable = Convert.ToDouble(Console.ReadLine() ?? "");

                if(variable <= 0)
                {
                    Console.WriteLine("Please make sure that the double you entered is greater than or equal to 0. ");
                }

            } catch(FormatException){
                
                Console.WriteLine("Please make sure that you entered a double for "+label+". Please try again: ");

            } catch(OverflowException) {
                
                Console.WriteLine("Please make sure that the double you entered is in the range [0,"+Double.MaxValue+"]. Please try again: ");

            }

        }

        return variable;

    }

      public static decimal convertToDecimal(string identifier)
    {

      decimal variable = -1.00m;

      Console.WriteLine("Please enter the "+identifier+" ");

      while(variable < 0) {

        try
        {
            
            variable = Convert.ToDecimal(Console.ReadLine() ?? "");

            if(variable == -1.00m)
            {
                return variable;  
            } else if(variable < 0)
            {
                Console.WriteLine(identifier+" cannot be negative. Please try again: ");
                continue;
            } 

        } catch(FormatException){
            Console.WriteLine(identifier+" should have a decimal data type. Please try again: ");
        } catch(OverflowException){
            Console.WriteLine("Please make sure that your variables fit within the allowed range for a decimal");
        }

      }

      return variable;

    }

    public static int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive) {
        
        return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;

    }

    public static void RunQuestion9()
    {
        
        int transactionAmounts = convertToInt("transaction amounts");

        decimal [] arr = new decimal[transactionAmounts];

        int arrIndex = 0;

        while(transactionAmounts > 0)
        {

            decimal input = convertToDecimal("the transaction amount for transaction "+(arrIndex+1));

            if(input == -1){
                Console.WriteLine("You have decided to finish the program early");
                return;
            }

            arr[arrIndex++] = input;

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

    /*

        Please note that I did this in question 9

        decimal minimum = calculateMin(arr);

        decimal maximum = calculateMax(arr);

        decimal total = calculateTotal(arr);

        decimal average = calculateAverage(total, length);

        because it is a requirement. It is a good idea to have reusable functions
        to avoid repeating code. However, since questions 9 and 10 ask for 
        min, max, average, and total, I thought a better way (to do it in just one
        for loop) is to add a method that does all that.
        
        That is what my calculateSummaryStatistics
        method does. However, it was a requirement to create individual methods
        for each. It is not a wrong approach. In fact, both serve different purposes.
        And neither approach is better than the other. It just really depends on
        the task at hand. If you are going to have multiple situations in which 
        you need the four quantities min, max, average, and total, it can be a good idea to do a method
        such as the one I did called "calculateSummaryStatistics." But if you
        are going to have many functions, some that ask for only the min, some that
        only ask for the max, some that ask for only the average, it might be better
        to have a reusable methods for each. In practice, if we need both situations,
        we might keep both the individual methods and the single cohesive method.
        In practice, I still called the individual methods because it was a requirement.
        It is not a big deal anyways because it is still just 4 passes, but the other
        method I made can do it in 1 pass. So it really depends on the task as I said.
        For this task, it could have been great to call the calculate summary statistics
        method I did, but i did not do it because the requirement was to make and
        call individual methods, which is still fine. That is not wrong either. In 
        fact, as I said, neither method is better than the other. It just depends on
        the task at hand and what you want to optimize. For most tasks, having individual
        methods is preferred due to separation of concerns. I just thought I would mention
        this though. I am aware of the tradeoffs of both methods, but ultimately i think
        for most every day purposes having individual functions for each one of them
        is better. If we are going to need all 4 measures in multiple questions, though,
        it could be good to also add the calculateSummaryStatistics method that does
        it all in one pass and then call that. 


    */

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
