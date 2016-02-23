using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pigpo
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public class Player
    {
        public string connectionId { get; set; }
        public string name { get; set; }
        public Position position { get; set; }
        public int left { get; set; }
        public int up { get; set; }
        public int right { get; set; }
        public int bottom { get; set; }
    }
}