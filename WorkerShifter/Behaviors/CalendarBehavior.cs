using Syncfusion.Maui.Calendar;
using WorkerShifter.ViewModels.ShiftsViewModels;

namespace WorkerShifter.Behaviors
{
    public class CalendarBehavior : Behavior<SfCalendar>
    {
        private SfCalendar calendar;

        protected override void OnAttachedTo(SfCalendar bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable;
            this.calendar.Tapped += calendar_Tapped;
        }

        private void calendar_Tapped(object sender, CalendarTappedEventArgs e)
        {
            
            ShiftPageViewModel viewModel = new();
            viewModel.OnItemSelected(e.Date);
        }

        protected override void OnDetachingFrom(SfCalendar bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.calendar != null)
            {
                this.calendar.Tapped -= calendar_Tapped;
            }

            this.calendar = null;
        }
    }
}