using MvvmWinFormsApp.Models;
using System.Collections.Generic;

namespace MvvmWinFormsApp.Services
{
    public class DataSourceService: IDataSourceService
    {
        public IList<PersonModel> GetPersons()
        {
            return new List<PersonModel>
            {
                new PersonModel{Id = 1, Name = "Антон", Age = 38},
                new PersonModel{Id = 2, Name = "Иван", Age = 25},
                new PersonModel{Id = 3, Name = "Пётр", Age =19}
            };
        }
    }
}
