FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/seatarranger.com/seatarranger.com.csproj src/seatarranger.com/
COPY src/seatarranger.com.Core/seatarranger.com.Core.csproj src/seatarranger.com.Core/
RUN dotnet restore src/seatarranger.com/seatarranger.com.csproj
COPY . .
WORKDIR /src/src/seatarranger.com
RUN dotnet build seatarranger.com.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish seatarranger.com.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "seatarranger.com.dll"]
