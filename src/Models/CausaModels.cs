namespace WorkingWithDapper.Models
{
    public class GetCausaOpcionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class GetCausaResponseModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ActoCondicion { get; set; }
    }

    public class PostCausaRequestModel
    {
        public string Nombre { get; set; }
        public int ActoCondicionId { get; set; }
        public int Tipo { get; set; }
    }

    public class PutCausaRequestModel
    {
        public string Nombre { get; set; }
        public int ActoCondicionId { get; set; }
        public int Tipo { get; set; }
    }
}
