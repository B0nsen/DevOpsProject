
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src



RUN apt-get update && apt-get install -y curl && \
    curl -sL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs



COPY ["Jysk/Jysk.Server/Jysk.Server.csproj", "Jysk/Jysk.Server/"]
COPY ["Jysk.BLL/Jysk.BLL.csproj", "Jysk.BLL/"]
COPY ["Jysk.DAL/Jysk.DAL.csproj", "Jysk.DAL/"]
COPY ["Logger/Logger.csproj", "Logger/"]


COPY ["Jysk/jysk.client/jysk.client.esproj", "Jysk/jysk.client/"]

RUN dotnet restore "Jysk/Jysk.Server/Jysk.Server.csproj"


COPY . .


WORKDIR "/src/Jysk/Jysk.Server"
RUN dotnet publish "Jysk.Server.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Jysk.Server.dll"]