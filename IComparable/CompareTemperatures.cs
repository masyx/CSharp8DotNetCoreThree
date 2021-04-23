using System;
using System.Collections.Generic;

public class CompareTemperatures
{
    public static void Main()
    {
        var temperatures = new List<Temperature>();

        for (int i = 0; i < 5; i++)
        {
            temperatures.Add(new Temperature { Fahrenheit = new Random().Next(0, 100) });
        }

        temperatures.Sort();

        foreach (var item in temperatures)
        {
            Console.WriteLine(item.Fahrenheit);
        }
    }
}
public class Temperature : IComparable
{
    // The temperature value
    protected double temperatureF;

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Temperature otherTemperature = obj as Temperature;
        if (otherTemperature != null)
            return this.temperatureF.CompareTo(otherTemperature.temperatureF);
        else
            throw new ArgumentException("Object is not a Temperature");
    }

    public double Fahrenheit
    {
        get
        {
            return this.temperatureF;
        }
        set
        {
            this.temperatureF = value;
        }
    }

    public double Celsius
    {
        get
        {
            return (this.temperatureF - 32) * (5.0 / 9);
        }
        set
        {
            this.temperatureF = (value * 9.0 / 5) + 32;
        }
    }
}

