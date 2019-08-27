using System;

namespace PaySlipKata
{
    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Welcome to the payslip generator!");
        
    
        Console.WriteLine("Please input your name: ");
        var name = Console.ReadLine();
        
        Console.WriteLine("Please input your surname:");
        var surName = Console.ReadLine();
        
        Console.WriteLine("Please enter your annual salary:");
        int annualSalary = 0;
        while (!int.TryParse(Console.ReadLine(), out annualSalary))
        {
            Console.WriteLine("Please Enter a valid numerical value!");
            Console.WriteLine("Please enter your annual salary");
        }

        Console.WriteLine("Please enter your super rate:");
        
        decimal percentageOfSuper = 0;
        
        if(decimal.TryParse(Console.ReadLine(), out var superRate))
        {
            percentageOfSuper = superRate / 100;
        }
        else
        {
            Console.WriteLine("Please enter a valid number");
            return;
        }
        

        Console.WriteLine("Please enter your payment start date:");
        var startDate = Console.ReadLine();
        
        Console.WriteLine("Please enter your payment end date:");
        var endDate = Console.ReadLine();
        
        var grossIncome = GrossIncome(annualSalary);
        var netIncome = GrossIncome(annualSalary) - IncomeTaxCalculation(annualSalary);
        var superAmount = decimal.Floor(grossIncome * percentageOfSuper);
        var incomeTax = IncomeTaxCalculation(annualSalary);

       
        
        Console.WriteLine("Your payslip has been generated:");
        Console.WriteLine($"Name: {name} {surName}");
        Console.WriteLine($"Pay Period: {startDate} - {endDate}");
        Console.WriteLine($"Gross Income: {grossIncome}");
        Console.WriteLine($"Income Tax: {incomeTax}");
        Console.WriteLine($"Net Income: {netIncome}");
        Console.WriteLine($"Super: {superAmount}");
        Console.WriteLine("Thank you for using MYOB!");
        
         
        }

        static int GrossIncome(int annualSalary)
        {
            var grossIncome = annualSalary / 12;

            return grossIncome;

        }
        

        static int IncomeTaxCalculation(int annualSalary)
        {
            
            var taxAmount = 0 ;

            var fixedTaxAmount = 0;

            if (annualSalary < 18200)
            {
                taxAmount = 0;
            }
            else if (18200 < annualSalary && annualSalary < 37000)
            {
                taxAmount = (int) Math.Ceiling((fixedTaxAmount + (annualSalary - 18200) * 0.19)/12);


            } else if (37000 < annualSalary && annualSalary < 87000)
            {
                fixedTaxAmount = 3572;
                taxAmount = (int) Math.Ceiling((fixedTaxAmount + (annualSalary - 37000) * 0.325)/12);


            }else if (87000 < annualSalary && annualSalary < 180000)
            {
                fixedTaxAmount = 19822;
                taxAmount = (int) Math.Ceiling((fixedTaxAmount + (annualSalary - 87000) * 0.37)/12);
            }
            else
            {
                fixedTaxAmount = 54232;
                taxAmount = (int) Math.Ceiling((fixedTaxAmount + (annualSalary - 180000) * 0.45)/12);
            }
            

            return taxAmount;
        }

        

    }
}

             