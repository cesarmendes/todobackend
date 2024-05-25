#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TodoList.Api/TodoList.Api.csproj", "TodoList.Api/"]
RUN dotnet restore "./TodoList.Api/TodoList.Api.csproj"
COPY . .
WORKDIR "/src/TodoList.Api"
RUN dotnet build "./TodoList.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#RUN dotnet tool install --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
#RUN dotnet-ef database update --configuration appsettings.Production.json

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TodoList.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoList.Api.dll"]