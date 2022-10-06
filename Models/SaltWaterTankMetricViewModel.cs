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

        private SaltWaterTankMetricRepository _repo;
        public List<SaltWaterTankMetric> MetricsList { get; set; }
        public SaltWaterTankMetric CurrentMetric { get; set; }

        public SaltWaterTankMetricViewModel(SaltwaterTankContext context)
        {
            _repo = new SaltWaterTankMetricRepository(context);
            MetricsList = GetAllMetrics();
            CurrentMetric = MetricsList.FirstOrDefault();
        }

        public SaltWaterTankMetricViewModel(SaltwaterTankContext context, int MetricsID)
        {
            if (MetricsID > 0)
            {
                CurrentMetric = GetMetric(MetricsID);
            } else
            {
                CurrentMetric = new SaltWaterTankMetric();
            }
        }
        
        public void SaveMetrics(SaltWaterTankMetric tankMetric)
        {
            
            if (tankMetric.MetricsID > 0)
            {
                _repo.Update(tankMetric, _repo.Get_dbContext());
            }
            else
            {
                tankMetric.MetricsID = _repo.Create(tankMetric);
            }

            MetricsList = GetAllMetrics();
            CurrentMetric = GetMetric(tankMetric.MetricsID);
        }

        public void DeleteMetrics(int MetricsID)
        {
            _repo.Delete(MetricsID);
            MetricsList = _repo.GetAllMetrics();
            CurrentMetric = GetMetric(MetricsID);
        }

        public List<SaltWaterTankMetric> GetAllMetrics()
        {
            return _repo.GetAllMetrics();
        }

        public SaltWaterTankMetric GetMetric(int MetricsID)
        {
            return _repo.GetMetricsByID(MetricsID);
        }
    }
}
