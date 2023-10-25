using Calc.Data;
using Calc.Data.Model;
using Calc.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly IRepository _repo;
        public AddController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> Sum(SumReq model)
        {
            var result = model.First + model.Second;
            var dbModel = new SumLog()
            {
                First = model.First,
                Second = model.Second,
                Sum = result,
            };
            await _repo.Context.AddAsync(dbModel);
            await _repo.Context.SaveChangesAsync();

            return Ok(result);
        }
    }
}
