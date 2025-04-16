# Code

## SQLite Migration

```shell
# SQLite
ASPNETCORE_ENVIRONMENT=Development \
dotnet ef migrations add InitialSqlite \
--context AppDbContext \
--output-dir Migrations.Sqlite
```

## PotgreSQL Migration

```shell
# PostgreSQL
ASPNETCORE_ENVIRONMENT=Production \
dotnet ef migrations add InitialPostgres \
--context AppDbContext \
--output-dir Migrations.Postgres
```
