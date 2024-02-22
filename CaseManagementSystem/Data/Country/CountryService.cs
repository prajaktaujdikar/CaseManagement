using CMS.DL.DM;

namespace CaseManagementSystem.Data.Companies
{
    public class CountryService
    {
        #region GET

        public List<string> GetAllCountries()
        {
            CountryDM countryDM = new CountryDM();
            return countryDM.GetAllCountries(); ;
        }

        #endregion
    }
}
