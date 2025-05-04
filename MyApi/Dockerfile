# Use base image for ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyApi.csproj", "MyApi/"]
RUN dotnet restore "MyApi/MyApi.csproj"
COPY . MyApi/
WORKDIR "/src/MyApi"
RUN dotnet publish -c Release -o /app

# Use final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MyApi.dll"]
