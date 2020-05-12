using System;
using System.Collections.Generic;
using System.Text;

namespace NabilsRondSystem
{
    public interface IRondservice
    {
        string TestInsert(string Plats, string Time, string Date, string Felrapport, string Anvandare);
    }
}
