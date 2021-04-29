
**ASP.NET Core Concepts**

Program.cs
ConfigureHostBuilder().Build().Run();

ConfigureHostBuilder()
{
  Host.CreateDefaultBuilder(arg)
  .ConfigureWebHostDefaults(webBuilder=>webBuilder.UseStartup<Startup>();   //Injecting StartupClass dependency
}

ConfigureService(IServiceCollections services)  //Used to register all the dependent services[class, Interface] using 3 scopes. AddTransient(), AddSingleton(),AddScoped().  This method is called by the runtime and used to add services to the container.

Configure(IAppBuilder app, IWebHostEnvironment env)   //Used to configure all middlewares, Endpoints. This method is called by the runtime and used to configure the HTTP request pipeline.

app.UseHsts()    //Https Strict Transport Security protocol. Not recommended for dev env since we want to reflect the code changes immediately after build.

###.NET Core Middleware Pipeline ###

<img width="898" alt="Screen Shot 2021-04-27 at 5 10 53 PM" src="https://user-images.githubusercontent.com/74425320/116320889-b176c180-a77e-11eb-888a-e6ab8e08f92d.png">

![Blog-Diagram-Middleware-Pipeline](https://user-images.githubusercontent.com/74425320/116319693-986d1100-a77c-11eb-8b7c-3b34ded31584.png)

![MiddlewareSequence](https://user-images.githubusercontent.com/74425320/116319938-f4d03080-a77c-11eb-84a0-fe8d5c6f36fc.png)

**Referenced From MS website**

<img width="724" alt="Screen Shot 2021-04-27 at 5 34 57 PM" src="https://user-images.githubusercontent.com/74425320/116321036-f864b700-a77e-11eb-8d43-a53c42359c1f.png">

<img width="722" alt="Screen Shot 2021-04-27 at 5 35 11 PM" src="https://user-images.githubusercontent.com/74425320/116321044-fbf83e00-a77e-11eb-821f-6751be45caca.png">

**Action Results:**

public IActionResult Index()
{
    return Created("url", data c# object);       //201
    return Ok() //200
    return NoContent().  //204
    return NotFound();     //404
    return BadRequest();    //400
    return Unauthorized();  //401
    
    return CreatedAtActionResult(new(){});
    return OkObjectResult(new(){});
    return NotFoundObjectResult(new(){});
    return BadRequestObjectResult(new(){});
    
}

**RedirectResults**. Need to permanant 301 to false

public IActionResult Index()
{
    return Redirect("google.com");
    return LocalRedirect("Controller/Action");
    return RedirectAction("Action","Controller");
}

**FileResults**

public IActionResult Index()
{
    return File("FilePath", "applicaiton/pdf");
    return FileContentResult("ByteContent", "application/pdf");
    return PhysicalFileResult("PhysicalFilePath", "applicaiton/pdf");
    return VirtualFileResult("VirtualFilePath", "applicaiton/pdf");
}

**ContentResult**
public IActionResult Index()
{
    return Content("Hello World");
}

**JsonResult**

public IActionResult Index()
{
    return Json(c# object);
}

**ViewResult**

public IActionResult Index()
{
  
    return View();
    return PartialView();
}
