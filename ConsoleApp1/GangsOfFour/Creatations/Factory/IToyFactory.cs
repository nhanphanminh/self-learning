namespace ConsoleApp1.GangsOfFour.Creatations.Factory
{
    public enum ToyType
    {
        duck,
        car
    }

    public interface IToyFactory
    {
        IToys GeToys(ToyType toyType);
    }
}
