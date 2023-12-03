FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Feedback.Web/Feedback.Web.csproj", "src/Feedback.Web/"]
RUN dotnet restore "src/Feedback.Web/Feedback.Web.csproj"
COPY . .
WORKDIR "/src/src/Feedback.Web"
RUN dotnet build "Feedback.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Feedback.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Feedback.Web.dll"]
