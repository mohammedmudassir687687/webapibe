using Microsoft.AspNetCore.Mvc;
using ReactWebApi.Data;
using ReactWebApi.Models;

namespace ReactWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GarageController : Controller
    {
        private IRepository _repo;
        public GarageController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<GarageModel>> GetGarage()
        {
            return await _repo.GetGarage();
        }

        [HttpGet]
        public string Getstring()
        {
            return "hello";
        }
    }
}
