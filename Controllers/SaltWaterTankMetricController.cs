using Microsoft.AspNetCore.Mvc;
using SaltWaterTankMetrics.DataAccess.EF.Context;
using SaltWaterTankMetrics.DataAccess.EF.Models;

using SaltWaterTankMetricsApp.Models;

namespace SaltWaterTankMetricsApp.Controllers
{
    public class SaltWaterTankMetricController : Controller
    {
        private readonly SaltwaterTankContext _context;

        public SaltWaterTankMetricController(SaltwaterTankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            SaltWaterTankMetricViewModel model = new(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int tankID, DateTime date, decimal waterTemp, decimal waterPH, decimal waterNH3, decimal waterDKH)
        {
            SaltWaterTankMetricViewModel model = new(_context);
            SaltWaterTankMetric tankMetrics = new(tankID, date, waterTemp, waterPH, waterNH3, waterDKH);

            model.SaveMetrics(tankMetrics);
            return View(model);
        }

        public IActionResult Update(int id)
        {
            SaltWaterTankMetricViewModel model = new(_context);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            SaltWaterTankMetricViewModel model = new(_context);

            if (id > 0)
            {
                model.DeleteMetrics(id);
            }

            return View("Index", model);
        }
    }
}
