namespace Taskly
{
    public class ToDo_Event
    {
        private string _task;
        private bool _isCompleted;
        public bool IsChecked;
        private DateTime _taskDate;
        private int _id;
        private double _daysLeftToTaskEnd;
        private bool _hasDate;
        private bool _expirated;

        public string Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public bool IsCompleted
        { get { return _isCompleted; } set { _isCompleted = value; } }
        public DateTime TaskDate
        { get { return _taskDate; } set { _taskDate = value; } }
        public int ID
        { get { return _id; } set { _id = value; } }
        public bool HasDate
        { get { return _hasDate; } init { _hasDate = value; } }

        public bool Expirated
        {
            get
            {
                if (_hasDate)
                {
                    return _expirated;
                }
                else
                {
                    return false;
                }
            }
        }

        public double recalculateDaysToTaskEnd()
        {
            double tempDaysLeft = 0;
            if (_hasDate == true)
            {
                tempDaysLeft = Math.Ceiling((TaskDate - DateTime.Now).TotalDays);
                if (tempDaysLeft > 0)
                {
                    _daysLeftToTaskEnd = tempDaysLeft;
                    _expirated = false;
                }
                else
                {
                    _expirated = true;
                    _daysLeftToTaskEnd = tempDaysLeft;
                }
            }
            return _daysLeftToTaskEnd;
        }
    }
}