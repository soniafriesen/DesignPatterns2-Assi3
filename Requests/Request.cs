using System;
/*
 * Project: Project 3/ Assi3
 * Purpose: Demonstrates visitor, CoR, Command.
 * Coder: Sonia Friesen
 * Date: Due April 13th 2021
 */
namespace Assi3
{
    class Request : Command
    {
        public string Route;
        public int Payload;
        public Request(string route, int payload) {
            Route = route;
            Payload = payload;
        }  
        public int Execute(Route route)
        {
            return route.HandleRequest(this);
        }
    }
}
