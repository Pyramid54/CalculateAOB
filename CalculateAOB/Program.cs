class CalculateAOB {
    // l = Measured centiradians of ship length
    // h = Measured centiradians of ship height
    // L = Length of ship in meters (Found in recognition book)
    // H = Height of ship in meters (Found in recognition book)

    // Formula for when ship is coming TOWARDS you: arcsin( (l/(h/16)) / (L/H) ) * (180°/π) (for the sake of this program, we omit the 180/π and use a hand made method to convert to degrees)
    // Formula for when ship is going AWAY from you: 180° - (arcsin( (l/(h/16)) / (L/H) ) * (180°/π)) (for the sake of this program, we omit the 180/π and use a hand made method to convert to degrees)

    static double l;
    static double h;
    static double L;
    static double H;
    static int towardsOrAway;
    
    public static double ConvertToDegrees(double radians)
    {
        return radians * 180 / Math.PI;
    }

    public static double ComingTowardsYou(double l, double h, double L, double H)
    {
        double resultInRadians = Math.Asin((l / (h / 16)) / (L / H));
        double resultInDegrees = ConvertToDegrees(resultInRadians);
        
        return resultInDegrees;
    }

    public static double GoingAwayFromYou(double l, double h, double L, double H)
    {
        double result = 180 - ConvertToDegrees((Math.Asin((l / (h / 16)) / (L / H))));
        
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("ALL MEASUREMENTS TO BE DONE WHILE ZOOMED IN");

        Console.Write("Measured centiradians of ship length: ");
        l = Convert.ToDouble(Console.ReadLine());

        Console.Write("Measured centiradians of ship height: ");
        h = Convert.ToDouble(Console.ReadLine());

        Console.Write("Length of ship in meters (recognition manual): ");
        L = Convert.ToDouble(Console.ReadLine());

        Console.Write("Height of ship in meters (recognition manual): ");
        H = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter 1 if target is coming towards you, or 2 if target is going away from you: ");
        towardsOrAway = Convert.ToInt32(Console.ReadLine());

        if (towardsOrAway == 1)
        {
            Console.WriteLine(ComingTowardsYou(l, h, L, H));
        }

        else if (towardsOrAway == 2)
        {
            Console.WriteLine(GoingAwayFromYou(l, h, L, H));
        }

        else
        {
            Console.WriteLine("Invalid choice");
        }

        Console.ReadKey();
    }
}