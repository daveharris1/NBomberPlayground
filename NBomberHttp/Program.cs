using HttpHelper;
using NBomber.CSharp;
using System;
using static System.Net.WebRequestMethods;

namespace NBomberHttp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region //scenario 1
            //using var httpClient = new HttpClient();

            //var scenario = Scenario.Create("http_scenario_1", async context =>
            //{
            //    var response = await httpClient.GetAsync("https://nbomber.com");

            //    var responseBody = await response.Content.ReadAsStringAsync();

            //    return Response.Ok();
            //})
            //.WithoutWarmUp()
            //.WithLoadSimulations(
            //    Simulation.Inject(rate: 500,
            //                      interval: TimeSpan.FromSeconds(1),
            //                      during: TimeSpan.FromSeconds(1))
            //);

            //NBomberRunner
            //    .RegisterScenarios(scenario)
            //    .Run();
            #endregion

            #region//scenario 2

            //var httpHelper = new HttpCaller();

            //var scenario = Scenario.Create("http_scenario_2", async context =>
            //{
            //    var response = await httpHelper.Get("https://nbomber.com");

            //    return Response.Ok();
            //})
            //.WithoutWarmUp()
            //.WithLoadSimulations(
            //Simulation.Inject(rate: 10,
            //          interval: TimeSpan.FromSeconds(1),
            //          during: TimeSpan.FromSeconds(30))
            //);

            //NBomberRunner
            //    .RegisterScenarios(scenario)
            //    .Run();
            #endregion

            #region//scenario 3

            //var httpHelper = new HttpCaller();

            //var scenario = Scenario.Create("http_scenario_3", async context =>
            //{
            //    var response = await httpHelper.Get("https://nbomber.com");

            //    return Response.Ok();
            //})
            //.WithoutWarmUp()
            //.WithLoadSimulations(

            //Simulation.RampingConstant(copies: 25, during: TimeSpan.FromSeconds(30)),

            //Simulation.KeepConstant(copies: 25, during: TimeSpan.FromSeconds(60))
            //);

            //NBomberRunner
            //    .RegisterScenarios(scenario)
            //    .Run();
            #endregion

            #region//scenario 4

            var httpHelper = new HttpCaller();

            var scenario = Scenario.Create("http_scenario_3", async context =>
            {
                var guid = Guid.NewGuid();
                Console.WriteLine($"Executing a new scenerio. ID is: {guid}");

                var response = await httpHelper.Get("https://nbomber.com");
                Console.WriteLine($"Response returned for {guid}. Handled on thread {Thread.CurrentThread.ManagedThreadId}");
                return Response.Ok();
            })
            .WithoutWarmUp()
            .WithLoadSimulations(


            Simulation.RampingInject(rate: 2,
                                     interval: TimeSpan.FromSeconds(1),
                                     during: TimeSpan.FromSeconds(1)),


            Simulation.Inject(rate: 2,
                              interval: TimeSpan.FromSeconds(1),
                              during: TimeSpan.FromSeconds(30))
            );

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
            #endregion
        }
    }
}