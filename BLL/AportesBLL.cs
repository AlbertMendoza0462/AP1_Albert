using AportesBlazor.DAL;
using AportesBlazor.Models;

namespace AportesBlazor.BLL
{
    public class AportesBLL
    {
        private Contexto _contexto { get; set; }
        public AportesBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public bool Guardar(Aportes aporte)
        {
            return (!Existe(aporte.AporteID)) ? Insertar(aporte) : Modificar(aporte);
        }

        public bool Insertar(Aportes aporte)
        {
            _contexto.aportes.Add(aporte);
            return (_contexto.SaveChanges() > 0);
        }

        public bool Modificar(Aportes aporte)
        {
            _contexto.Entry(aporte).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return (_contexto.SaveChanges() > 0);
        }

        public bool Eliminar(Aportes aporte)
        {
            _contexto.Entry(aporte).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return (_contexto.SaveChanges() > 0);
        }

        public bool Existe(int aporteID)
        {
            return _contexto.aportes.Any(aporte => aporte.AporteID == aporteID);
        }

        public Aportes? Buscar(int aporteID)
        {
            return _contexto.aportes.Find(aporteID);
        }

        public List<Aportes> GetAportes()
        {
            return _contexto.aportes.ToList();
        }

        public List<Aportes> GetAportesPorPersona(string texto, DateTime FechaDesde, DateTime FechaHasta)
        {
            return _contexto.aportes.Where(a =>
                a.Persona == texto &&
                a.Fecha.Date >= FechaDesde.Date && a.Fecha.Date <= FechaHasta.Date
            ).ToList();
        }

        public List<Aportes> GetAportesPorFecha(string texto, DateTime FechaDesde, DateTime FechaHasta)
        {
            return _contexto.aportes.Where(a => 
                a.Fecha >= FechaDesde && a.Fecha <= FechaHasta
            ).ToList();
        }

        public List<Aportes> GetAportesPorAporteID(string texto, DateTime FechaDesde, DateTime FechaHasta)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(texto);
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo parsear");
                return new List<Aportes>();
            }
            return _contexto.aportes.Where(aporte => aporte.AporteID == num && aporte.Fecha >= FechaDesde && aporte.Fecha <= FechaHasta).ToList();
        }

    }
}
