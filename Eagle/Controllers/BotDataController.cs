using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EagleRock.Models;

namespace EagleRock.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BotDataController : ControllerBase
    {

        TrafficDataContext _context;

        public BotDataController(TrafficDataContext context)
        {


            
            _context = context;
        }

     /*   [HttpGet]
        public IEnumerable<TrafficData> Get()
        {
            return _context.TrafficDataList
                .AsNoTracking()
                .ToList();
        }*/

    /*    [HttpGet("{id}")]
        public ActionResult<TrafficData> GetById(int id)
        {

                var tData= _context.TrafficDataList
                       .AsNoTracking()
                           .SingleOrDefault(p => p.id == id);



                   if (tData is not null)
                   {
                       return tData;
                   }
                   else
                   {
                       return NotFound();
                   }
        }

        */



        /*   [HttpPost]
           public async Task<ActionResult<TrafficData>> PostTrafficData(TrafficData newTData)
           {
              if (ModelState.IsValid)
              {
                  _context.TrafficDataList.Add(newTData);
                  await _context.SaveChangesAsync();
              }

               return CreatedAtAction(nameof(GetById), new { id = newTData.id }, newTData);
           }
        */


        [HttpPost]
        public async Task<HttpResponseMessage> PostTrafficData(TrafficData newTData)
        {
            if (ModelState.IsValid)
            {
                _context.TrafficDataList.Add(newTData);
                await _context.SaveChangesAsync();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }



        }


        }
    }


