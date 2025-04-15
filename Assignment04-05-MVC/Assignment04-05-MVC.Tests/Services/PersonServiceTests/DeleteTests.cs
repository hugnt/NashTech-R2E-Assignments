using Assignment04_05_MVC.Models;
using Assignment04_05_MVC.Repositories;
using Assignment04_05_MVC.Services;
using Assignment04_05_MVC.Tests.TestData;
using FluentAssertions;
using Moq;
using System.Net;

namespace Assignment04_05_MVC.Tests.Services.PersonServiceTest;

public class DeleteTests
{
	private readonly Mock<IPersonRepository> _mockPersonRepository;
	private readonly PersonService _personService;
	public DeleteTests()
	{
		_mockPersonRepository = new Mock<IPersonRepository>();
		_personService = new PersonService(_mockPersonRepository.Object, null);
	}

	[Theory]
	[InlineData(11)]
	[InlineData(12)]
	[InlineData(13)]
	public void Delete_NotExistedId_ReturnErrorNotFound(int id)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Delete(id);

		result.IsSuccess.Should().BeFalse();
		result.StatusCode.Should().Be(HttpStatusCode.NotFound);
		
	}

	[Theory]
	[InlineData(1)]
	[InlineData(2)]
	[InlineData(3)]
	public void Delete_ValidId_ReturnSuccessResult(int id)
	{
		var data = RepositoryData.ListPersonsTest().AsQueryable();
		_mockPersonRepository.Setup(r => r.GetAllQueryAble()).Returns(data);

		var result = _personService.Delete(id);

		result.IsSuccess.Should().BeTrue();
		result.StatusCode.Should().Be(HttpStatusCode.NoContent);

		_mockPersonRepository.Verify(r => r.Remove(It.IsAny<Person>()), Times.Once);
	}

}
