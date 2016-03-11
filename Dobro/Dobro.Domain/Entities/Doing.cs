using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobro.Domain.Entities
{
    public class Doing
    {
        public int DoingId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Metro { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }
    }

}
