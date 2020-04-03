using XamarinNativePractialCoding.Models;

namespace XamarinNativePractialCoding.ExtensionMethods
{
    public static class PersonExtensions
    {
        public static Person ToPerson(this string person)
        {
            const int Id = 0;
            const int FIRST_NAME = 1;
            const int LAST_NAME = 2;
            const int TITLE = 3;

            string[] fields = person.Split(Global.DELIMITTER.ToCharArray());

            return new Person
            {
                Id = fields[Id],
                Firstname = fields[FIRST_NAME],
                Lastname = fields[LAST_NAME],
                Title = fields[TITLE]
            };
        }


        public static string SerializePerson(this Person person)
        {
            return $"{person.Id}{Global.DELIMITTER}{person.Firstname}{Global.DELIMITTER}{person.Lastname}{Global.DELIMITTER}{person.Title}";
        }
    }
}