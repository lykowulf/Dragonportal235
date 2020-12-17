using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dragonportal235.Data;
using Dragonportal235.Models;
using Dragonportal235.Models.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dragonportal235.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<FPUser> _userManager;

        public ChartsController(ApplicationDbContext context, UserManager<FPUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<JsonResult> BankPieChart()
        {
            List<ChartModel> result = new List<ChartModel>();

            var user = await _userManager.GetUserAsync(User);
            var accounts = _context.BankAccount.Where(b => b.HouseholdId == user.HouseholdId).ToList();
            foreach (var bank in accounts)
            {
                result.Add(new ChartModel
                {
                    Label = bank.Name,
                    Value = bank.CurrentBalance,
                });
            }
            return Json(result);
        }

        public JsonResult transactionChart()
        {
            List<TransactionChartModel> result = new List<TransactionChartModel>();

            var categories = _context.Category.ToList();
            foreach (var cat in categories)
            {
                result.Add(new TransactionChartModel
                {

                });
            }
            return Json(result);
        }
    }
}
