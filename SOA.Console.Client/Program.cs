namespace SOA.Console.Client
{
    using CalculateurService;
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorSoapClient calculator = new CalculatorSoapClient();
            calculator.Add(11, 44);
        }
    }
}
