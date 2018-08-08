FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/seatarranger.com.Console/seatarranger.com.Console.csproj src/seatarranger.com.Console/
COPY src/seatarranger.com.Core/seatarranger.com.Core.csproj src/seatarranger.com.Core/
RUN dotnet restore src/seatarranger.com.Console/seatarranger.com.Console.csproj
COPY . .
WORKDIR /src/src/seatarranger.com.Console
RUN dotnet build seatarranger.com.Console.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish seatarranger.com.Console.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "seatarranger.com.Console.dll"]
