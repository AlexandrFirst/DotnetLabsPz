using Lab_4_Dot_Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4_Dot_Net.Controllers
{
    public class StatisticsController : Controller
    {
        private const string losersTable = "LosersTable";
        private const string workersOperationsTable = "WorkersOperationsTable";
        private readonly IUnitOfWork _repository;
        public StatisticsController(IUnitOfWork repository) => this._repository = repository;

        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult GetTopLosers()
        {
            var losers = _repository.GetLosersTop();
            return View(losersTable, losers);
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult GetOperationsMadeByWorkers()
        {
            var operations = _repository.GetNumberOfAllOperationsPerformedByWorkers();
            return View(workersOperationsTable, operations);
        }
        public ActionResult GetTotalNumberOfOperations()
        {
            var totalNumber = _repository.GetAllOperationsTotalCount();
            return Content("There have been already performed " + totalNumber + " operations!");
        }
    }
}