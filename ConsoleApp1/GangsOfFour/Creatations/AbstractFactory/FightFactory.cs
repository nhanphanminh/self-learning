namespace ConsoleApp1.GangsOfFour.Creatations.AbstractFactory
{
    public class FightFactory : ITransportFactory
    {
        public void BuildTransport()
        {
            IVehicle vehicle = new Tank();
            IAirCraft airCraft = new Jet();
        }
    }
}
