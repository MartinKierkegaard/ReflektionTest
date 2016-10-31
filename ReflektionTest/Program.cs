using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflektionTest
{
    //    using System;
    //    using System.Reflection;

    public class MyClass
    {
        public MyClass()
        {
            
        }
        public virtual int AddNumb(int numb1, int numb2)
        {
            int result = numb1 + numb2;
            return result;
        }

    }

    //    class MyMainClass
    //    {
    //        public static int Main()
    //        {
    //            Console.WriteLine("\nReflection.MethodInfo");
    //            // Create MyClass object
    //            MyClass myClassObj = new MyClass();
    //            // Get the Type information.
    //            Type myTypeObj = myClassObj.GetType();
    //            // Get Method Information.
    //            Console.WriteLine("typen er : " + myTypeObj);

    //            Type myTypeObj1 = Type.GetType("ReflektionTest.MyClass");

    //            Console.WriteLine("myTypeObj1 : " + myTypeObj1);

    //            Console.WriteLine("is abstract : {0}", myTypeObj1.IsAbstract);
    //            Console.WriteLine("is class : "+ myTypeObj1.IsClass); 


    //            MethodInfo myMethodInfo = myTypeObj.GetMethod("AddNumb");
    //            object[] mParam = new object[] { 5, 10 };
    //            // Get and display the Invoke method.
    //            Console.Write("\nFirst method - " + myTypeObj.FullName + " returns " +
    //                                 myMethodInfo.Invoke(myClassObj, mParam) + "\n");

    //            Console.ReadLine();

    //            return 0;


    //        }
    //    }

    public class ExampleClass
{
    public int sampleMember;
    public void SampleMethod() { }

    static void Main()
    {
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "Application");
                Console.WriteLine("Created Event source");
                return;
            }

            EventLog myLog = new EventLog();

            myLog.Source = "MySource";
            

            myLog.WriteEntry("Write to event log: " + myLog.Source);



            Assembly assem = typeof(ExampleClass).Assembly;

            Console.WriteLine("Assembly Full Name:");
            Console.WriteLine(assem.FullName);
            Console.WriteLine(assem.Location);

        var attr = typeof (ExampleClass).Attributes;
        Console.WriteLine(  attr.ToString());
            
            Type t = typeof(ExampleClass);
        // Alternatively, you could use
        // ExampleClass obj = new ExampleClass();
        // Type t = obj.GetType();

        Console.WriteLine("Methods:");
        System.Reflection.MethodInfo[] methodInfo = t.GetMethods();

        foreach (System.Reflection.MethodInfo mInfo in methodInfo)
            Console.WriteLine(mInfo.ToString());
            Console.WriteLine("**********");

        Console.WriteLine();
            Console.WriteLine("Members:");
        System.Reflection.MemberInfo[] memberInfo = t.GetMembers();

        foreach (System.Reflection.MemberInfo mInfo in memberInfo)
        {
            Console.WriteLine(mInfo.ToString());
                myLog.WriteEntry(mInfo.ToString(), EventLogEntryType.Error,1001,1);
            }

        Console.WriteLine("\nReflection.MethodInfo");
            // Create MyClass object
            MyClass myClassObj = new MyClass();
            // Get the Type information.
            Type myTypeObj = myClassObj.GetType();
            // Get Method Information.
            Console.WriteLine("typen er : " + myTypeObj);

            Type myTypeObj1 = Type.GetType("ReflektionTest.MyClass");

            Console.WriteLine("myTypeObj1 : " + myTypeObj1);

            Console.WriteLine("is abstract : {0}", myTypeObj1.IsAbstract);
            Console.WriteLine("is class : " + myTypeObj1.IsClass);

        Type NyType = typeof (MyClass);
           
            MethodInfo myMethodInfo = myTypeObj.GetMethod("AddNumb");
            object[] mParam = new object[] { 5, 10 };
            // Get and display the Invoke method.
            Console.Write("\nFirst method - " + myTypeObj.FullName + " returns " +
                                 myMethodInfo.Invoke(myClassObj, mParam) + "\n");


        Console.WriteLine("LOG : " + myLog.LogDisplayName);
        var errorlist = (from EventLogEntry entry in myLog.Entries select entry.Message).Skip(20).Take(10).ToList();

        foreach (var e   in errorlist)
        {
            Console.WriteLine(e);
            
        }

            //JavaScriptSerializer ser = new JavaScriptSerializer();

        Console.ReadLine();
    }
}
    /*
     Output:
        Methods:
        Void SampleMethod()
        System.String ToString()
        Boolean Equals(System.Object)
        Int32 GetHashCode()
        System.Type GetType()
        Members:
        Void SampleMethod()
        System.String ToString()
        Boolean Equals(System.Object)
        Int32 GetHashCode()
        System.Type GetType()
        Void .ctor()
        Int32 sampleMember
    */
}
