# Weather App Project
Este proyecto consta de una API en .NET para obtener información del clima y una aplicación web en Angular para mostrarla.

## Requisitos previos
- .NET SDK (para ejecutar la API)
- Node.js y npm (para ejecutar la aplicación web)
- Angular CLI (instalado de forma global)

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
