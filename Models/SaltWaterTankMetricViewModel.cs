using Microsoft.AspNetCore.Mvc;
using SaltWaterTankMetrics.DataAccess.EF.Context;
using SaltWaterTankMetrics.DataAccess.EF.Models;
using SaltWaterTankMetrics.DataAccess.EF.Repositories;

namespace SaltWaterTankMetricsApp.Models
{
    public class SaltWaterTankMetricViewModel
    {
        // Same properties from the EF class go in here
        // Pass this class on the view

        private SaltWaterTankMetricRepository? _repo;
        public List<SaltWaterTankMetric>? MetricsList { get; set; }
        public SaltWaterTankMetric? CurrentMetric { get; set; }

        public SaltWaterTankMetricViewModel(SaltwaterTankContext context)
        {
            _repo = new SaltWaterTankMetricRepository(context);
            MetricsList = GetAllMetrics();
            CurrentMetric = MetricsList.FirstOrDefault();
        }

        public SaltWaterTankMetricViewModel(SaltwaterTankContext context, int tankID)
        {
            if (tankID > 0)
            {
                CurrentMetric = GetMetric(tankID);
            } else
            {
                CurrentMetric = new SaltWaterTankMetric();
            }
        }
        
        public void SaveMetrics(SaltWaterTankMetric tankMetric)
        {
            
            if (tankMetric.TankId > 0)
            {
                _repo.Update(tankMetric);
            }
            else
            {
                tankMetric.TankId = _repo.Create(tankMetric);
            }

            MetricsList = GetAllMetrics();
            CurrentMetric = GetMetric(tankMetric.TankId);
        }

        public void DeleteMetrics(int tankID)
        {
            _repo.Delete(tankID);
            MetricsList = _repo.GetAllMetrics();
            CurrentMetric = GetMetric(tankID);
        }

        public List<SaltWaterTankMetric> GetAllMetrics()
        {
            return _repo.GetAllMetrics();
        }

        public SaltWaterTankMetric GetMetric(int tankID)
        {
            return _repo.GetMetricsByID(tankID);
        }
    }
}
