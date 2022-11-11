namespace WorkingWithDapper.Entities
{
    public class CausaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ActoCondicionId { get; set; }
        public int Tipo { get; set; }
        public ActoCondicion ActoCondicion { get; set; }
    }
}
