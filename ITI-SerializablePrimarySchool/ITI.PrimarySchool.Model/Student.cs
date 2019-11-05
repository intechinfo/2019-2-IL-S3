namespace ITI.PrimarySchool.Model
{
    public class Student
    {
        readonly School _ctx;
        readonly string _firstName;
        readonly string _lastName;

        internal Student(School ctx, string firstName, string lastName)
        {
            _ctx = ctx;
            _firstName = firstName;
            _lastName = lastName;
        }

        public School School
        {
            get { return _ctx; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }
    }
}
