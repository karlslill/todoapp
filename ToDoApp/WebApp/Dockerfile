FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln . 
COPY ToDoApp/WebApp/*.csproj ./WebApp/
RUN dotnet restore

COPY ToDoApp/. ./ToDoApp/
WORKDIR /app/ToDoApp/WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/ToDoApp/WebApp/out ./

EXPOSE 5138

ENTRYPOINT ["dotnet", "WebApp.dll"]
