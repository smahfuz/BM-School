﻿using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IClassLevelService
    {
        Task InsertAsync(ClassLevel obj);
        Task UpdateAsync(ClassLevel obj);
        Task DeleteAsync(ClassLevel obj);
        Task SaveChangesAsync();
        Task<IList<ClassLevel>> GetAllAsync();
        Task<ClassLevel> GetIdAsync(int id);
        Task<ClassLevel> SearchStudentByClassIdAsync(int id);
    }
}
