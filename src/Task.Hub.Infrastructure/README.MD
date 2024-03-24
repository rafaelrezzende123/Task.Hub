How to run migrations?

Open Package Manager Console 
Set project Task.Hub.Infrastructure
Execute commands: 
1 - Add-Migration InitialMigration -c CommandDbContext
2 - Update-Database -Context CommandDbContext