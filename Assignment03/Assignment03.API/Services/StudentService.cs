using Assignment03.API.Models;

namespace Assignment03.API.Services
{
    public class StudentService : IStudentService
    {
        private List<StudentModel> Students = new List<StudentModel>()
        {
            new StudentModel { Id = 1, Name = "Nguyen Thanh Hung",BirthDate = DateTime.Parse("2003/02/13"),Email="hung@gmail.com",PhoneNumber="0946928815" },
            new StudentModel { Id = 2, Name = "Doan Nhat Anh",BirthDate = DateTime.Parse("2003/01/03"),Email="hung@gmail.com",PhoneNumber="0946928815" },
            new StudentModel { Id = 3, Name = "Cu Trung Canh",BirthDate = DateTime.Parse("2003/06/12"),Email="hung@gmail.com",PhoneNumber="0946928815" },
            new StudentModel { Id = 4, Name = "Le Quoc Viet",BirthDate = DateTime.Parse("2003/12/12"),Email="hung@gmail.com",PhoneNumber="0946928815" }
        };
        public APIResponseModel<bool> Add(StudentModel newStudent)
        {
            try
            {
                if (Students.Any(x => x.Id == newStudent.Id))
                {
                    throw new Exception("Student is existed"); 
                }
                Students.Add(newStudent);
                return new APIResponseModel<bool>()
                {
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new APIResponseModel<bool>()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = new List<string>() { e.Message}
                };
            }
          
        }
        public APIResponseModel<bool> Delete(int studentId)
        {
            try
            {
                if (!Students.Any(x => x.Id == studentId))
                {
                    throw new Exception("Student is not existed");
                }
                Students.Remove(Students.First(x => x.Id == studentId));
                return new APIResponseModel<bool>()
                {
                    IsSuccess = true,
                    StatusCode = 201
                };
            }
            catch (Exception e)
            {
                return new APIResponseModel<bool>()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = new List<string>() { e.Message }
                };
            }
        }
        public APIResponseModel<List<StudentModel>> GetAll()
        {
            try
            {
                return new APIResponseModel<List<StudentModel>>()
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Metadata = Students
                };
            }
            catch (Exception e)
            {
                return new APIResponseModel<List<StudentModel>>()
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = new List<string>() { e.Message }
                };
            }
        }
        public APIResponseModel<StudentModel> GetById(int studentId)
        {
            try
            {
                if (!Students.Any(x => x.Id == studentId))
                {
                    throw new Exception("Student is not existed");
                }
                return new APIResponseModel<StudentModel>()
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Metadata = Students.First(x => x.Id == studentId)
                };
            }
            catch (Exception e)
            {
                return new APIResponseModel<StudentModel>()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = new List<string>() { e.Message }
                };
            }
        }
        public APIResponseModel<bool> Update(int studentId, StudentModel studentModel)
        {
            try
            {
                if (!Students.Any(x => x.Id == studentId))
                {
                    throw new Exception("Student is not existed");
                }
                foreach (var student in Students)
                {
                    if(student.Id == studentId)
                    {
                        student.Name = studentModel.Name;
                        student.Email = studentModel.Email;
                        student.PhoneNumber = studentModel.PhoneNumber;
                        student.BirthDate = studentModel.BirthDate;
                    }
                }
                return new APIResponseModel<bool>()
                {
                    IsSuccess = true,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                return new APIResponseModel<bool>()
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = new List<string>() { e.Message }
                };
            }
        }
    }
}
