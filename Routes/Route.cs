using System;
/*
 * Project: Project 3/ Assi3
 * Purpose: Demonstrates visitor, CoR, Command.
 * Coder: Sonia Friesen
 * Date: Due April 13th 2021
 */
namespace Assi3
{
    class Route
    {
        private Route Next;
        private string Path;

        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }
        /*
         * Method: HandleRequest()
         * Purpose: Using CoR, output the reuilts/ process the request
         * Parameters: Request
         * Returns: int (results)
         */
        public int HandleRequest(Request request)
        {
            if (Path == request.Route)
                return Handle(request.Payload);                
            if (Next != null)
                return Next.HandleRequest(request);
            //conclusion handle the request based on the payload
            return Handle(request.Payload);
        }

        public virtual int Handle(int handle)
        {
            return 404; //default return value; will be overridden by Routes
        }
    }
}
