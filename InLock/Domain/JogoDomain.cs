namespace InLock.Domain
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string Nome { get; set; }
        public string Descriao { get; set; }
        public string DataLancamento { get; set; }
        public float Valor { get; set; }
    }
}
