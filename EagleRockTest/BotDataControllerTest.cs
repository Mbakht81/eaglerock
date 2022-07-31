using Moq;
using EagleRock.Controllers;
using EagleRock.Models;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace EagleRockTest;


[TestClass]
public class BotDataController_test
{
    public readonly DbContextOptions<TrafficDataContext> dbContextOptions;

    public BotDataController_test()
    {
        dbContextOptions = new DbContextOptionsBuilder<TrafficDataContext>()
              .UseInMemoryDatabase(databaseName: "db")
              .Options;
    }



   



    [TestMethod]
    public  async Task postBotDataTest_ShouldbeOK()
    {


        //Arrange

        try
        {

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

            //data.AsQueryable();

            var dbContext = new TrafficDataContext(dbContextOptions);
            var controller = new BotDataController(dbContext);


            
            /*     var mockContext = new Mock<TrafficDataContext>();
                 var mockSet = new Mock<DbSet<TrafficData>>();
                 mockContext.Setup(m => m.TrafficDataList).Returns(mockSet.Object);
            */



            //ACT
            for (int i = 0; i < data.Count(); i++)
            {
                var result = await controller.PostTrafficData(data[i]);
                //Assert
                Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            }
         

        }
        catch(Exception ex)
        {
            Console.WriteLine("------------------------"+ex.Message);
        }

    }


   




}
