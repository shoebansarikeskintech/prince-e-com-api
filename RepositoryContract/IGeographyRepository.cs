using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
    public interface IGeographyRepository
    {
        public Task<ResponseViewModel> getAllCountryMethod();
        public Task<ResponseViewModel> getAllStateMethod(int Fk_CountryId);

        public Task<ResponseViewModel> getAllCityMethod(int Fk_StateId);
    }
}
