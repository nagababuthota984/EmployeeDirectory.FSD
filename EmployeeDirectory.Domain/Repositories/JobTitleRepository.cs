﻿using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Infra.Persistence;

namespace EmployeeDirectory.Domain.Repositories
{
    public class JobTitleRepository : IRepository<JobTitle>
    {
        private readonly EmployeeDirectoryDbContext _dbContext;
        public JobTitleRepository(EmployeeDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(JobTitle entity)
        {
            await _dbContext.JobTitles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();    
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(JobTitle entity)
        {
            try
            {
                _dbContext.JobTitles.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<JobTitle>> GetAllAsync()
        {
            return _dbContext.JobTitles.ToList();
        }

        public async Task<JobTitle> GetByIdAsync(int id)
        {
            return _dbContext.JobTitles.FirstOrDefault(jobTitle => jobTitle.Id == id);
        }

        public async Task<int> UpdateAsync(JobTitle entity)
        {
            _dbContext.JobTitles.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
