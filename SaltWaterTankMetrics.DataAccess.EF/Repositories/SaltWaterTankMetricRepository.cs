using SaltWaterTankMetrics.DataAccess.EF.Context;
using SaltWaterTankMetrics.DataAccess.EF.Models;
using SaltWaterTankMetrics.DataAccess.EF.ngModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltWaterTankMetrics.DataAccess.EF.Repositories
{
    public class SaltWaterTankMetricRepository
    {
        // Database Context connection
        private SaltwaterTankContext _dbContext;

        public SaltWaterTankMetricRepository(SaltwaterTankContext context)
        {
            _dbContext = context;
        }

        public int Create(SaltWaterTankMetric metrics)
        {
            _dbContext.Add(metrics);
            _dbContext.SaveChanges();
            return metrics.TankId;
        }

        public int Update(SaltWaterTankMetric metrics)
        {
            SaltWaterTankMetric? existingMetrics = _dbContext.SaltWaterTankMetrics.Find(metrics.TankId);

            existingMetrics.SaltWaterTemp = metrics.SaltWaterTemp;
            existingMetrics.SaltWaterPh = metrics.SaltWaterPh;
            existingMetrics.SaltWaterNh3 = metrics.SaltWaterNh3;
            existingMetrics.SaltWaterDkh = metrics.SaltWaterDkh;

            _dbContext.SaveChanges();
            return existingMetrics.TankId;
        }

        public bool Delete(int tankID)
        {
            SaltWaterTankMetric metrics = _dbContext.SaltWaterTankMetrics.Find(tankID);

            _dbContext?.Remove(metrics);
            _dbContext.SaveChanges();

            return true;
        }

        public List<SaltWaterTankMetric> GetAllMetrics()
        {
            List<SaltWaterTankMetric> metricsList = _dbContext.SaltWaterTankMetrics.ToList();
            return metricsList;
        }

        public SaltWaterTankMetric GetMetricsByID(int tankID)
        {
            SaltWaterTankMetric metrics = _dbContext.SaltWaterTankMetrics.Find(tankID);
            return metrics;
        }
    }
}
