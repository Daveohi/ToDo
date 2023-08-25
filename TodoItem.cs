namespace ToDo
{
    public class TodoItem
    {

        //Creating a model class
        public virtual int Id { get; set; }
        public virtual string? Task { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual int Priority { get; set; }

    }
}