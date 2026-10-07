using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region constructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
         return  await _studentRepository.GetStudentListAsync();
        }

        public async Task<Student> GetStudentByIDAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                            .Include(x=>x.Department)
                                            .Where(x=>x.StudID.Equals(id))
                                            .FirstOrDefault();
            return student;
                                                
        }
        #endregion


    }
}
