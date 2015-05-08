using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{
   

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course course = new Course();
            course.ID = "chinese";
            course.NAME = "國文";
            course.Description = "古今中外";
            CourseDao.AddCourse(course);

            Course dbCourse = CourseDao.GetCourseById(course.ID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.ID, dbCourse.ID);

            Console.WriteLine("課程編號為 = " + dbCourse.ID);
            Console.WriteLine("課程名稱為 = " + dbCourse.NAME);
            Console.WriteLine("課程敘述為 = " + dbCourse.Description);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseById(course.ID);
            Assert.IsNull(dbCourse);
        }

        //[TestMethod]
        //public void TestCourseDao_UpdateCourse()
        //{
        //    // 取得資料
        //    Course Course = CourseDao.GetCourseById("dennis_yen");
        //    Assert.IsNotNull(Course);

        //    // 更新資料
        //    Course.Name = "單元測試";
        //    CourseDao.UpdateCourse(Course);

        //    // 再次取得資料
        //    Course dbCourse = CourseDao.GetCourseById(Course.Id);
        //    Assert.IsNotNull(dbCourse);
        //    Assert.AreEqual(Course.Name, dbCourse.Name);

        //    Console.WriteLine("員工編號為 = " + dbCourse.Id);
        //    Console.WriteLine("員工姓名為 = " + dbCourse.Name);
        //    Console.WriteLine("員工年齡為 = " + dbCourse.Age);

        //    Console.WriteLine("================================");

        //    // 將資料改回來
        //    Course.Name = "嚴志和";
        //    CourseDao.UpdateCourse(Course);

        //    // 再次取得資料
        //    dbCourse = CourseDao.GetCourseById(Course.Id);
        //    Assert.IsNotNull(dbCourse);
        //    Assert.AreEqual(Course.Name, dbCourse.Name);

        //    Console.WriteLine("員工編號為 = " + dbCourse.Id);
        //    Console.WriteLine("員工姓名為 = " + dbCourse.Name);
        //    Console.WriteLine("員工年齡為 = " + dbCourse.Age);
        //}


        //[TestMethod]
        //public void TestCourseDao_DeleteCourse()
        //{
        //    Course newCourse = new Course();
        //    newCourse.Id = "UnitTests";
        //    newCourse.Name = "單元測試";
        //    newCourse.Age = 15;
        //    CourseDao.AddCourse(newCourse);

        //    Course dbCourse = CourseDao.GetCourseById(newCourse.Id);
        //    Assert.IsNotNull(dbCourse);

        //    CourseDao.DeleteCourse(dbCourse);
        //    dbCourse = CourseDao.GetCourseById(newCourse.Id);
        //    Assert.IsNull(dbCourse);
        //}

        [TestMethod]
        public void TestCourseDao_GetCourseById()
        {
            Course course = CourseDao.GetCourseById("chinese");
            Assert.IsNotNull(course);
            Console.WriteLine("課程編號為 = " + course.ID);
            Console.WriteLine("課程名稱為 = " + course.NAME);
            Console.WriteLine("課程敘述為 = " + course.Description);
        }

    }
}
