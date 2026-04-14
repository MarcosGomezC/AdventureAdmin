using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class ScrapReasonService(AdventureWorksContext context) : Aplicada1.Core.IService<Data.Models.ScrapReason, int>
    {
        public async Task<Data.Models.ScrapReason?> Buscar(int id)
        {
            return await context.ScrapReasons
                .FirstOrDefaultAsync(s => s.ScrapReasonId == (short)id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var entidad = await context.ScrapReasons
                .FirstOrDefaultAsync(s => s.ScrapReasonId == (short)id);

            if (entidad == null)
                return false;

            context.ScrapReasons.Remove(entidad);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Data.Models.ScrapReason>> GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
        {
            return await context.ScrapReasons
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(Data.Models.ScrapReason scrapReason)
        {
            if (!await Existe((int)scrapReason.ScrapReasonId))
                return await Insertar(scrapReason);
            else
                return await Modificar(scrapReason);
        }

        public async Task<bool> Insertar(Data.Models.ScrapReason scrapReason)
        {
            scrapReason.ModifiedDate = DateTime.Now;
            await context.ScrapReasons.AddAsync(scrapReason);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int id)
        {
            return await context.ScrapReasons.AnyAsync(s => s.ScrapReasonId == (short)id);
        }

        public async Task<bool> Modificar(Data.Models.ScrapReason scrapReason)
        {
            scrapReason.ModifiedDate = DateTime.Now;
            context.ScrapReasons.Update(scrapReason);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Actualizar(Data.Models.ScrapReason scrapReason)
        {
            scrapReason.ModifiedDate = DateTime.Now;
            context.Entry(scrapReason).State = EntityState.Modified;
            return await context.SaveChangesAsync() > 0;
        }
    }
}
