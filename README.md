

1. Install Docker Desktop
2. Run Docker Compose command
   ```
   docker-compose up -d
   ```
3. EF Initial migration
   ```shell
   dotnet ef migrations add InitialDB -p People.Infrastructure/ -s People.Api/
   ```

4. Apply Migrations (Create the Database):
   ```shell
   dotnet ef database update
   ```
5. Run Web Api
   ```shell
   dotnet watch run -p People.Api/
   ```