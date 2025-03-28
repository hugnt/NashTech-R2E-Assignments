using Assignment03.API.Models;

namespace Assignment03.API.Services
{
    public interface IStudentService
    {
        public APIResponseModel<List<StudentModel>> GetAll();
        public APIResponseModel<StudentModel> GetById(int studentId);
        public APIResponseModel<bool> Add(StudentModel newStudent);
        public APIResponseModel<bool> Update(int studentId, StudentModel studentModel);
        public APIResponseModel<bool> Delete(int studentId);
    }
}
