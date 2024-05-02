namespace Exercism.Properties;

public class WeighingMachine(int precision)
{
    
    public int Precision { get; } = precision;
    
    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set
        {
            if (value >= 0)
            {
                _weight = value;
                return;
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight => $"{Math.Round(Weight - TareAdjustment, Precision).ToString($"0.{new string('0', Precision)}")} kg";
}