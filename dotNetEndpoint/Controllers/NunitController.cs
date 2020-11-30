﻿using dotNetEndpoint.Models;
using dotNetEndpointApp.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class NunitController : Controller
    {
        [Route("assert_equal")]
        public string AssertEqual()
        {
            string test = "";
            int a = 5, b = 4;
            b = 5;
            Assert.AreEqual(a, b);
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_equal");
            return test;
        }
        [Route("assert_equal_exception")]
        public string AssertEqualException()
        {
            string test = "";
            int a = 5, b = 4;
            try
            {
                Assert.AreEqual(a, b);
                test += "True";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_equal_exception");
            return test;
        }
        [Route("assert_false")]
        public string AssertFalse()
        {
            string test = "";
            int a = 5, b = 4;
            try
            {
                Assert.False(a == 0, "a jest równe 0");
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_false");
            return test;
        }
        [Route("assert_true")]
        public string AssertTrue()
        {
            string test = "";
            int a = 0, b = 4;
            try
            {
                Assert.True(a == 0, "a jest równe 0");
                test += "a jest równe 0";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_true");
            return test;
        }
        [Route("assert_null_exception")]

        public string AssertNullException()
        {
            string test = "";
            int a = 0, b = 4;
            try
            {
                Assert.Null(a, "a nie jest nullem");
                test += "true";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_null_exception");
            return test;
        }
        [Route("assert_null")]

        public string AssertNull()
        {
            string test = "";
            string a = null;
            try
            {
                Assert.Null(a, "a nie jest nullem");
                test += "true";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_null");
            return test;
        }
        [Route("assert_arrays")]

        public string AssertArrays()
        {
            string test = "";
            var thing = new MyOtherClass();

            var expected = new List<MyOtherClass>();
            expected.Add(thing);

            var actual = new List<MyOtherClass>();
            actual.Add(thing);

            try
            {
                CollectionAssert.AreEqual(expected, actual);
                test += "true";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_arrays");
            return test;
        }
        [Route("assert_arrays_exception")]

        public string AssertArraysException()
        {
            string test = "";
            var thing = new MyOtherClass();
            var nunitThing = new MyNUnitClass();

            var expected = new List<MyOtherClass>();
            expected.Add(thing);

            var actual = new List<MyNUnitClass>();
            actual.Add(nunitThing);

            try
            {
                CollectionAssert.AreEqual(expected, actual);
                test += "true";
            }
            catch (Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("assert_arrays_exception");
            return test;
        }
        [Route("person_comparer")]

        public string PersonComparer()
        {
            string test = "";
            Person p1 = new Person { FirstName = "Tom", LastName = "Hamilton" };
            Person p2 = new Person { FirstName = "Tom", LastName = "Hamilton" };
            Person p3 = new Person { FirstName = "Lewis", LastName = "Hamilton" };

            Assert.AreSame(p1.FirstName, p2.FirstName);
            RevDeBugAPI.Snapshot.RecordSnapshot("person_comparer");
            return test;


        }
        [Route("person_comparer_exception")]

        public string PersonComparerException()
        {
            string test = "";
            Person p1 = new Person { FirstName = "Tom", LastName = "Hamilton" };
            Person p2 = new Person { FirstName = "Tom", LastName = "Hamilton" };
            Person p3 = new Person { FirstName = "Lewis", LastName = "Hamilton" };

            try
            {
                Assert.AreSame(p1, p2);
            }
            catch(Exception e)
            {
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("person_comparer");
            return test;
        }
    }
}