namespace NavieraOceanoAzul.DTO
{
    public class TiqueteDTO
    {
        public string PuertoDestino { get; set; }
        public string PuertoOrigen { get; set; }
        public int Idcliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Precio { get; set; }
        public int Idbarco { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}
