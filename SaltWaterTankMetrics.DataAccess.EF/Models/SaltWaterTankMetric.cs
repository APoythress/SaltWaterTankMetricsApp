using System;
using System.Collections.Generic;

namespace SaltWaterTankMetrics.DataAccess.EF.Models
{
    public partial class SaltWaterTankMetric
    {
        public int TankId { get; set; }
        public decimal? SaltWaterTemp { get; set; }
        public decimal? SaltWaterPh { get; set; }
        public decimal? SaltWaterNh3 { get; set; }
        public decimal? SaltWaterDkh { get; set; }
    }
}
