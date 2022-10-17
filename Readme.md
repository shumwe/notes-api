# NOTES API
## Track your notes with a dotnet api, persisted to the database using EntityFrameworkCore {Sqlite}
<br/>

# RUNNING 
```
1) Clone the project # git clone https://github.com/shumwe/notes-api.git

2) Run the app migrations # dotnet ef migrationsa add InitialMigrations -o Data/Migrations

3) Create the database # dotnet ef databbase update

4) Run the app # dotnet watch run
'you should be redirected to your default browser or navigate to /swagger/index.html'

```

# Actions
```

[HttpGet] /api/Notes/all?count={count:int}
[HttpGet] /api/Notes/{id}
[HttpPost] /api/Notes/new
[HttpPut] /api/Notes/update/{id}
[HttpDelete] /api/Notes/delete/{id}

```