using Balta.ContentContext;
using Balta.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            //foreach (var article in articles)
            //{
            //    Console.WriteLine(article.Id);
            //    Console.WriteLine(article.Title);
            //    Console.WriteLine(article.Url);
            //    Console.WriteLine("###############################");

            //}
            var courses = new List<Course>();
            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");
            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

           

            var careers = new List<Career>();
            var careerDotNet = new Career("Especialista .NET", "especialista-dotnet");
            var careerDotNetItem2= new CareerItem(2, "Aprenda OOP", "", null);
            var careerDotNetItem1 = new CareerItem(1, "Comece por aqui", "", courseCsharp);
            var careerDotNetItem3 = new CareerItem(3, "Aprenda .NET", "", courseAspNet);
            careerDotNet.Items.Add(careerDotNetItem2);
            careerDotNet.Items.Add(careerDotNetItem1);
            careerDotNet.Items.Add(careerDotNetItem3);
            careers.Add(careerDotNet);

            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
                var payPalSubscription = new PayPalSubscriotion();
                var student = new Student();
                student.CreateSubscription(payPalSubscription);
            }
        }
    }
}
