using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCalculator.Lib
{
    public interface ICalculatorCommand
    {
        public string? Execute(IEnumerable<Car> cars);
    }
}
