using AssetManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompany(int id);
        Task<List<Company>> ListAllCompany();
        Task<Company> AddCompany(Company entity);
        Task UpdateCompany(Company entity);
        Task DeleteCompany(Company entity);
    }
}
