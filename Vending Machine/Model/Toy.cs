using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Model
{
    public class Toy : Product
    {
        public string ToyType { get; set; }

        public override string Examine()
        {
            return $"Toy: {Name} \t- Price: {Price} SEK \t- Type: {ToyType}";
        }

        public override string Use()
        {
            return $"Have fun with your new {Name} toy!";
        }


    }
}
