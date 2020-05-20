namespace GTL_Project.Models
{
    public interface IBook
    {
        string Author { get; set; }
        string Cover_Type { get; set; }
        string Description { get; set; }
        string Edition { get; set; }
        bool In_Stock { get; set; }
        int Isbn { get; set; }
        bool Lendable { get; set; }
        string Title { get; set; }
    }
}