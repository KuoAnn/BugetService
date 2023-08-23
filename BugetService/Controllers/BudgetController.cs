using Microsoft.AspNetCore.Mvc;

namespace BugetService.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class BudgetController : ControllerBase
    {
        [HttpPost(Name = "Budget")]
        public decimal Budget()
        {
            return 1000;
        }
    }
}