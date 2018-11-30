using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GangsOfFour.Creatations.Factory
{
    public class ToyFactory:IToyFactory
    {
        public IToys GeToys(ToyType toyType)
        {
            switch (toyType)
            {
                case ToyType.duck:
                    return new DuckToy();
                case ToyType.car:
                    return new CarToy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(toyType), toyType, null);
            }
        }
    }
}
