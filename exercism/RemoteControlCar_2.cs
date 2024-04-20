namespace Exercism;

public class RemoteControlCar_2
{
    
    private int speed;
    private int batteryDrain;
    private int distance;
    private int battery = 100;
    
    public RemoteControlCar_2(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => battery <= 0 || battery - batteryDrain < 0;

    public int DistanceDriven() => distance;

    public void Drive()
    {
        if (BatteryDrained()) return;
        battery -= batteryDrain;
        distance += speed;
    }

    public static RemoteControlCar_2 Nitro() => new RemoteControlCar_2(50, 4);
}

class RaceTrack
{
    private int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar_2 car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() <= distance)
        {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}