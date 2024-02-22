using CaseManagementSystem.Data.CaseTypes;
using CaseManagementSystem.Data.TraceLevels;
using CaseManagementSystem.Data.Users;
using CaseManagementSystem.Pages;
using CMS.DL.DM;
using CMS.DL.Model;

namespace CaseManagementSystem.Data.Subjects
{
    public class SubjectService
    {
        private readonly string _connectionString = "";

        public SubjectService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        #region GET

        public async Task<IEnumerable<SubjectViewModel>> GetAllSubjectsAsync()
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Subjects> subjects = await subjectDM.GetAllSubjectsAsync();

            return subjects.Select(c => new SubjectViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Alias = c.Alias,
                AssociatedCompany = c.AssociatedCompany,
                Notes = c.Notes,
                Email = c.Email,
                TelephoneNumber = c.TelephoneNumber,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                City = c.City,
                County = c.County,
                Postcode = c.Postcode,
                Country = c.Country,
                TitlePrefixId = c.TitlePrefixId,
                TitlePrfixName = c.TitlePrfixName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName,
                CaseNumber = c.CaseNumber,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                CompanyName = c.CompanyName,
                UserId = c.UserId
            });
        }

        public async Task<IEnumerable<SubjectViewModel>> GetSubjectsByClientAsync(Guid? id)
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Subjects> subjects = await subjectDM.GetSubjectsByClientAsync(id);

            return subjects.Select(c => new SubjectViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Alias = c.Alias,
                AssociatedCompany = c.AssociatedCompany,
                Notes = c.Notes,
                Email = c.Email,
                TelephoneNumber = c.TelephoneNumber,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                City = c.City,
                County = c.County,
                Postcode = c.Postcode,
                Country = c.Country,
                TitlePrefixId = c.TitlePrefixId,
                TitlePrfixName = c.TitlePrfixName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName,
                CaseNumber = c.CaseNumber,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                CompanyName = c.CompanyName,
                UserId = c.UserId
            });
        }

        public async Task<IEnumerable<SubjectViewModel>> GetAllSubjectsWithCaseAsync()
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Subjects> subjects = await subjectDM.GetAllSubjectsWithCaseAsync();

            return subjects.Select(c => new SubjectViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Alias = c.Alias,
                AssociatedCompany = c.AssociatedCompany,
                Notes = c.Notes,
                Email = c.Email,
                TelephoneNumber = c.TelephoneNumber,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                City = c.City,
                County = c.County,
                Postcode = c.Postcode,
                Country = c.Country,
                TitlePrefixId = c.TitlePrefixId,
                TitlePrfixName = c.TitlePrfixName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName,
                CaseNumber = c.CaseNumber,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                CompanyName = c.CompanyName
            });
        }

        public async Task<SubjectViewModel> GetSubjectsByIdAsync(Guid id)
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            CMS.DL.Model.Subjects subject = await subjectDM.GetSubjectsByIdAsync(id);

            return new SubjectViewModel
            {
                Id = subject.Id,
                Created = subject.Created,
                CreatedBy = subject.CreatedBy,
                Updated = subject.Updated,
                UpdatedBy = subject.UpdatedBy,
                FirstName = subject.FirstName,
                MiddleName = subject.MiddleName,
                LastName = subject.LastName,
                DateOfBirth = subject.DateOfBirth,
                Alias = subject.Alias,
                AssociatedCompany = subject.AssociatedCompany,
                Notes = subject.Notes,
                Email = subject.Email,
                TelephoneNumber = subject.TelephoneNumber,
                AddressLine1 = subject.AddressLine1,
                AddressLine2 = subject.AddressLine2,
                AddressLine3 = subject.AddressLine3,
                City = subject.City,
                County = subject.County,
                Postcode = subject.Postcode,
                Country = subject.Country,
                TitlePrefixId = subject.TitlePrefixId,
                TitlePrfixName = subject.TitlePrfixName,
                SubjectName = subject.SubjectName,
                ClientName = subject.ClientName,
                AgentName = subject.AgentName,
                CaseNumber = subject.CaseNumber,
                ClientRef = subject.ClientRef,
                EndClient = subject.EndClient,
                CompanyName = subject.CompanyName
            };
        }

        public async Task<SubjectViewModel> GetLastSubjectsAsync()
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            CMS.DL.Model.Subjects subject = await subjectDM.GetLastSubjectsAsync();

            if (subject != null)
            {
                return new SubjectViewModel
                {
                    Id = subject.Id,
                    Created = subject.Created,
                    CreatedBy = subject.CreatedBy,
                    Updated = subject.Updated,
                    UpdatedBy = subject.UpdatedBy,
                    FirstName = subject.FirstName,
                    MiddleName = subject.MiddleName,
                    LastName = subject.LastName,
                    DateOfBirth = subject.DateOfBirth,
                    Alias = subject.Alias,
                    AssociatedCompany = subject.AssociatedCompany,
                    Notes = subject.Notes,
                    Email = subject.Email,
                    TelephoneNumber = subject.TelephoneNumber,
                    AddressLine1 = subject.AddressLine1,
                    AddressLine2 = subject.AddressLine2,
                    AddressLine3 = subject.AddressLine3,
                    City = subject.City,
                    County = subject.County,
                    Postcode = subject.Postcode,
                    Country = subject.Country,
                    TitlePrefixId = subject.TitlePrefixId,
                    TitlePrfixName = subject.TitlePrfixName,
                    SubjectName = subject.SubjectName,
                    ClientName = subject.ClientName,
                    AgentName = subject.AgentName,
                    CaseNumber = subject.CaseNumber,
                    ClientRef = subject.ClientRef,
                    EndClient = subject.EndClient,
                    CompanyName = subject.CompanyName,
                    UserId = subject.UserId
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<SubjectViewModel>> SearchSubjectsAsync(
            string firstName,
            string lastName,
            string postCode,
            string dob)
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Subjects> subjects = await subjectDM.SearchSubjectsAsync(firstName, lastName, postCode, dob);

            return subjects.Select(c => new SubjectViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Alias = c.Alias,
                AssociatedCompany = c.AssociatedCompany,
                Notes = c.Notes,
                Email = c.Email,
                TelephoneNumber = c.TelephoneNumber,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                City = c.City,
                County = c.County,
                Postcode = c.Postcode,
                Country = c.Country,
                TitlePrefixId = c.TitlePrefixId,
                TitlePrfixName = c.TitlePrfixName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName,
                CaseNumber = c.CaseNumber,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                CompanyName = c.CompanyName,
                UserId = c.UserId
            });
        }

        public async Task<IEnumerable<SubjectViewModel>> GetAllSubjectsWithCaseByAgentAsync(Guid id)
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            IEnumerable<CMS.DL.Model.Subjects> subjects = await subjectDM.GetAllSubjectsWithCaseByAgentAsync(id);

            return subjects.Select(c => new SubjectViewModel
            {
                Id = c.Id,
                Created = c.Created,
                CreatedBy = c.CreatedBy,
                Updated = c.Updated,
                UpdatedBy = c.UpdatedBy,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Alias = c.Alias,
                AssociatedCompany = c.AssociatedCompany,
                Notes = c.Notes,
                Email = c.Email,
                TelephoneNumber = c.TelephoneNumber,
                AddressLine1 = c.AddressLine1,
                AddressLine2 = c.AddressLine2,
                AddressLine3 = c.AddressLine3,
                City = c.City,
                County = c.County,
                Postcode = c.Postcode,
                Country = c.Country,
                TitlePrefixId = c.TitlePrefixId,
                TitlePrfixName = c.TitlePrfixName,
                SubjectName = c.SubjectName,
                ClientName = c.ClientName,
                AgentName = c.AgentName,
                CaseNumber = c.CaseNumber,
                ClientRef = c.ClientRef,
                EndClient = c.EndClient,
                CompanyName = c.CompanyName,
                UserId = c.UserId,
                CaseId = c.CaseId,
                CaseCreated = c.CaseCreated,
                CaseNotes = c.CaseNotes
            });
        }

        public async Task<SubjectViewModel> GetSubjectsWithCaseByCaseIdAsync(Guid id)
        {
            SubjectsDM subjectDM = new SubjectsDM(_connectionString);
            CMS.DL.Model.Subjects subject = await subjectDM.GetSubjectsWithCaseByCaseIdAsync(id);

            if (subject != null)
            {
                return new SubjectViewModel
                {
                    Id = subject.Id,
                    Created = subject.Created,
                    CreatedBy = subject.CreatedBy,
                    Updated = subject.Updated,
                    UpdatedBy = subject.UpdatedBy,
                    FirstName = subject.FirstName,
                    MiddleName = subject.MiddleName,
                    LastName = subject.LastName,
                    DateOfBirth = subject.DateOfBirth,
                    Alias = subject.Alias,
                    AssociatedCompany = subject.AssociatedCompany,
                    Notes = subject.Notes,
                    Email = subject.Email,
                    TelephoneNumber = subject.TelephoneNumber,
                    AddressLine1 = subject.AddressLine1,
                    AddressLine2 = subject.AddressLine2,
                    AddressLine3 = subject.AddressLine3,
                    City = subject.City,
                    County = subject.County,
                    Postcode = subject.Postcode,
                    Country = subject.Country,
                    TitlePrefixId = subject.TitlePrefixId,
                    TitlePrfixName = subject.TitlePrfixName,
                    SubjectName = subject.SubjectName,
                    ClientName = subject.ClientName,
                    AgentName = subject.AgentName,
                    CaseNumber = subject.CaseNumber,
                    ClientRef = subject.ClientRef,
                    EndClient = subject.EndClient,
                    CompanyName = subject.CompanyName,
                    UserId = subject.UserId,
                    CaseId = subject.CaseId,
                    CaseCreated = subject.CaseCreated,
                    CaseNotes = subject.CaseNotes
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertSubjectsAsync(SubjectViewModel subjectViewModel)
        {
            SubjectsDM subjectsDM = new SubjectsDM(_connectionString);
            int result = await subjectsDM.InsertSubjectsAsync(new CMS.DL.Model.Subjects
            {
                Created = subjectViewModel.Created,
                CreatedBy = subjectViewModel.CreatedBy,
                Updated = subjectViewModel.Updated,
                UpdatedBy = subjectViewModel.UpdatedBy,
                FirstName = subjectViewModel.FirstName,
                MiddleName = subjectViewModel.MiddleName,
                LastName = subjectViewModel.LastName,
                DateOfBirth = subjectViewModel.DateOfBirth,
                Alias = subjectViewModel.Alias,
                AssociatedCompany = subjectViewModel.AssociatedCompany,
                Notes = subjectViewModel.Notes,
                Email = subjectViewModel.Email,
                TelephoneNumber = subjectViewModel.TelephoneNumber,
                AddressLine1 = subjectViewModel.AddressLine1,
                AddressLine2 = subjectViewModel.AddressLine2,
                AddressLine3 = subjectViewModel.AddressLine3,
                City = subjectViewModel.City,
                County = subjectViewModel.County,
                Postcode = subjectViewModel.Postcode,
                Country = subjectViewModel.Country,
                TitlePrefixId = subjectViewModel.TitlePrefixId,

            });
            return result;
        }

        public async Task<int> UpdateSubjectsAsync(SubjectViewModel subjectViewModel)
        {
            SubjectsDM subjectsDM = new SubjectsDM(_connectionString);
            int result = await subjectsDM.UpdateSubjectsAsync(new CMS.DL.Model.Subjects
            {
                Id = subjectViewModel.Id,
                Created = subjectViewModel.Created,
                CreatedBy = subjectViewModel.CreatedBy,
                Updated = subjectViewModel.Updated,
                UpdatedBy = subjectViewModel.UpdatedBy,
                FirstName = subjectViewModel.FirstName,
                MiddleName = subjectViewModel.MiddleName,
                LastName = subjectViewModel.LastName,
                DateOfBirth = subjectViewModel.DateOfBirth,
                Alias = subjectViewModel.Alias,
                AssociatedCompany = subjectViewModel.AssociatedCompany,
                Notes = subjectViewModel.Notes,
                Email = subjectViewModel.Email,
                TelephoneNumber = subjectViewModel.TelephoneNumber,
                AddressLine1 = subjectViewModel.AddressLine1,
                AddressLine2 = subjectViewModel.AddressLine2,
                AddressLine3 = subjectViewModel.AddressLine3,
                City = subjectViewModel.City,
                County = subjectViewModel.County,
                Postcode = subjectViewModel.Postcode,
                Country = subjectViewModel.Country,
                TitlePrefixId = subjectViewModel.TitlePrefixId,

            });
            return result;
        }

        public async Task<int> DeleteSubjectsAsync(Guid id)
        {
            SubjectsDM subjectsDM = new SubjectsDM(_connectionString);
            int result = await subjectsDM.DeleteSubjectsAsync(id);

            return result;
        }

        #endregion
    }
}
