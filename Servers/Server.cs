using System;
using System.Collections.Generic;
/*
 * Project: Project 3/ Assi3
 * Purpose: Demonstrates visitor, CoR, Command.
 * Coder: Sonia Friesen
 * Date: Due April 13th 2021
 */
namespace Assi3
{
    class Server : AbstractServer
    {
        private Request request;
        private Route baseRoute;        

        public Server()
        {
            Route parent = new Route("");
            Route a = new MultiplyRoute("/mul", parent);
            Route b = new Multiply4Route("/mul/4", a);
            Route c = new AddRoute("/add", b);
            baseRoute = c;
        }
        //accepting the Query 
        public bool Accept(Query query)
        {
            return query.ServerStatus(this);
        }

        //check if it has a request or not
        public bool isAvaliable()
        {
            if (request != null)
            {
                return false;
            }
            else
                return true;
        }
        //setter for the request
        public void SetRequest(Request request)
        {
           this.request = request;
        }

        /*
         * Method: ProcessWork()
         * Purpose: Using CoR, output the reuilts/ process the request
         * Parameters: Nothing
         * Returns: Nothing
         */
        public void ProcessWork()
        {
            Console.WriteLine($"Path: \t{request.Route}");
            Console.WriteLine($"Input: \t{request.Payload}");            
            int results = 0;
            //Route route = new Route(request.Route);            
            results = request.Execute(baseRoute); //having the request run 
            //results =  route.HandleRequest(request); //directly having the route handle request
            Console.WriteLine($"Results: {results}");
           
            //server did its work,
            //clear the request so we can accept anotehr
            request = null;
        }
    }
}
