FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish fazenda_urbana.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "fazenda_urbana.dll"]
