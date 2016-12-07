using System.Net.Http;
using System.Web.Mvc;
using LMS_WebAPP_ServiceHelpers;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementApp.Controllers
{
    public class ApplyLeaveController : Controller
    {
        static HttpClient client = new HttpClient();


        // GET: LeaveTransection
        public async Task<ActionResult> ApplyLeave()
        {
            EmployeeLeaveTransactionManagement ELTM = new EmployeeLeaveTransactionManagement();
            var res = await ELTM.GetProductAsync();

            return View(res);
        }

        public ActionResult AddLeave()
        {
            return View();

        }
    }
}