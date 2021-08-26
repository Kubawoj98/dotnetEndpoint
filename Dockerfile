# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /dotNetEndpoint

RUN apt-get install -y git

ARG REVDEBUG_RECORD_SERVER_ADDRESS
ENV REVDEBUG_RECORD_SERVER_ADDRESS=$REVDEBUG_RECORD_SERVER_ADDRESS

COPY . ./
RUN dotnet nuget add source https://nexus.revdebug.com/repository/nuget --name rdb_nexus
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /dotNetEndpoint
COPY --from=build-env /dotNetEndpoint/out .
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=RevDeBugAPM.Agent.AspNetCore
ENTRYPOINT ["dotnet", "dotNetEndpoint.dll"]
