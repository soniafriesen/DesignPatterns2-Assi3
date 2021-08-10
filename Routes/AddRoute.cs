using System;

namespace Assi3
{
    class AddRoute : Route
    {
        public AddRoute(string path, Route next = null) : base(path, next) {}
        public override int Handle(int handle)
        {
            return handle + 8;
        }
    }
}
