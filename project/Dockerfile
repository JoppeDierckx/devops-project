# Stage 1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /build
COPY ./project ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app
# Stage 2
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Core3Api.dll"]