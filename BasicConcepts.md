
**ASP.NET Core Concepts**

Program.cs
ConfigureHostBuilder().Build().Run();

ConfigureHostBuilder()
{
  Host.CreateDefaultBuilder(arg)
  .ConfigureWebHostDefaults(webBuilder=>webBuilder.UseStartup<Startup>();   //Injecting StartupClass dependency
}

ConfigureService(IServiceCollections services)  //Used to register all the dependent services[class, Interface] using 3 scopes. AddTransient(), AddSingleton(),AddScoped()

Configure(IAppBuilder app, IWebHostEnvironment env)   //Used to configure all middlewares, Endpoints. 

app.UseHsts()    //Https Strict Transport Security protocol. Not recommended for dev env since we want to reflect the code changes immediately after build.

###.NET Core Middleware Pipeline ###

<img width="898" alt="Screen Shot 2021-04-27 at 5 10 53 PM" src="https://user-images.githubusercontent.com/74425320/116320889-b176c180-a77e-11eb-888a-e6ab8e08f92d.png">

![Blog-Diagram-Middleware-Pipeline](https://user-images.githubusercontent.com/74425320/116319693-986d1100-a77c-11eb-8b7c-3b34ded31584.png)

![MiddlewareSequence](https://user-images.githubusercontent.com/74425320/116319938-f4d03080-a77c-11eb-84a0-fe8d5c6f36fc.png)

**Referenced From MS website**

<img width="724" alt="Screen Shot 2021-04-27 at 5 34 57 PM" src="https://user-images.githubusercontent.com/74425320/116321036-f864b700-a77e-11eb-8d43-a53c42359c1f.png">

<img width="722" alt="Screen Shot 2021-04-27 at 5 35 11 PM" src="https://user-images.githubusercontent.com/74425320/116321044-fbf83e00-a77e-11eb-821f-6751be45caca.png">


