using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltWaterTankMetrics.DataAccess.EF.ngModels
{
    public class ngSaltWaterTankMetric
    {
        public int TankId { get; set; }
        public decimal? SaltWaterTemp { get; set; }
        public decimal? SaltWaterPh { get; set; }
        public decimal? SaltWaterNh3 { get; set; }
        public decimal? SaltWaterDkh { get; set; }

        public ngSaltWaterTankMetric(int tankId, decimal saltWaterTemp,  decimal saltWaterPH, decimal saltWaterNH3, decimal saltWaterDKH)
        {
            TankId = tankId;
            SaltWaterTemp = saltWaterTemp;
            SaltWaterPh = saltWaterPH;
            SaltWaterNh3 = saltWaterNH3;
            SaltWaterDkh = saltWaterDKH;
        }

        public ngSaltWaterTankMetric()
        {

        }
    }
}
