# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /dotNetEndpoint

RUN apt-get install -y git

ARG REVDEBUG_RECORD_SERVER_ADDRESS
ENV REVDEBUG_RECORD_SERVER_ADDRESS=$REVDEBUG_RECORD_SERVER_ADDRESS

ARG REVDEBUG_DOTNET_COMPILER_VERSION
ENV REVDEBUG_DOTNET_COMPILER_VERSION=$REVDEBUG_DOTNET_COMPILER_VERSION

ARG REVDEBUG_DOTNET_AGENT_VERSION
ENV REVDEBUG_DOTNET_AGENT_VERSION=$REVDEBUG_DOTNET_AGENT_VERSION

COPY . ./
RUN dotnet nuget add source https://nexus.revdebug.com/repository/nuget --name rdb_nexus
RUN dotnet nuget add source https://nexus-test.revdebug.com/repository/nuget --name rdb_nexus_test
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /dotNetEndpoint
COPY --from=build-env /dotNetEndpoint/out .
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=RevDeBugAPM.Agent.AspNetCore
ENTRYPOINT ["dotnet", "dotNetEndpoint.dll"]
