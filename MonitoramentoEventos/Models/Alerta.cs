namespace MonitoramentoEventos.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
