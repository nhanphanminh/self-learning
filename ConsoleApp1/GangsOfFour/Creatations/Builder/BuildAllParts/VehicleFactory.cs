namespace ConsoleApp1.GangsOfFour.Creatations.Builder.BuildAllParts
{
    public class VehicleFactory : IVehicleFactory
    {
        public void ConstructVehicle(IVehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
}
