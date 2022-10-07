using System;
using System.Collections.Generic;

namespace SaltWaterTankMetrics.DataAccess.EF.Models
{
    public partial class SaltWaterTankMetric
    {
        public int MetricsID { get; set; }
        public DateTime MetricsDate { get; set; }
        public decimal SaltWaterTemp { get; set; }
        public decimal SaltWaterPH { get; set; }
        public decimal SaltWaterNH3 { get; set; }
        public decimal SaltWaterDKH { get; set; }

        public SaltWaterTankMetric(int metricID, DateTime date, decimal saltWaterTemp, decimal saltWaterPh, decimal saltWaterNh3, decimal saltWaterDkh)
        {
            MetricsID = metricID;
            MetricsDate = date;
            SaltWaterTemp = saltWaterTemp;
            SaltWaterPH = saltWaterPh;
            SaltWaterNH3 = saltWaterNh3;
            SaltWaterDKH = saltWaterDkh;
        }

        public SaltWaterTankMetric()
        {

        }
    }
}
