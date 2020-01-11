
/*
1. Добавлять сотрудников, в ответ должен приходить Id добавленного сотрудника.
2. Удалять сотрудников по Id.
3. Выводить список сотрудников для указанной компании. Все доступные поля.
4. Изменять сотрудника по его Id. Изменения должно быть только тех полей, которые указаны в запросе.
     */

namespace TestTaskKolgatina.Controllers
{
    public class Queries
    {
        public static string AddEmployee()
        {
            return "INSERT INTO employee (name, surname, Phone, CompanyId, Passport) VALUES ('Mike','Buganoff','5830948350', '3', '3593874')";

            //return Id;
        }

        public void DeleteEmployee(int IdEmployee)
        {
        }

        public void PrintAListOfEmployees()
        {
        }

        public void EditEmployeeInfo(int IdEmployee)
        {
        }
    }
}
