FROM mcr.microsoft.com/dotnet/sdk:8.0 as base
EXPOSE 80
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIROPMENT Development
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src

COPY ["BackendApi/BackendApi-Test.csproj", "BackendApi/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "BackendApi/BackendApi-Test.csproj"

RUN dotnet restore "BackendApi/BackendApi-Test.csproj"
COPY . .
FROM build AS publish
RUN dotnet publish "BackendApi/BackendApi-Test.csproj" -c Release -o /app/publish/p:UseAppHost=false
FROM base AS final

WORKDIR /app
COPY -from-publish/app/publish.

ENTRYPOINT ["dotnet", "BackendApi-Test.dll"]