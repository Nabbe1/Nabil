﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NabilsRondSystem
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
