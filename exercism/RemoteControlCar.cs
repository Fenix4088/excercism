using System.Runtime.CompilerServices;

namespace Exercism;

class RemoteControlCar
{
    private int _disatance;
    private int _battery = 100;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_disatance} meters";

    public string BatteryDisplay() => _battery > 0  ? $"Battery at {_battery}%" : "Battery empty";

    public void Drive()
    {
        if (_battery == 0) return;
        _disatance += 20;
        _battery -= 1;
    }
}