using System;

namespace Assi3
{
    interface AbstractServer
    {
        bool isAvaliable();
        bool Accept(Query query);
        void SetRequest(Request request);
        void ProcessWork();
    }
}
