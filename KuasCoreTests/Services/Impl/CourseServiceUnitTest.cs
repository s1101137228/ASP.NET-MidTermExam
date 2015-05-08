using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services.Impl
{
   
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.ID = "chinese";
            course.NAME = "國文";
            course.Description = "古今中外";
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseById(course.ID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.ID, course.ID);

            Console.WriteLine("課程編號為 = " + dbCourse.ID);
            Console.WriteLine("課程名稱為 = " + dbCourse.NAME);
            Console.WriteLine("課程敘述為 = " + dbCourse.Description);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(course.ID);
            Assert.IsNull(dbCourse);
        }

        //[TestMethod]
        //public void TestEmployeeService_UpdateEmployee()
        //{
        //    // 取得資料
        //    Employee empolyee = EmployeeService.GetEmployeeById("dennis_yen");
        //    Assert.IsNotNull(empolyee);

        //    // 更新資料
        //    empolyee.Name = "單元測試";
        //    EmployeeService.UpdateEmployee(empolyee);

        //    // 再次取得資料
        //    Employee dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);
        //    Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

        //    Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);

        //    Console.WriteLine("================================");

        //    // 將資料改回來
        //    empolyee.Name = "嚴志和";
        //    EmployeeService.UpdateEmployee(empolyee);

        //    // 再次取得資料
        //    dbEmpolyee = EmployeeService.GetEmployeeById(empolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);
        //    Assert.AreEqual(empolyee.Name, dbEmpolyee.Name);

        //    Console.WriteLine("員工編號為 = " + dbEmpolyee.Id);
        //    Console.WriteLine("員工姓名為 = " + dbEmpolyee.Name);
        //    Console.WriteLine("員工年齡為 = " + dbEmpolyee.Age);
        //}


        //[TestMethod]
        //public void TestEmployeeService_DeleteEmployee()
        //{
        //    Employee newEmpolyee = new Employee();
        //    newEmpolyee.Id = "UnitTests";
        //    newEmpolyee.Name = "單元測試";
        //    newEmpolyee.Age = 15;
        //    EmployeeService.AddEmployee(newEmpolyee);

        //    Employee dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
        //    Assert.IsNotNull(dbEmpolyee);

        //    EmployeeService.DeleteEmployee(dbEmpolyee);
        //    dbEmpolyee = EmployeeService.GetEmployeeById(newEmpolyee.Id);
        //    Assert.IsNull(dbEmpolyee);
        //}

        [TestMethod]
        public void TestCourseService_GetCourseById()
        {
            Course course = CourseService.GetCourseById("chinese");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.ID);
            Console.WriteLine("課程名稱為 = " + course.NAME);
            Console.WriteLine("課程敘述為 = " + course.Description);
        }

    }
}
