using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleRock.Models
{
    public class TrafficData 
    {
        public int id { get; set; }
        public int BotId { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoadName { get; set; }
        public string TrafficFlow { get; set; }
        public int FlowRate { get; set; }
        public int AvrageVehicleSpeed { get; set; }
   //     public TrafficData()
     //   {
             
       // }
    }

  /*  public class TrafficDataDTO
    {
        public int BotId { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoadName { get; set; }
        public string TrafficFlow { get; set; }
        public int FlowRate { get; set; }
        public int AvrageVehicleSpeed { get; set; }
            
    }*/


    public class TrafficDataContext : DbContext
    {
    
        public TrafficDataContext(DbContextOptions<TrafficDataContext> options) : base(options) { }
        public DbSet<TrafficData> TrafficDataList { get; set; }
       
    }


    public class LatestDataContext : DbContext
    {
        
        public LatestDataContext(DbContextOptions<LatestDataContext> options) : base(options) { }
        // public DbSet<TrafficData> LatestTrafficData { get;  }
        public DbSet<TrafficData> LatestTrafficData { get; set; }

    }

}

