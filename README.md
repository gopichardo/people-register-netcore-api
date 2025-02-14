

1. Install Docker Desktop
2. Docker Compose
   ```
   docker-compose up -d
   ```
3. EF Initial migration
```shell
dotnet ef migrations add InitialCreate -o Migrations  // "InitialCreate" is the migration name
```

1. Apply Migrations (Create the Database):
```shell
dotnet ef database update
```