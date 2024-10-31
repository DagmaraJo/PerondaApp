using Microsoft.Extensions.DependencyInjection;
using PerondaApp;
//using PerondaApp.Data.Components.CsvReader;
using PerondaApp.Data.Components.DataProviders;
using PerondaApp.Entities;
using PerondaApp.Repositories;
using PerondaApp.Services;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<BusinessPartner>, ListRepository<BusinessPartner>>();
services.AddSingleton<IRepository<Tile>, ListRepository<Tile>>();
services.AddSingleton<ITilesProvider, TilesProvider>();
//services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IActions, Actions>();
services.AddSingleton<IUserCommunication, UserCommunication>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();