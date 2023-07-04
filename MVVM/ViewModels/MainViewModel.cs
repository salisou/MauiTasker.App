using MauiTasker.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FileData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FileData()
        {
            Categories = new ObservableCollection<Category>()
            {
                new Category
                {
                    Id = 1,
                    CategoryName = ".Net maui Course",
                    Color = "#CF14DF"
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "Tutorial",
                    Color = "#df6f14"
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#14df80"
                },

            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Update exercise file",
                    Completed = false,
                    CategoryId = 1,
                },

                new MyTask
                {
                    TaskName = "Plan next couse",
                    Completed = false,
                    CategoryId = 1,
                },

                new MyTask
                {
                    TaskName = "Plan new ASP.NET video on Youtube",
                    Completed = false,
                    CategoryId = 2,
                },

                new MyTask
                {
                    TaskName = "Fix Setting.cs class of the projet",
                    Completed = false,
                    CategoryId = 2,
                },

                new MyTask
                {
                    TaskName = "Update github repository",
                    Completed = true,
                    CategoryId = 2,
                },

                new MyTask
                {
                    TaskName = "Buy eggs",
                    Completed = false,
                    CategoryId = 3,
                },

                new MyTask
                {
                    TaskName = "Go for the pepperoni pizza",
                    Completed = false,
                    CategoryId = 3,
                }
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                           where t.CategoryId == c.Id
                           select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var noComleted = from t in tasks
                                 where t.Completed == false
                                 select t;

                c.PendingTasks = noComleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }

            foreach (var t in Tasks)
            {
                var catColor = 
                    (
                        from c in Categories
                        where c.Id == t.CategoryId
                        select c.Color
                     ).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
