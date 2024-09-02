﻿using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface IClasslevelRepository : IRepository<ClassLevel>
    {
        Task<ClassLevel> SearchStudentByClassId(int id);
        Task<ClassLevel> SearchStudentByClassIdAsync(int id);
    }
}
