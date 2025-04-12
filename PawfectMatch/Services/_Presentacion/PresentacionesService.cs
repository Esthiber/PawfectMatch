using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PawfectMatch.Data;
using PawfectMatch.Models._Presentacion;
using System.Linq.Expressions;

namespace PawfectMatch.Services._Presentacion
{
    public class PresentacionesService(IDbContextFactory<ApplicationDbContext> DbFactory)
    {
        public async Task<bool> DeleteAsync(int id)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();
            var presentacion = await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                .FirstOrDefaultAsync(p => p.PresentacionId == id);

            if (presentacion == null)
                return false;

            // Eliminar relaciones primero
            ctx.PresentacionesDiapositivas.RemoveRange(presentacion.PresentacionesDiapositivas);

            // Luego eliminar la presentación
            ctx.Presentaciones.Remove(presentacion);

            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistAsync(int id)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();
            return await ctx.Presentaciones.AnyAsync(p => p.PresentacionId == id);
        }

        public async Task<bool> InsertAsync(Presentaciones elem, List<Diapositivas> diapositivas)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();
            ctx.Presentaciones.Add(elem);

            foreach (var d in diapositivas) // Agregar Diapositivas
            {
                ctx.Diapositivas.Add(d);
                await ctx.SaveChangesAsync();
            }

            foreach (var d in diapositivas) // En base a las diapositivas agregar a la tabla relacional
            {
                var r = new PresentacionesDiapositivas();
                r.PresentacionId = elem.PresentacionId;
                r.DiapositivaId = d.DiapositivaId;
                ctx.PresentacionesDiapositivas.Add(r);
            }
            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<List<Presentaciones>> ListAsync(Expression<Func<Presentaciones, bool>> criteria)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();

            return await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                    .ThenInclude(pd => pd.Diapositiva)
                .Where(criteria)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync(Presentaciones presentacion, List<Diapositivas> diapositivas)
        {
            if (presentacion.PresentacionId == 0)
            {
                return await InsertAsync(presentacion, diapositivas);
            }
            else
            {
                return await UpdateAsync(presentacion, diapositivas);
            }
        }

        public async Task<Presentaciones> SearchByIdAsync(int id)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();

            return await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                    .ThenInclude(pd => pd.Diapositiva)
                .FirstOrDefaultAsync(p => p.PresentacionId == id)
                ?? throw new KeyNotFoundException($"Presentación con ID {id} no encontrada.");
        }

        public async Task<bool> UpdateAsync(Presentaciones elem, List<Diapositivas> nuevasDiapositivas)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();

            var existing = await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                .ThenInclude(pd => pd.Diapositiva)
                .FirstOrDefaultAsync(p => p.PresentacionId == elem.PresentacionId);

            if (existing == null)
                return false;

            // Actualizar campos básicos
            existing.Titulo = elem.Titulo;
            existing.FechaCreacion = elem.FechaCreacion;
            existing.EsActiva = elem.EsActiva;

            // Eliminar relaciones y diapositivas antiguas
            foreach (var rel in existing.PresentacionesDiapositivas)
            {
                ctx.Diapositivas.Remove(rel.Diapositiva); // si deseas conservarlas, quita esta línea
            }
            ctx.PresentacionesDiapositivas.RemoveRange(existing.PresentacionesDiapositivas);

            await ctx.SaveChangesAsync();

            // Insertar nuevas diapositivas y relaciones
            foreach (var nueva in nuevasDiapositivas)
            {
                ctx.Diapositivas.Add(nueva);
                await ctx.SaveChangesAsync(); // Para que tenga DiapositivaId

                var relacion = new PresentacionesDiapositivas
                {
                    PresentacionId = existing.PresentacionId,
                    DiapositivaId = nueva.DiapositivaId
                };
                ctx.PresentacionesDiapositivas.Add(relacion);
            }

            return await ctx.SaveChangesAsync() > 0;
        }

        public async Task<Presentaciones> GetActiveAsync()
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();
            return await ctx.Presentaciones
                 .Include(p => p.PresentacionesDiapositivas)
                     .ThenInclude(pd => pd.Diapositiva)
                 .FirstOrDefaultAsync(p => p.EsActiva) ?? throw new KeyNotFoundException($"Presentación con Activa no encontrada.");
        }

        public async Task<bool> SetActive(int id)
        {
            await using var ctx = await DbFactory.CreateDbContextAsync();

            List<Presentaciones> lista = await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                    .ThenInclude(pd => pd.Diapositiva)
                .Where(p => p.EsActiva == true)
                .ToListAsync();


            foreach (var p in lista)
            {
                p.EsActiva = false;
                ctx.Presentaciones.Update(p);
            }

            var elem = await ctx.Presentaciones
                .Include(p => p.PresentacionesDiapositivas)
                    .ThenInclude(pd => pd.Diapositiva)
                .FirstOrDefaultAsync(p => p.PresentacionId == id)
                ?? throw new KeyNotFoundException($"Presentación con ID {id} no encontrada.");

            elem.EsActiva = true;
            ctx.Presentaciones.Update(elem);
            return await ctx.SaveChangesAsync() > 0;
        }

    }
}
