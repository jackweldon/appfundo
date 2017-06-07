using System.Collections.Generic;

namespace Fundo.Core.Model
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }

    public enum Category
    {
        Creative =0,
        Active = 1,
        Indoor =2
           
    }

    public enum Group
    {
        Family= 0,
        Couple = 1,
        Individual = 2,
        Friends = 3
    }

    public enum AccountType
    {
        Google = 0,
        Facebook = 1
    }
    public class AppUser
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public AccountInfo accounts { get; set; }
        public Likes likes { get; set; }
        public Dislikes dislikes { get; set; }
    }

    public class AccountInfo
    {
        public AccountType type { get; set; }
        public string uid { get; set; }
    }

    public class Dislikes
    {
        public List<ToDoItem> somethingid { get; set; }
    }

    public class Likes
    {
        public List<ToDoItem> somethingid { get; set; }
    }

    public abstract class SearchModel
    {
        
    }

    public class FundoSearchModel : SearchModel
    {
        
    }
}
