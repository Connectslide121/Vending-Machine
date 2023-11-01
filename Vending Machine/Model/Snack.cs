using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Model
{
    public class Snack : Product
    {
        public string Type { get; set; }

        public override string Examine()
        {
            return $"Snack: {Name} \t- Price: {Price} SEK \t- Type: {Type}";
        }

        public override string Use()
        {
            return $"Enjoy your {Name} snack!";
        }
    }
}
