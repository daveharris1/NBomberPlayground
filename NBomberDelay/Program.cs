using NBomber.CSharp;

namespace NBomberDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scenario = Scenario.Create("hello_world_scenario", async context =>
            {
                var guid = Guid.NewGuid();
                Console.WriteLine($"Executing a new scenerio. ID is: {guid}");
                // you can define and execute any logic here,
                // for example: send http request, SQL query etc
                // NBomber will measure how much time it takes to execute your logic
                await Task.Delay(1_000);
                Console.WriteLine($"{guid} handled on thread {Thread.CurrentThread.ManagedThreadId}");

                return Response.Ok();
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: 200,
                                  interval: TimeSpan.FromSeconds(1),
                                  during: TimeSpan.FromSeconds(30))
            );

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }
    }
}