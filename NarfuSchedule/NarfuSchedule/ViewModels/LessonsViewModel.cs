using System;
using System.Collections.Generic;
using System.Linq;
using NarfuSchedule.Models;

namespace NarfuSchedule.ViewModels
{
    public class LessonsViewModel : BaseViewModel
    {
        public IEnumerable<IGrouping<string, Lesson>> Lessons { get; set; } = new List<IGrouping<string, Lesson>>();

        public DateTime UpdateTime { get; set; }

        public readonly MainContext _db = MainContext.GetInstance();

        public LessonsViewModel()
        {
            if (_db.Lessons.Any())
                Lessons = _db.GetGrouperLessons();
        }
    }
}