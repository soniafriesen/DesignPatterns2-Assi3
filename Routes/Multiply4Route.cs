using System;

namespace Assi3
{
    class Multiply4Route : Route
    {
        public Multiply4Route(string path, Route next = null) : base(path, next) {}
        public override int Handle(int handle)
        {
            return handle * 4;
        }
    }
}
