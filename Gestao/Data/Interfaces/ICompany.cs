using Gestao.Client.Libraries;
using Gestao.Domain;

namespace Gestao.Data.Interfaces;

    public interface ICompany
    {
    PaginatedList<Company> GetAll();
    Company Get(int id);
    void Add(Company company);
    void Update(Company company);
    void Delete(int id);
}

