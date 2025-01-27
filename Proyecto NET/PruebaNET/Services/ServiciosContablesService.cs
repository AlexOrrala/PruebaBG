using PRUEBANET.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaNET.Services
{
    public class ServiciosContablesService
    {
        private readonly ApplicationDbContext _context;

        public ServiciosContablesService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> MarcarDiscrepanciasComoResueltas(List<int> discrepanciasIds)
        {
            var discrepancias = await _context.discrepancias_aorrala
                                               .Where(d => discrepanciasIds.Contains(d.Id))
                                               .ToListAsync();

            if (discrepancias.Count == 0){
                return false;
            }

            foreach (var discrepancia in discrepancias)
            {
                discrepancia.Resuelta = true;
            }

            await _context.SaveChangesAsync();
            return true;
        }

            public async Task<List<DiscrepanciasAORRALA>> Concileacion(EntradaConcileacion body){
        var discrepancias = new List<DiscrepanciasAORRALA>();

        // Guardar los registros contables
        foreach (var registro in body.listaregistros)
        {
            var movimiento = body.listamovimientos.FirstOrDefault(m =>
                m.Descripcion == registro.Descripcion && m.Monto == registro.Monto && m.Fecha == registro.Fecha);

            if (movimiento == null)
            {
                discrepancias.Add(new DiscrepanciasAORRALA
                {
                    Fecha = registro.Fecha,
                    Descripcion = registro.Descripcion,
                    Monto = registro.Monto,
                    Tipo = "Registro contable sin coincidencia"
                });

                var registroExistente = await _context.registroscontables_aorrala
                    .FirstOrDefaultAsync(r => r.Fecha == registro.Fecha && r.Descripcion == registro.Descripcion && r.Monto == registro.Monto);

                if (registroExistente == null)
                {
                    _context.registroscontables_aorrala.Add(registro);  // Agregar nuevo registro contable
                }
            }
        }

        foreach (var movimiento in body.listamovimientos)
        {
            var registro = body.listaregistros.FirstOrDefault(r =>
                r.Descripcion == movimiento.Descripcion && r.Monto == movimiento.Monto && r.Fecha == movimiento.Fecha);

            if (registro == null)
            {
                discrepancias.Add(new DiscrepanciasAORRALA
                {
                    Fecha = movimiento.Fecha,
                    Descripcion = movimiento.Descripcion,
                    Monto = movimiento.Monto,
                    Tipo = "Movimiento bancario sin coincidencia"
                });

                var movimientoExistente = await _context.movimientosbancarios_aorrala
                    .FirstOrDefaultAsync(m => m.Fecha == movimiento.Fecha && m.Descripcion == movimiento.Descripcion && m.Monto == movimiento.Monto);

                if (movimientoExistente == null)
                {
                    _context.movimientosbancarios_aorrala.Add(movimiento);  
                }
            }
        }

        if (discrepancias.Any())
        {
            await _context.discrepancias_aorrala.AddRangeAsync(discrepancias);
            await _context.SaveChangesAsync();  
        }

        return discrepancias;  
    }


        public async Task<List<RegistrosContablesAORRALA>> TodosRegistrosContables()
        {
            var result = await _context.registroscontables_aorrala.ToListAsync();
            return result;
        }

        public async Task<List<MovimientosBancariosAORRALA>> TodosmovimientosContables()
        {
            var result = await _context.movimientosbancarios_aorrala.ToListAsync();
            return result;
        }

    }
}
