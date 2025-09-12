## Urban Etiquette API Docs

# Database
The database is postgres

# Database management
The database management tool is DBeaver

# New Migration
To run a new ef core migration, run the following command, replacing InitialCreate with unique migration name
`dotnet ef migrations add AddCoreEntities --project UrbanEtiquette.Infrastructure --startup-project UrbanEtiquette.WebApi`

# Apply Migration to Database
`dotnet ef database update --project UrbanEtiquette.Infrastructure --startup-project UrbanEtiquette.WebApi`