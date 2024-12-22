using Microsoft.EntityFrameworkCore;
using PerondaApp.Data.Entities;

namespace PerondaApp.Data;

public class PerondaAppDbContext : DbContext
{
    public PerondaAppDbContext(DbContextOptions<PerondaAppDbContext> options)
        : base(options) { }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Manufacturer> Manufacturer { get; set; }

    //public DbSet<Tile> Tiles => Set<Tile>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.LogTo(Console.WriteLine);
}
/*
info: 07-12-2024 10:59:20.298 CoreEventId.ContextInitialized[10403] (Microsoft.EntityFrameworkCore.Infrastructure)
      Entity Framework Core 6.0.30 initialized 'PerondaAppDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.30' with options: None
dbug: 07-12-2024 10:59:21.283 RelationalEventId.ConnectionOpening[20000] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opening connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:29.887 RelationalEventId.ConnectionOpened[20001] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opened connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:29.913 RelationalEventId.CommandCreating[20103] (Microsoft.EntityFrameworkCore.Database.Command)
      Creating DbCommand for 'ExecuteNonQuery'.
dbug: 07-12-2024 10:59:29.992 RelationalEventId.CommandCreated[20104] (Microsoft.EntityFrameworkCore.Database.Command)
      Created DbCommand for 'ExecuteNonQuery' (94ms).
dbug: 07-12-2024 10:59:30.013 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: 07-12-2024 10:59:30.566 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (207ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
dbug: 07-12-2024 10:59:30.569 RelationalEventId.ConnectionClosing[20002] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closing connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:30.575 RelationalEventId.ConnectionClosed[20003] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closed connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:30.578 RelationalEventId.CommandCreating[20103] (Microsoft.EntityFrameworkCore.Database.Command)
      Creating DbCommand for 'ExecuteScalar'.
dbug: 07-12-2024 10:59:30.578 RelationalEventId.CommandCreated[20104] (Microsoft.EntityFrameworkCore.Database.Command)
      Created DbCommand for 'ExecuteScalar' (0ms).
dbug: 07-12-2024 10:59:30.578 RelationalEventId.ConnectionOpening[20000] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opening connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:30.580 RelationalEventId.ConnectionOpened[20001] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opened connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:30.581 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']

      IF EXISTS
          (SELECT *
           FROM [sys].[objects] o
           WHERE [o].[type] = 'U'
           AND [o].[is_ms_shipped] = 0
           AND NOT EXISTS (SELECT *
               FROM [sys].[extended_properties] AS [ep]
               WHERE [ep].[major_id] = [o].[object_id]
                   AND [ep].[minor_id] = 0
                   AND [ep].[class] = 1
                   AND [ep].[name] = N'microsoft_database_tools_support'
          )
      )
      SELECT 1 ELSE SELECT 0
info: 07-12-2024 10:59:37.720 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (7,139ms) [Parameters=[], CommandType='Text', CommandTimeout='30']

      IF EXISTS
          (SELECT *
           FROM [sys].[objects] o
           WHERE [o].[type] = 'U'
           AND [o].[is_ms_shipped] = 0
           AND NOT EXISTS (SELECT *
               FROM [sys].[extended_properties] AS [ep]
               WHERE [ep].[major_id] = [o].[object_id]
                   AND [ep].[minor_id] = 0
                   AND [ep].[class] = 1
                   AND [ep].[name] = N'microsoft_database_tools_support'
          )
      )
      SELECT 1 ELSE SELECT 0
dbug: 07-12-2024 10:59:37.723 RelationalEventId.ConnectionClosing[20002] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closing connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:37.724 RelationalEventId.ConnectionClosed[20003] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closed connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:39.039 CoreEventId.QueryCompilationStarting[10111] (Microsoft.EntityFrameworkCore.Query)
      Compiling query expression:
      'DbSet<Car>()
          .FirstOrDefault(c => c.Name == __name_0)'
dbug: 07-12-2024 10:59:40.220 CoreEventId.QueryExecutionPlanned[10107] (Microsoft.EntityFrameworkCore.Query)
      Generated query execution expression:
      'queryContext => new SingleQueryingEnumerable<Car>(
          (RelationalQueryContext)queryContext,
          RelationalCommandCache.SelectExpression(
              Projection Mapping:
                  EmptyProjectionMember -> Dictionary<IProperty, int> { [Property: Car.Id (int) Required PK AfterSave:Throw ValueGenerated.OnAdd, 0], [Property: Car.City (int) Required, 1], [Property: Car.Combined (int) Required, 2], [Property: Car.Cylinders (int) Required, 3], [Property: Car.Displacement (double) Required, 4], [Property: Car.Highway (int) Required, 5], [Property: Car.Manufacturer (string), 6], [Property: Car.Name (string), 7], [Property: Car.Year (int) Required, 8] }
              SELECT TOP(1) c.Id, c.City, c.Combined, c.Cylinders, c.Displacement, c.Highway, c.Manufacturer, c.Name, c.Year
              FROM Cars AS c
              WHERE c.Name == @__name_0),
          Func<QueryContext, DbDataReader, ResultContext, SingleQueryResultCoordinator, Car>,
          PerondaApp.Data.PerondaAppDbContext,
          False,
          False,
          True
      )
          .SingleOrDefault()'
dbug: 07-12-2024 10:59:40.329 RelationalEventId.CommandCreating[20103] (Microsoft.EntityFrameworkCore.Database.Command)
      Creating DbCommand for 'ExecuteReader'.
dbug: 07-12-2024 10:59:40.329 RelationalEventId.CommandCreated[20104] (Microsoft.EntityFrameworkCore.Database.Command)
      Created DbCommand for 'ExecuteReader' (0ms).
dbug: 07-12-2024 10:59:40.366 RelationalEventId.ConnectionOpening[20000] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opening connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:40.366 RelationalEventId.ConnectionOpened[20001] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opened connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:40.380 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[@__name_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [c].[Id], [c].[City], [c].[Combined], [c].[Cylinders], [c].[Displacement], [c].[Highway], [c].[Manufacturer], [c].[Name], [c].[Year]
      FROM [Cars] AS [c]
      WHERE [c].[Name] = @__name_0
info: 07-12-2024 10:59:41.315 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (946ms) [Parameters=[@__name_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [c].[Id], [c].[City], [c].[Combined], [c].[Cylinders], [c].[Displacement], [c].[Highway], [c].[Manufacturer], [c].[Name], [c].[Year]
      FROM [Cars] AS [c]
      WHERE [c].[Name] = @__name_0
dbug: 07-12-2024 10:59:41.382 CoreEventId.StartedTracking[10806] (Microsoft.EntityFrameworkCore.ChangeTracking)
      Context 'PerondaAppDbContext' started tracking 'Car' entity. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see key values.
dbug: 07-12-2024 10:59:41.439 RelationalEventId.DataReaderDisposing[20300] (Microsoft.EntityFrameworkCore.Database.Command)
      A data reader was disposed.
dbug: 07-12-2024 10:59:41.454 RelationalEventId.ConnectionClosing[20002] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closing connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.454 RelationalEventId.ConnectionClosed[20003] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closed connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.457 CoreEventId.SaveChangesStarting[10004] (Microsoft.EntityFrameworkCore.Update)
      SaveChanges starting for 'PerondaAppDbContext'.
dbug: 07-12-2024 10:59:41.460 CoreEventId.DetectChangesStarting[10800] (Microsoft.EntityFrameworkCore.ChangeTracking)
      DetectChanges starting for 'PerondaAppDbContext'.
dbug: 07-12-2024 10:59:41.492 CoreEventId.PropertyChangeDetected[10802] (Microsoft.EntityFrameworkCore.ChangeTracking)
      The unchanged property 'Car.Name' was detected as changed and will be marked as modified. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see property values.
dbug: 07-12-2024 10:59:41.501 CoreEventId.StateChanged[10807] (Microsoft.EntityFrameworkCore.ChangeTracking)
      An entity of type 'Car' tracked by 'PerondaAppDbContext' changed state from 'Unchanged' to 'Modified'. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see key values.
dbug: 07-12-2024 10:59:41.504 CoreEventId.DetectChangesCompleted[10801] (Microsoft.EntityFrameworkCore.ChangeTracking)
      DetectChanges completed for 'PerondaAppDbContext'.
dbug: 07-12-2024 10:59:41.521 RelationalEventId.ConnectionOpening[20000] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opening connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.521 RelationalEventId.ConnectionOpened[20001] (Microsoft.EntityFrameworkCore.Database.Connection)
      Opened connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.524 RelationalEventId.TransactionStarting[20209] (Microsoft.EntityFrameworkCore.Database.Transaction)
      Beginning transaction with isolation level 'Unspecified'.
dbug: 07-12-2024 10:59:41.586 RelationalEventId.TransactionStarted[20200] (Microsoft.EntityFrameworkCore.Database.Transaction)
      Began transaction with isolation level 'ReadCommitted'.
dbug: 07-12-2024 10:59:41.679 RelationalEventId.CommandCreating[20103] (Microsoft.EntityFrameworkCore.Database.Command)
      Creating DbCommand for 'ExecuteReader'.
dbug: 07-12-2024 10:59:41.679 RelationalEventId.CommandCreated[20104] (Microsoft.EntityFrameworkCore.Database.Command)
      Created DbCommand for 'ExecuteReader' (0ms).
dbug: 07-12-2024 10:59:41.684 RelationalEventId.CommandExecuting[20100] (Microsoft.EntityFrameworkCore.Database.Command)
      Executing DbCommand [Parameters=[@p1='?' (DbType = Int32), @p0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      UPDATE [Cars] SET [Name] = @p0
      WHERE [Id] = @p1;
      SELECT @@ROWCOUNT;
info: 07-12-2024 10:59:41.897 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (214ms) [Parameters=[@p1='?' (DbType = Int32), @p0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET NOCOUNT ON;
      UPDATE [Cars] SET [Name] = @p0
      WHERE [Id] = @p1;
      SELECT @@ROWCOUNT;
dbug: 07-12-2024 10:59:41.900 RelationalEventId.DataReaderDisposing[20300] (Microsoft.EntityFrameworkCore.Database.Command)
      A data reader was disposed.
dbug: 07-12-2024 10:59:41.904 RelationalEventId.TransactionCommitting[20210] (Microsoft.EntityFrameworkCore.Database.Transaction)
      Committing transaction.
dbug: 07-12-2024 10:59:41.908 RelationalEventId.TransactionCommitted[20202] (Microsoft.EntityFrameworkCore.Database.Transaction)
      Committed transaction.
dbug: 07-12-2024 10:59:41.909 RelationalEventId.ConnectionClosing[20002] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closing connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.909 RelationalEventId.ConnectionClosed[20003] (Microsoft.EntityFrameworkCore.Database.Connection)
      Closed connection to database 'PerondaAppStorage' on server '.\sqlexpress'.
dbug: 07-12-2024 10:59:41.911 RelationalEventId.TransactionDisposed[20204] (Microsoft.EntityFrameworkCore.Database.Transaction)
      Disposing transaction.
dbug: 07-12-2024 10:59:41.915 CoreEventId.StateChanged[10807] (Microsoft.EntityFrameworkCore.ChangeTracking)
      An entity of type 'Car' tracked by 'PerondaAppDbContext' changed state from 'Modified' to 'Unchanged'. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see key values.
dbug: 07-12-2024 10:59:41.917 CoreEventId.SaveChangesCompleted[10005] (Microsoft.EntityFrameworkCore.Update)
      SaveChanges completed for 'PerondaAppDbContext' with 1 entities written to the database.

C:\PROJEKTY DAG\PerondaApp\PerondaApp\bin\Debug\net7.0\PerondaApp.exe (proces 9872) zakończono z kodem 0.
Aby automatycznie zamknąć konsolę po zatrzymaniu debugowania, włącz opcję Narzędzia -> Opcje -> Debugowanie -> Automatycznie zamknij konsolę po zatrzymaniu debugowania.
Naciśnij dowolny klawisz, aby zamknąć to okno...
 */