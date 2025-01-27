

namespace PRUEBANET.Models
{
    public class TransaccionBase
    {
        public int Id { get; set; }  // Clave primaria con incremento automático
        public string Fecha { get; set; }  // Fecha en formato string
        public string Descripcion { get; set; }  // Descripción de la transacción
        public decimal Monto { get; set; }  // Monto de la transacción
    }

     public class RegistrosContablesAORRALA : TransaccionBase
    {
    }

    public class MovimientosBancariosAORRALA : TransaccionBase
    {
    }

    public class EntradaConcileacion{
        public List<RegistrosContablesAORRALA> listaregistros { get; set; }
        public List<MovimientosBancariosAORRALA> listamovimientos { get; set; }
    }

    public class DiscrepanciasAORRALA : TransaccionBase
    {
        public string Tipo { get; set; }  // Tipo de discrepancia
        public bool Resuelta { get; set; }  // Indica si la discrepancia ha sido resuelta
    }


}