## Phone-Book

### Database

To develop locally, all you really need is a Postgres database as you can use the Authentication and application IDs from the production environment.

In this directory run the following to setup a database on your machine (provided you have docker installed). The username and password can be found in the docker-compose.yml file.

'docker-compose -f docker-compose.yml up --build'

The connection strings can be found in the appsettings.json.


### Frontend

Angular application is under Client folder.
