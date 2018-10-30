using System.Collections.Generic;
using System.Linq;
using NarfuSchedule.Models;
using Xamarin.Forms;

namespace NarfuSchedule.ViewModels
{
    public class LessonsViewModel : BaseViewModel
    {
        public IEnumerable<IGrouping<string, Lesson>> Lessons { get; set; } = new List<IGrouping<string, Lesson>>();

        public LessonsViewModel()
        {
            var l = ScheduleHelper.LoadCalendar();
            if (l.Count > 0)
                Lessons = ScheduleHelper.LoadCalendar().GroupBy(x => x.Time.ToString("dd.MM.yyyy (dddd)"));
            else
            {
                DependencyService.Get<IMessage>().LongTime("Невозможно получить расписание.\n" +
                                                           "Проверьте, включен ли WI-FI или мобильный интернет.\n" +
                                                           "Также может быть недоступен сайт.");
            }
        }
    }
}