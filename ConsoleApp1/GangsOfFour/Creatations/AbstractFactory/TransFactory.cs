namespace ConsoleApp1.GangsOfFour.Creatations.AbstractFactory
{
    public class TransFactory : ITransportFactory
    {
        public void BuildTransport()
        {
            IVehicle vehicle = new Car();
            IAirCraft airCraft = new Plane();
        }
    }
}
