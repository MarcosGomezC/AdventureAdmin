using AdventureAdmin.Ui.Services;
using AdventureAdmin.Ui.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ScrapReasonEntity = AdventureAdmin.Data.Models.ScrapReason;

namespace AdventureAdmin.Ui.Tests.Services;

public class ScrapReasonServiceTests
{
    [Fact]
    public async Task Buscar_CuandoExisteMotivo_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 1, name: "Defecto de soldadura"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.ScrapReasonId);
        Assert.Equal("Defecto de soldadura", result.Name);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteMotivo_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ScrapReasonService(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorId_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.AddRange(
                CreateScrapReason(id: 1, name: "Material incorrecto"),
                CreateScrapReason(id: 2, name: "Herramienta desgastada"),
                CreateScrapReason(id: 3, name: "Ajuste fuera de tolerancia"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);

        var result = await service.GetList(s => s.ScrapReasonId != 2);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.ScrapReasonId == 1);
        Assert.Contains(result, s => s.ScrapReasonId == 3);
        Assert.DoesNotContain(result, s => s.ScrapReasonId == 2);
    }

    [Fact]
    public async Task Insertar_CuandoMotivoEsValido_GeneraFechaYAlmacena()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ScrapReasonService(context);
        var scrapReason = CreateScrapReason(id: 10, name: "Falla de montaje");
        var beforeInsert = DateTime.Now;

        var wasInserted = await service.Insertar(scrapReason);

        Assert.True(wasInserted);
        Assert.True(scrapReason.ModifiedDate >= beforeInsert);

        var savedEntity = await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("Falla de montaje", savedEntity!.Name);
    }

    [Fact]
    public async Task Existe_CuandoExisteMotivo_RetornaTrue()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 5, name: "Pieza rechazada en inspeccion"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);

        var exists = await service.Existe(5);

        Assert.True(exists);
    }

    [Fact]
    public async Task Existe_CuandoNoExisteMotivo_RetornaFalse()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ScrapReasonService(context);

        var exists = await service.Existe(77);

        Assert.False(exists);
    }

    [Fact]
    public async Task Modificar_CuandoMotivoExiste_ActualizaDatosYFecha()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 20, name: "Descripcion original"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);
        var updated = CreateScrapReason(id: 20, name: "Descripcion actualizada");
        var beforeUpdate = DateTime.Now;

        var wasUpdated = await service.Modificar(updated);

        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 20);
        Assert.NotNull(saved);
        Assert.Equal("Descripcion actualizada", saved!.Name);
    }

    [Fact]
    public async Task Actualizar_CuandoMotivoExiste_ActualizaDatosYFecha()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 21, name: "Motivo sin editar"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);
        var updated = CreateScrapReason(id: 21, name: "Motivo editado por Actualizar");
        var beforeUpdate = DateTime.Now;

        var wasUpdated = await service.Actualizar(updated);

        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 21);
        Assert.NotNull(saved);
        Assert.Equal("Motivo editado por Actualizar", saved!.Name);
    }

    [Fact]
    public async Task Guardar_CuandoMotivoNoExiste_InsertaYRetornaTrue()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ScrapReasonService(context);
        var nuevo = CreateScrapReason(id: 30, name: "Nuevo motivo de scrap");

        var result = await service.Guardar(nuevo);

        Assert.True(result);

        var saved = await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 30);
        Assert.NotNull(saved);
        Assert.Equal("Nuevo motivo de scrap", saved!.Name);
    }

    [Fact]
    public async Task Guardar_CuandoMotivoExiste_ModificaYRetornaTrue()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 40, name: "Motivo existente"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);
        var updated = CreateScrapReason(id: 40, name: "Motivo existente renombrado");

        var result = await service.Guardar(updated);

        Assert.True(result);

        var saved = await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 40);
        Assert.NotNull(saved);
        Assert.Equal("Motivo existente renombrado", saved!.Name);
    }

    [Fact]
    public async Task Eliminar_CuandoNoExisteMotivo_RetornaFalse()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ScrapReasonService(context);

        var result = await service.Eliminar(1);

        Assert.False(result);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteMotivo_EliminaYRetornaTrue()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ScrapReasons.Add(CreateScrapReason(id: 7, name: "Para eliminar"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ScrapReasonService(context);

        var result = await service.Eliminar(7);

        Assert.True(result);
        Assert.Null(await context.ScrapReasons.FirstOrDefaultAsync(s => s.ScrapReasonId == 7));
    }

    private static ScrapReasonEntity CreateScrapReason(short id, string name, DateTime? modifiedDate = null)
    {
        return new ScrapReasonEntity
        {
            ScrapReasonId = id,
            Name = name,
            ModifiedDate = modifiedDate ?? DateTime.Now
        };
    }
}
