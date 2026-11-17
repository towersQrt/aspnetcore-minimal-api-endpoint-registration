# aspnetcore-minimal-api-endpoint-registration

Ejemplo mínimo de registro dinámico de endpoints en Minimal API (.NET 10).

## Cómo funciona

Cada endpoint es una clase que implementa `IEndpoint`. `AddEndpoints` los descubre por reflexión en el assembly y los registra en DI, y `MapEndpoints` llama a `MapEndpoint` en cada uno:

```csharp
builder.Services.AddEndpoints(typeof(IEndpoint).Assembly);
app.MapEndpoints();
```

Para agregar un endpoint basta crear una clase nueva en `src/Regnier.Web/Endpoints` (ver `Hello.cs`); no hay que tocar `Program.cs`.

## Ejecutar

```bash
dotnet run --project src/Regnier.Web
curl http://localhost:5278/
```
