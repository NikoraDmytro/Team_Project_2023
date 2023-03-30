FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .
COPY ./Api/Api.csproj ./Api/
COPY ./BLL/BLL.csproj ./BLL/
COPY ./DAL/DAL.csproj ./DAL/
COPY ./Core/Core.csproj ./Core/

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Api.dll"]