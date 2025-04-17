## Unit test ✅

- **Position**: 
		 <br>- Branch: [unit_test](https://github.com/hugnt/NashTech-R2E-Assignments/tree/unit_test)
		 <br>- Folder: [Assignment04-05-MVC](https://github.com/hugnt/NashTech-R2E-Assignments/tree/unit_test/Assignment04-05-MVC)
		 <br>- Quick access: [Here](https://github.com/hugnt/NashTech-R2E-Assignments/tree/unit_test/Assignment04-05-MVC)
 - **Content**: 
	-	***Requirement*** 
		-	Create Unit Tests for the actions of RookiesController 
		-	Create Unit Tests for all business method which used in the above controller
	-	***Objectives:*** The unit test must be covered at least 70% line of code that we had implemented for controller and business
	-	***Implementation:*** 
		-	All Test cases is located in `Assignment04-05-MVC.Tests` project
		-	***GlobalTestData:*** contains these data that can be mocked into repository
		-	***Services > PersonServicesTest:***
			-	File .cs: AddTests, DeteleTests, GetByFilterTests, ... represent for each method in PersonService
			-	TestData: contains these data that used to test for specific method in PersonService
			-	ExpectedResultModel: contains these class may TestData need to using (for clear coding)
		- ***Controllers >  RookiesControllerTests:***
			-  TestData: contains these data that used to test for specific method in RookiesController
			- File .cs: AddNewTests, DeteleTests, DetailsTests, ... represent for each method in RookiesController
		- 	***Repositories> PersonRepositoryTests:***
			-	File .cs: AddTests, RemoveTests, GetaAllQueryAble, ... represent for each method in PersonRepository
	-	***What did I do?***	
			 <br>-	Using XUnit 
			 <br>-	Add validation for Person using Fluent Validation
			 <br>-	Writing test case for all method in PersonService:
			 <br>-	Writing test case for all method in RookiesController
			 <br>-	Writing test case for all method in PersonRepository
			 <br>-	Apply Fluent Insertion for all test case
			 <br>-	Apply [Fact] & [Theory]
			 <br>-	Mocking data for Repository (in PersonService) and Service (in RookiesController)
 - **Step by step**:
	-	Clone:  https://github.com/hugnt/NashTech-R2E-Assignments/tree/main
	- 	Then change to branch: `unit_test`
	- 	Then access folder: `Assignment04-05-MVC`
	- 	(or clone directly to branch by command: git clone --branch unit_test --single-branch https://github.com/hugnt/NashTech-R2E-Assignments.git)
	-	***To Run Test Case:***
		-	Open solution (.sln file) by Visual Studio
		-	Open `Test` tab then click `Run All Tests`
	- ***To See Code Coverage:***
		- Install extension FCC (Fine Code Coverage)
		- Open View > Other Window > Fine Code Coverage to see the FCC window
		- Run All Test Case again: then see FCC window
	- ***To Run Application***: 
		- Open solution (.sln file) by Visual Studio and click Run ▶️ button 

