using Moq;
using EagleRock.Controllers;
using EagleRock.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EagleRockTest;


    [TestClass]
    public class TrafficDataController_test
    {

    public readonly DbContextOptions<LatestDataContext> dbContextOptions;

    public TrafficDataController_test()
    {
        dbContextOptions = new DbContextOptionsBuilder<LatestDataContext>()
              .UseInMemoryDatabase(databaseName: "db")
              .Options;
    }



    [TestMethod]
    public void GetTrafficData_Test()
    {


        //Arrange
        string js1 = @"{
    
    'botId': '789',
    'location': '-27.512881, 152.937386',
    'timestamp': '2022-07-29T20:44:45',
    'roadName': 'Kenmore Road',
    'trafficFlow': 'North',
    'flowRate': '11',
    'avrageVehicleSpeed': '52'
  }";

        string js2 = @"{
            
    'botId': '123',
    'location': '-27.490616, 152.986170',
    'timestamp': '2022-07-29T22:15:17.326',
    'roadName': 'Moggil Road',
    'trafficFlow': 'West',
    'flowRate': '15',
    'avrageVehicleSpeed': '59'
  }";

        string js3 = @"{
           
    'botId': '456',
    'location': '-27.50149, 152.93078',
    'timestamp': '2022-07-30T05:59:03.866',
    'roadName': 'Brookfield Road',
    'trafficFlow': 'South',
    'flowRate': '20',
    'avrageVehicleSpeed': '60'
  }";
        var data = new List<TrafficData>();

        data.Add(JsonConvert.DeserializeObject<TrafficData>(js1));

        data.Add(JsonConvert.DeserializeObject<TrafficData>(js2));
        data.Add(JsonConvert.DeserializeObject<TrafficData>(js3));
        
        
        var dbContext = new LatestDataContext(dbContextOptions);

        for (int i = 0; i < data.Count(); i++)
        {

              dbContext.LatestTrafficData.Add(data[i]);

        }
          
        dbContext.SaveChanges();
        var controller = new TrafficDataController(dbContext);

    //ACT
        var result =  controller.Get();

        //Assert
        try
        {
            Assert.AreEqual(data.Count(), result.Count());
            List<TrafficData> tdl = result.ToList<TrafficData>();

            //some random checking:
            //better to override TrafficData Equals and compare all fields
            Assert.AreEqual(data[1].BotId, tdl[1].BotId);
            Assert.AreEqual(data[2].Location, tdl[2].Location);

        }
        catch(Exception ex)
        {
            Console.WriteLine("---------" + ex.Message);
        }


    }
}


