using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmd
{
    public class Alias : Command
    {
        public Alias(string command)
            : base(command)
        {
        }

        protected override string GetValueCommand()
        {
            return "kj";
        }

        public override void Execute()
        {

        }

    }
}
