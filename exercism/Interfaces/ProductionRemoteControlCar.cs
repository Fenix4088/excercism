using System.Runtime.CompilerServices;

namespace Exercism.Interfaces;

using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    public void Drive();
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar: IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
    
    public int CompareTo(ProductionRemoteControlCar car) => NumberOfVictories - car.NumberOfVictories;
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2) => prc1.CompareTo(prc2) > 0 ? new List<ProductionRemoteControlCar>() {prc2, prc1} : new
        List<ProductionRemoteControlCar>() { prc1, prc2 };
}