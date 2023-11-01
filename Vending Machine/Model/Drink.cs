using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Model
{
    public class Drink : Product
    {
        public string Flavor { get; set; }

        public override string Examine()
        {
            return $"Drink: {Name} \t- Price: {Price} SEK \t- Flavor: {Flavor}";
        }

        public override string Use()
        {
            return $"Enjoy your {Name} drink!";
        }
    }
}
