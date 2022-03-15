#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Net5/HelpMeDeskNet5/HelpMeDeskNet5.csproj", "Net5/HelpMeDeskNet5/"]
COPY ["Net5/DomainNet5/DomainNet5.csproj", "Net5/DomainNet5/"]
COPY ["Net5/DataNet5/DataNet5.csproj", "Net5/DataNet5/"]
RUN dotnet restore "Net5/HelpMeDeskNet5/HelpMeDeskNet5.csproj"
COPY . .
WORKDIR "/src/Net5/HelpMeDeskNet5"
RUN dotnet build "HelpMeDeskNet5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelpMeDeskNet5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelpMeDeskNet5.dll"]