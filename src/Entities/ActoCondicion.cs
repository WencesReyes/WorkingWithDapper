namespace WorkingWithDapper.Entities
{
    public class ActoCondicion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public ICollection<CausaEntity> Causas { get; set; }
    }
}
