# Weather App Project
Este proyecto consta de una API en .NET para obtener información del clima y una aplicación web en Angular para mostrarla.

## Requisitos previos
- .NET SDK
- Node.js y npm
- Angular CLI
- Microsoft SQL Server

## Configuración
- Clona el repositorio:
```
git clone https://github.com/Gonza1694/challenge.git
```
- Instalar dependencias:
### API
```
cd /WeatherAPI
```
```
dotnet restore
```
```
dotnet build
```
### Base de datos
- Navegar hasta la ruta `/WeatherAPI/Utils/ConnectionString.cs` y modificar los siguientes campos:
```
Server = @"SERVER NAME"
DB = @"DB NAME"
User = @"USER"
Password = @"PASS"
```
- Luego en la terminal ejecutar el siguiente comando
```
dotnet ef database update
```
### APP
```
cd /WeatherApp/ClientApp
```
```
npm install
```

## Ejecutar Aplicación
### Levantar API
```
cd /WeatherAPI
```
```
dotnet run
```
[http://localhost:5227/swagger/index.html](http://localhost:5227/swagger/index.html)

### Levantar APP
```
cd /WeatherApp/
```
```
dotnet run
```
[https://localhost:44455](https://localhost:44455/)
