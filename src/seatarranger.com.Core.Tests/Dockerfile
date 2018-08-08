FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/seatarranger.com.Core.Tests/seatarranger.com.Core.Tests.csproj src/seatarranger.com.Core.Tests/
COPY src/seatarranger.com.Core/seatarranger.com.Core.csproj src/seatarranger.com.Core/
RUN dotnet restore src/seatarranger.com.Core.Tests/seatarranger.com.Core.Tests.csproj
COPY . .
WORKDIR /src/src/seatarranger.com.Core.Tests
RUN dotnet build seatarranger.com.Core.Tests.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish seatarranger.com.Core.Tests.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "seatarranger.com.Core.Tests.dll"]
