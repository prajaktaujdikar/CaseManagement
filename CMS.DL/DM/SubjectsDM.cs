using CMS.DL.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CMS.DL.DM
{
    public class SubjectsDM
    {
        private readonly IDbConnection _dbConnection;

        public SubjectsDM(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        #region GET

        public async Task<IEnumerable<Subjects>> GetAllSubjectsAsync()
        {
            string sql = "SELECT * FROM Subjects";
            return await _dbConnection.QueryAsync<Subjects>(sql);
        }

        public async Task<IEnumerable<Subjects>> GetAllSubjectsWithCaseAsync()
        {
            string sql = "SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName FROM Subjects AS S LEFT JOIN Cases AS C ON S.Id = C.SubjectId LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id";
            return await _dbConnection.QueryAsync<Subjects>(sql);
        }

        public async Task<IEnumerable<Subjects>> GetSubjectsByClientAsync(Guid? id)
        {
            string sql = $"SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName FROM Subjects AS S LEFT JOIN Cases AS C ON S.Id = C.SubjectId LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id WHERE S.CreatedBy = @CreatedBy";
            return await _dbConnection.QueryAsync<Subjects>(sql, new { CreatedBy = id });
        }

        public async Task<Subjects> GetSubjectsByIdAsync(Guid id)
        {
            string sql = "SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName FROM Subjects AS S LEFT JOIN Cases AS C ON S.Id = C.SubjectId LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id WHERE S.Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Subjects>(sql, new { Id = id });
        }

        public async Task<Subjects> GetLastSubjectsAsync()
        {
            string sql = $"SELECT TOP 1 S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName FROM Subjects AS S LEFT JOIN Cases AS C ON S.Id = C.SubjectId LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id ORDER BY S.Created DESC";
            return await _dbConnection.QueryFirstOrDefaultAsync<Subjects>(sql);
        }

        public async Task<IEnumerable<Subjects>> SearchSubjectsAsync(
            string firstName, 
            string lastName,
            string postCode,
            string dob)
        {
            string sql = $"SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName FROM Subjects AS S LEFT JOIN Cases AS C ON S.Id = C.SubjectId LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id WHERE S.FirstName LIKE @FirstName OR S.LastName LIKE @LastName OR S.Postcode LIKE @Postcode OR S.DateOfBirth = @DateOfBirth";
            return await _dbConnection.QueryAsync<Subjects>(sql, new { FirstName = firstName, LastName = lastName, Postcode = postCode, DateOfBirth = dob });
        }

        public async Task<IEnumerable<Subjects>> GetAllSubjectsWithCaseByAgentAsync(Guid id)
        {
            string sql = "SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName, C.Created AS CaseCreated, C.Id AS CaseId, C.Notes AS CaseNotes FROM Cases AS C INNER JOIN Subjects AS S ON C.SubjectId = S.Id LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id WHERE C.EndClient = @EndClient";
            return await _dbConnection.QueryAsync<Subjects>(sql, new { EndClient = id });
        }

        public async Task<Subjects> GetSubjectsWithCaseByCaseIdAsync(Guid id)
        {
            string sql = "SELECT S.*,TP.[Name] AS TitlePrfixName,C.CaseNumber,C.ClientRef,C.EndClient,CONCAT(S.FirstName, ' ', S.LastName) as SubjectName, CONCAT(CU.FirstName, ' ', CU.LastName) AS ClientName, CONCAT(AU.FirstName, ' ', AU.LastName) AS AgentName, CO.CompanyName, C.Created AS CaseCreated, C.Id AS CaseId, C.Notes AS CaseNotes FROM Cases AS C INNER JOIN Subjects AS S ON C.SubjectId = S.Id LEFT JOIN TitlePrefixes AS TP ON S.TitlePrefixId = TP.Id LEFT JOIN Users AS CU ON C.ClientRef = CU.Id LEFT JOIN Users AS AU ON C.EndClient = AU.Id LEFT JOIN Companies AS CO ON S.AssociatedCompany = CO.Id WHERE C.Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Subjects>(sql, new { Id = id });
        }

        #endregion

        #region INSERT/UPDATE/DELETE

        public async Task<int> InsertSubjectsAsync(Subjects subjects)
        {
            string sql = $"INSERT INTO Subjects(Created, CreatedBy, Updated, UpdatedBy, FirstName, MiddleName, LastName, DateOfBirth, Alias, AssociatedCompany, Notes, Email, TelephoneNumber, AddressLine1, AddressLine2, AddressLine3, City, County, Postcode, Country, TitlePrefixId) VALUES(@Created, @CreatedBy, @Updated, @UpdatedBy, @FirstName, @MiddleName, @LastName, @DateOfBirth, @Alias, @AssociatedCompany, @Notes, @Email, @TelephoneNumber, @AddressLine1, @AddressLine2, @AddressLine3, @City, @County, @Postcode, @Country, @TitlePrefixId)";
            return await _dbConnection.ExecuteAsync(sql, new { Created = subjects.Created, CreatedBy = subjects.CreatedBy, Updated = subjects.Updated, UpdatedBy = subjects.UpdatedBy, FirstName = subjects.FirstName, MiddleName = subjects.MiddleName, LastName = subjects.LastName, DateOfBirth = subjects.DateOfBirth, Alias = subjects.Alias, AssociatedCompany = subjects.AssociatedCompany, Notes = subjects.Notes, Email = subjects.Email, TelephoneNumber = subjects.TelephoneNumber, AddressLine1 = subjects.AddressLine1, AddressLine2 = subjects.AddressLine2, AddressLine3 = subjects.AddressLine3, City = subjects.City, County = subjects.County, Postcode = subjects.Postcode, Country = subjects.Country, TitlePrefixId = subjects.TitlePrefixId });
        }

        public async Task<int> UpdateSubjectsAsync(Subjects subjects)
        {
            string sql = $"UPDATE Subjects SET Created = @Created, CreatedBy = @CreatedBy, Updated = @Updated, UpdatedBy = @UpdatedBy, FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DateOfBirth = @DateOfBirth, Alias = @Alias, AssociatedCompany = @AssociatedCompany, Notes = @Notes , Email = @Email, TelephoneNumber = @TelephoneNumber, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressLine3 =@AddressLine3, City = @City, County = @County, Postcode = @Postcode, Country = @Country, TitlePrefixId = @TitlePrefixId WHERE Id = @Id ";
            return await _dbConnection.ExecuteAsync(sql, new { Created = subjects.Created, CreatedBy = subjects.CreatedBy, Updated = subjects.Updated, UpdatedBy = subjects.UpdatedBy, FirstName = subjects.FirstName, MiddleName = subjects.MiddleName, LastName = subjects.LastName, DateOfBirth = subjects.DateOfBirth, Alias = subjects.Alias, AssociatedCompany = subjects.AssociatedCompany, Notes = subjects.Notes, Email = subjects.Email, TelephoneNumber = subjects.TelephoneNumber, AddressLine1 = subjects.AddressLine1, AddressLine2 = subjects.AddressLine2, AddressLine3 = subjects.AddressLine3, City = subjects.City, County = subjects.County, Postcode = subjects.Postcode, Country = subjects.Country, TitlePrefixId = subjects.TitlePrefixId, Id = subjects.Id });
        }

        public async Task<int> DeleteSubjectsAsync(Guid id)
        {
            string sql = $"DELETE FROM Subjects WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        #endregion
    }
}
