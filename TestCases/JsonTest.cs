﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
using ILRuntimeTest.TestFramework;

namespace TestCases
{
    class JsonTest
    {
        enum JsonTestEnum
        {
            Test1,
            Test2,
            Test3,
        }
        class JsonTestClass
        {
            public static int StaticField;
            public static int StaticProp { get; set; }

            public int IntProp { get; set; }
            public string StringProp { get; set; }
            public JsonTestEnum EnumProp { get; set; }
            public JsonTestSubClass SubClassProp { get; set; }
            public Dictionary<string, JsonTestSubClass> DicTest { get; set; }
            public Dictionary<string, int> DicTest2 { get; set; }

            [JsonIgnore]
            public int IgnoreField;

            [JsonIgnore]
            public int IgnoreProp { get; set; }


        }

        class JsonTestSubClass
        {
            public long LongProp { get; set; }
            public List<JsonTestSubClass> SubClassList { get; set; }
            public JsonTestSubClass[] ArrayProp { get; set; }
        }

        class MyTestDataItem : TestClass3
        {
            public string Type;
        }

        class MyTestDataItem1 // : TestClass3
        {
            public int Type;
        }

        class MyTestDataItem2 // : TestClass3
        {
            public string Type;
        }

        class MyTestDataItem3 // : TestClass3
        {
            public bool B = true;
        }

        class MyTestDataMap //: TestClass3
        {
            public Dictionary<string, MyTestDataItem1> Items1;
            public Dictionary<string, MyTestDataItem2> Items2;
        }

        public static void JsonTest1()
        {
            JsonTestClass cls = new TestCases.JsonTest.JsonTestClass();
            cls.IntProp = 1;
            cls.StringProp = "2";
            cls.EnumProp = JsonTestEnum.Test3;
            var sub = new TestCases.JsonTest.JsonTestSubClass();
            sub.LongProp = 4;
            var sub2 = new TestCases.JsonTest.JsonTestSubClass();
            sub2.LongProp = 5;
            var sub3 = new TestCases.JsonTest.JsonTestSubClass();
            sub3.LongProp = 6;

            cls.SubClassProp = sub;
            sub.ArrayProp = new JsonTestSubClass[2];
            sub.ArrayProp[0] = sub2;
            sub.ArrayProp[1] = sub3;
            sub.SubClassList = new List<TestCases.JsonTest.JsonTestSubClass>();
            sub.SubClassList.Add(sub2);
            sub.SubClassList.Add(sub3);

            cls.DicTest = new Dictionary<string, TestCases.JsonTest.JsonTestSubClass>();
            cls.DicTest["11111"] = sub;
            cls.DicTest2 = new Dictionary<string, int>();
            cls.DicTest2["111222"] = 333444;

            var str = JsonMapper.ToJson(cls);
            Console.WriteLine(str);

            var cls2 = JsonMapper.ToObject<JsonTestClass>(str);
            Console.WriteLine(cls2.SubClassProp.ArrayProp[0].LongProp);
            Console.WriteLine(cls2.SubClassProp.ArrayProp[1].LongProp);
            Console.WriteLine(cls2.SubClassProp.SubClassList[0].LongProp);
            Console.WriteLine(cls2.SubClassProp.SubClassList[1].LongProp);
            Console.WriteLine(cls2.DicTest["11111"].LongProp);
            Console.WriteLine(cls2.DicTest2["111222"]);

        }

        public static void JsonTest2()
        {
            string json = "[{\"Type\":\"MyName\"}]";
            List<MyTestDataItem> data = JsonMapper.ToObject<List<MyTestDataItem>>(json);
            Console.WriteLine("Name : " + data[0].Type);
        }

        public static void JsonTest3()
        {
            string json = "{\"Items1\":{\"one\":{\"Type\":1},\"two\":{\"Type\":2}},\"Items2\":{\"one\":{\"Type\":\"OneType\"},\"two\":{\"Type\":\"TwoType\"}}}";
            MyTestDataMap data = JsonMapper.ToObject<MyTestDataMap>(json);
            Console.WriteLine("Type : " + data.Items1["one"].Type);
            Console.WriteLine("Type : " + data.Items2["one"].Type);

        }
        public static void JsonTest4()
        {
            var tj = new MyTestDataItem3();
            var json = JsonMapper.ToJson(tj);
            Console.WriteLine(json); //output: {"b":1} Error

            var outTj = JsonMapper.ToObject<MyTestDataItem3>(json); //Error Point!
            Console.WriteLine(outTj.B);
        }

        public static void JsonTest5()
        {
            if (typeof(MyTestDataItem1).Equals(typeof(MyTestDataItem2)))
            {
                Console.WriteLine("MyTestDataItem1 == MyTestDataItem2");
            }
            else
            {
                Console.WriteLine("MyTestDataItem1 != MyTestDataItem2");
            }
            if (typeof(MyTestDataItem1).Equals(typeof(MyTestDataItem1)))
            {
                Console.WriteLine("MyTestDataItem1 == MyTestDataItem1");
            }
            else
            {
                Console.WriteLine("MyTestDataItem1 != MyTestDataItem1");
            }
        }


        public static void JsonTest6()
        {
            JsonTestClass.StaticField = 10;
            JsonTestClass.StaticProp = 30;

            JsonTestClass cls = new TestCases.JsonTest.JsonTestClass();
            var str = JsonMapper.ToJson(cls);

            Console.WriteLine(str);

            if (str.Contains("StaticField"))
            {
                throw new Exception("Static Field should not be serilized");
            }

            if (str.Contains("StaticProp"))
            {
                throw new Exception("Static Field should not be serilized");
            }

            Console.WriteLine(str);
            var cls2 = JsonMapper.ToObject<JsonTestClass>(str);
        }

        public static void JsonIgnoreTest()
        {
            JsonTestClass cls = new TestCases.JsonTest.JsonTestClass();
            var str = JsonMapper.ToJson(cls);

            Console.WriteLine(str);

            if (str.Contains("IntProp") == false)
            {
                throw new Exception("IntProp should be serilized");
            }

            if (str.Contains("IgnoreField"))
            {
                throw new Exception("Ignore Field should not be serilized");
            }

            if (str.Contains("IgnoreProp"))
            {
                throw new Exception("Ignore Prop should not be serilized");
            }

            Console.WriteLine(str);
            var cls2 = JsonMapper.ToObject<JsonTestClass>(str);
        }

        public static void JsonTestFloat()
        {
            var floats = new List<float>()
            {
                float.MinValue,
                -123213.2f,
                -123.23478f,
                -1.0f,
                0,
                1.0f,
                123.23478f,
                float.MaxValue,
            };

            var json = JsonMapper.ToJson(floats);

            Console.WriteLine(json);

            var floats2 = JsonMapper.ToObject<List<float>>(json);

            for (var index = 0; index < floats.Count; index++)
            {
                var f = floats[index];
                var f2 = floats2[index];

                Console.WriteLine(string.Format("{0:f5} - {1:f5}", f, f2));

                if (Math.Abs(f - f2) > 0.01f)
                {
                    throw new Exception();
                }
            }
        }
    }
}
