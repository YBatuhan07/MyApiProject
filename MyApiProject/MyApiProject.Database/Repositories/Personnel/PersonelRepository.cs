using Microsoft.EntityFrameworkCore;
using MyApiProject.Database.Context;
using MyApiProject.DomainLayer;
using System.Linq.Expressions;

namespace MyApiProject.Database.Repositories;

public class PersonelRepository : BaseRepository<Personnel>, IPersonelRepository
{
    public PersonelRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<Personnel> AddAsync(Personnel personnel)
    {
        await AddAsync(personnel);

        return personnel;
    }
    public async Task<Personnel> Update(Personnel model)
    {
        await UpdateAsyn(model);
        return model;
    }
    public IQueryable<Personnel> GetPersonnelQueryable(Expression<Func<Personnel, bool>>? expression = null)
    {
        return expression == null ? Queryabla() : Queryabla(expression);
    }
}