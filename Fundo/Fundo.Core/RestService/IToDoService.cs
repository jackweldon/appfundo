using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundo.Core.Model;

namespace Fundo.Core.RestService
{
    interface IToDoService
    {
        void PostLike();
        void PostDislike();

        List<ToDoItem> GetUserLikes();
        List<ToDoItem> SearchToDoItems();

    }
}
