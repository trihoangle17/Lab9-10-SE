# Lab 9 and 10 Software Testing and Deployment

Small ASP.NET Core MVC project covering unit tests, CSV-driven tests, Selenium automation, Docker and GitHub Actions.

## Run locally

```powershell
dotnet restore Lab9_10.sln
dotnet test LabCore.Tests/LabCore.Tests.csproj
dotnet run --project LabWebApp/LabWebApp.csproj
```

Open `http://localhost:5000` (or the URL printed by ASP.NET Core). Login with `student` / `123456`.

## Run with Docker

```powershell
docker build -t lab9-10-web .
docker run -d -p 8080:8080 --name lab9-10-web lab9-10-web
docker ps
```

Open `http://localhost:8080`.

## Selenium

Start the web app on port 8080, ensure Chrome is installed, then run:

```powershell
dotnet test LabWebApp.SeleniumTests/LabWebApp.SeleniumTests.csproj
```

## Docker Hub commands

```powershell
docker login
docker tag lab9-10-web trihoangle17/lab9-10-web:latest
docker push trihoangle17/lab9-10-web:latest
```

Repository: https://github.com/trihoangle17/Lab9-10-SE.git

The included GitHub Actions workflow restores, tests and builds the Docker image on every push or pull request to `main`.
