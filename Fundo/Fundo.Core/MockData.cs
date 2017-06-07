using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundo.Core.Model;

namespace Fundo.Core
{
    public static class MockData
    {
        public static List<ToDoItem> GetItems()
        {
            var list = new List<ToDoItem>
            {
                new ToDoItem
                {
                    Name = "The first one",
                                        Rating= 1.67f,

                    Image = "https://i.ytimg.com/vi/c6KuZyOc8os/hqdefault.jpg",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin metus orci, dictum quis pulvinar vitae," +
                        " bibendum tincidunt dui. Fusce lobortis enim eget purus imperdiet, et cursus erat ornare. Vivamus mauris leo, " +
                        "egestas eu efficitur eu, ullamcorper vitae diam. Phasellus vulputate bibendum dolor et fringilla. "
                },
                new ToDoItem
                {
                    Name = "The next one",
                                        Rating= 4.67f,

                    Image = "http://www.feistees.com/wp-content/uploads/2014/05/squpd.jpg",
                    Description =
                        "Curabitur tempor arcu neque, sit amet vestibulum felis posuere sed. Vivamus finibus rhoncus viverra. Curabitur cursus molestie augue."
                },
                new ToDoItem
                {
                    Name = "The other one",
                    Rating= 2.67f,
                    Image =
                        "https://image.freepik.com/vetores-gratis/resumo-de-fundo-com-um-desenho-geometrico_1048-1511.jpg",
                    Description =
                        "Proin laoreet elit lacus, quis porttitor est pharetra non. Mauris lacus mauris, consequat non ultricies vitae, varius eget sem. Curabitur quis posuere tellus."
                }
            };




            return list;
        }
    }
}
