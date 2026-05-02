FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["Jysk/Jysk.Server/Jysk.Server.csproj", "Jysk/Jysk.Server/"]
COPY ["Jysk.BLL/Jysk.BLL.csproj", "Jysk.BLL/"]
COPY ["Jysk.DAL/Jysk.DAL.csproj", "Jysk.DAL/"]
COPY ["Logger/Logger.csproj", "Logger/"]

RUN dotnet restore "Jysk/Jysk.Server/Jysk.Server.csproj"


COPY . .
WORKDIR "/src/Jysk/Jysk.Server"
RUN dotnet publish "Jysk.Server.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Jysk.Server.dll"]