FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
COPY . .

# FROM mcr.microsoft.com/mssql/server:2017-latest

CMD ["dotnet", "HWMS.Web.dll"]