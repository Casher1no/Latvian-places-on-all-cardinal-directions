using BackEnd_LatvianMap.DI;
using BackEnd_LatvianMap.LatvianPlaces.Application.Cardinals;
using BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Persistence.csv;
using BackEnd_LatvianMap.LatvianPlaces.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Controllers
{
    [Route("api/latvia/cardinal-places")]
    [ApiController]
    public class LatvianCardinalPlacesController : ControllerBase
    {

        [HttpGet]
        public Dictionary<string, Centroids> GetCardinalLatvianPlaces()
        {
            LatvianCardinalPlacesService service = new LatvianCardinalPlacesService(DataAccessFactory.LatvianCardinalPlacesRepository());

            return service.Invoke();
        }
        
    }
}