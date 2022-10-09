using SaltWaterTankMetrics.DataAccess.EF.Context;
using SaltWaterTankMetrics.DataAccess.EF.Models;
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
            return metrics.MetricsID;
        }

        public SaltwaterTankContext Get_dbContext()
        {
            return _dbContext;
        }

        public int Update(SaltWaterTankMetric metrics)
        {
            SaltWaterTankMetric existingMetrics = _dbContext.SaltWaterTankMetrics.Find(metrics.MetricsID);

            existingMetrics.SaltWaterTemp = metrics.SaltWaterTemp;
            existingMetrics.SaltWaterPH = metrics.SaltWaterPH;
            existingMetrics.SaltWaterNH3 = metrics.SaltWaterNH3;
            existingMetrics.SaltWaterDKH = metrics.SaltWaterDKH;

            _dbContext.SaveChanges();
            return existingMetrics.MetricsID;
        }

        public bool Delete(int MetricsID)
        {
            SaltWaterTankMetric metrics = _dbContext.SaltWaterTankMetrics.Find(MetricsID);

            _dbContext.Remove(metrics);
            _dbContext.SaveChanges();

            return true;
        }

        public List<SaltWaterTankMetric> GetAllMetrics()
        {
            List<SaltWaterTankMetric> metricsList = _dbContext.SaltWaterTankMetrics.ToList();
            return metricsList;
        }

        public SaltWaterTankMetric GetMetricsByID(int metricsID)
        {
            SaltWaterTankMetric metrics = _dbContext.SaltWaterTankMetrics.Find(metricsID);
            return metrics;
        }
    }
}
