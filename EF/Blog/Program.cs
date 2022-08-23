﻿using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
           using(var context = new BlogDataContext())
           {
                //var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                //context.Tags.Add(tag);
                //context.SaveChanges();

                //var tag2 = new Tag { Name = ".NET", Slug = "dotnet" };
                //context.Tags.Add(tag2);
                //context.SaveChanges();

                //var tag = context
                //    .Tags
                //    .AsNoTracking()
                //    .FirstOrDefault(x => x.Id == 3);

                //tag.Name = "Ponto NET";
                //tag.Slug = "dotnet";

                //context.Update(tag);
                //context.SaveChanges();

                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);

                //context.Remove(tag);
                //context.SaveChanges();
                //var tags = context
                //    .Tags
                //    .AsNoTracking()
                //    .ToList();
                //foreach (var tag in tags)
                //{
                //    Console.WriteLine(tag.Name);
                //}
                var tag = context
                    .Tags
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == 3);

                Console.WriteLine(tag?.Name);
            }

        }
    }
}