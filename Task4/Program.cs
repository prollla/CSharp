class ObjectQualityCalculator
{
    private double x;
    private double y;
    private double quality;

    public ObjectQualityCalculator(double xValue, double yValue)
    {
        x = xValue;
        y = yValue;
        CalculateQuality();
    }

    private void CalculateQuality()
    {
        quality = 0.1 * x * y;
    }

    public void PrintObjectInfo()
    {
        Console.WriteLine("Object quality information:");
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);
        Console.WriteLine("Quality = " + quality);
    }
    
    class UpdatedObjectQualityCalculator : ObjectQualityCalculator
    {
        private double z;
        private double v;

        public UpdatedObjectQualityCalculator(double xValue, double yValue, double zValue, double vValue) : base(xValue, yValue)
        {
            z = zValue;
            v = vValue;
            RecalculateQuality();
        }

        private void RecalculateQuality()
        {
            double updatedQuality = quality - 1.5 * (z - v);
            quality = updatedQuality > 0 ? updatedQuality : 0;
        }
        public void PrintUpdatedObjectInfo()
        {
            Console.WriteLine("Updated object quality information:");
            //Console.WriteLine("x = " + x);
            //Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);
            Console.WriteLine("v = " + v);
            Console.WriteLine("Quality = " + quality);
        }
    }
    
    
    static void Main(string[] args)
    {
        ObjectQualityCalculator obj = new ObjectQualityCalculator(5.0, 10.0);
        obj.PrintObjectInfo();
        UpdatedObjectQualityCalculator obj1 = new UpdatedObjectQualityCalculator(5.0, 10.0, 2000.0, 1999.0);
        obj1.PrintUpdatedObjectInfo();

    }
}