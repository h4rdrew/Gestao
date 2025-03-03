using Gestao.Client.Libraries;
using Gestao.Data.Interfaces;
using Gestao.Domain;

namespace Gestao.Data.Repositories;

public class CompanyRepository : ICompany
{
    private readonly ApplicationDbContext _db;

    public CompanyRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Add(Company company)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Company Get(int id)
    {
        throw new NotImplementedException();
    }

    public PaginatedList<Company> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Company company)
    {
        throw new NotImplementedException();
    }
}
