using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EagleRock.Models;

namespace EagleRock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrafficDataController : ControllerBase

    {
        LatestDataContext _context;



        public TrafficDataController(LatestDataContext context)
        {
            
            _context = context;

        }

            [HttpGet]
            public IEnumerable<TrafficData> Get()
            {
                try
                {
                    var tData = _context.LatestTrafficData
                            .AsNoTracking()
                            .ToList();



                    if (tData is not null)
                    {
                        return tData;
                    }
                    else
                    {
                    return  new List<TrafficData>();
                    }

                }
                catch(Exception ex)
                {
                    return new List<TrafficData>();
                }
            }

        
    }
}

