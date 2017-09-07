# Toggl to Harvest

Framework used : Dotnet Core 2.0

Migrates the last 10 days of time entries from Toggl to Harvest.

Example
````
docker run -rm \
-e TOGGL_API_KEY=... \
-e HARVEST_PASSWORD=... \
-e HARVEST_EMAIL=... \
-e HARVEST_DOMAIN=... \
-e TOGGL_PROJECT_NAME=... \
raphaelareya/toggle-to-harvest

````