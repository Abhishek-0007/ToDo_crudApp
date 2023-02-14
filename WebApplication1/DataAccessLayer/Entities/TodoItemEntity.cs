namespace WebApplication1.DataAccessLayer.Entities
{
    public class TodoItemEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool isComplete { get; set; }

    }
}
