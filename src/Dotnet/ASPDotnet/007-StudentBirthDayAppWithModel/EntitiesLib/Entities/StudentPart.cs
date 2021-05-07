namespace StudentBirthDayApp.Entities
{
    public partial class Student
    {
        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object other)
        {
            return Id == ((Student)other).Id;
        }
    }
}