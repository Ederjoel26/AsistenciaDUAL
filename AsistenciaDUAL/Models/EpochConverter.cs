﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenciaDUAL.Models
{
    public static class EpochConverter
    {
        public static int DateToEpoch(DateTime date)
        {
            TimeSpan time = date - new DateTime(1970,1,1);
            return (int)time.TotalSeconds;
        }

        public static string EpochToDate(int epochSeconds)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epochSeconds);
            return dateTimeOffset.ToString();
        }
    }
}
