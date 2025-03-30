using MvvmWinFormsApp.Models;
using System.Collections.Generic;

namespace MvvmWinFormsApp.Services
{
    public interface IDataSourceService
    {
        IList<PersonModel> GetPersons();
    }
}
