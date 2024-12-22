using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerondaApp.Components.CsvReader;
using PerondaApp.Components.CsvReader.Extensions;
using PerondaApp.Components.DataProviders;
using PerondaApp.Data;
using PerondaApp.Data.Entities;
using PerondaApp.Data.Repositories;
using PerondaApp.Services;

// (localdb)\MSSQLLocalDB      .\sqlexpress     
//   Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True
var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
//services.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
//services.AddSingleton<IRepository<Tile>, SqlRepository<Tile>>();
services.AddSingleton<IRepository<Car>, SqlRepository<Car>>();
services.AddSingleton<IRepository<Manufacturer>, SqlRepository<Manufacturer>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IFilesProcessor, FilesProcessor>();
services.AddSingleton<ICarProvider, CarProvider>();

services.AddDbContext<PerondaAppDbContext>(options=>options
    .UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=PerondaAppStorage;Integrated Security=True;Trust Server Certificate=True"));
// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestStorage;Integrated Security=True  bez zaufania Trust Server Certificate=True
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog="Test Storage X";Integrated Security=True;Trust Server Certificate=True
// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestStorage;Integrated Security=True;Trust Server Certificate=True

// Data Source=.\SQLEXPRESS;Initial Catalog=TestStorage3;Integrated Security=True;Encrypt=True;Trust Server Certificate=True

// Data Source=.\SQLEXPRESS;Initial Catalog=PerondaAppStorage;Integrated Security=True;Trust Server Certificate=True