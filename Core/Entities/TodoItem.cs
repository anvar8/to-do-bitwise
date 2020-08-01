using System;

namespace Core.Entities
{
    public class TodoItem: BaseEntity
    {
        public string Title { get; set; }
        
        public string Details {get; set;}
        public DateTime DateCreated {get; set;} = new DateTime(); 
        public DateTime? DateUpdated {get; set;}
        public bool IsCompleted {get; set;} = false;
        public int Priority {get; set;} 

    }
}