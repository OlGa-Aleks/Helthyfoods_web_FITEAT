# Этап сборки: используем SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Копируем файл проекта и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем оставшиеся исходники и публикуем приложение в режиме Release
COPY . . 
RUN dotnet publish -c Release -o out

# Этап выполнения: используем образ ASP.NET Core для запуска приложения
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

# Копируем опубликованное приложение из этапа сборки
COPY --from=build /app/out .

# Render предоставляет порт через переменную среды PORT, поэтому настраиваем ASP.NET Core на прослушивание всех адресов
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

EXPOSE 80
ENTRYPOINT ["dotnet", "Helthy_Shop.dll"]
