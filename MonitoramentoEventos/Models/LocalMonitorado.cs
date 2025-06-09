using System.Collections.Generic;

namespace MonitoramentoEventos.Models
{
    public class LocalMonitorado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Alerta> Alertas { get; set; }
    }
}