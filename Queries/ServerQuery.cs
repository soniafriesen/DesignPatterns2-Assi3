using System;
/*
 * Project: Project 3/ Assi3
 * Purpose: Demonstrates visitor, CoR, Command.
 * Coder: Sonia Friesen
 * Date: Due April 13th 2021
 */
namespace Assi3
{
    class ServerQuery : Query
    {
        public bool ServerStatus(Server s)
        {
            return s.isAvaliable();
        }
    }
}
