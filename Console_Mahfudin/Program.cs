using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Console_Mahfudin
{
    class Program
    {
        static void Main(string[] args)
        {
            int numMenu = 0;
            List<EmployeeModel> listEmployees = new List<EmployeeModel>();

            title:
                WriteLine("Menu list of employees\n==========================");
            menu:
                WriteLine("\n1. Add data employee\n2. Show list of employee\n3. Delete data of employee\n4. Clear\n5. Exit");
            start:
                Write("Choose the Menu  [1-5] : ");
                numMenu = int.Parse(ReadLine());

            switch (numMenu)
            {
                case 1:
                    EmployeeModel employeeModel = new EmployeeModel();

                    WriteLine("Add Employee\n===============");
                    try
                    {
                        addEmpid:
                            Write("Employee ID : ");
                            string employeeId = ReadLine();
                            if (string.IsNullOrEmpty(employeeId))
                            {
                                WriteLine("Empty Employee ID, please try again");
                                goto addEmpid;
                            }
                            else
                            {
                                employeeModel.EmployeeId = employeeId;
                            }

                        addFull:
                            Write("Full Name : ");
                            string fullName = ReadLine();
                            if (string.IsNullOrEmpty(fullName))
                            {
                                WriteLine("Empty Full Name, please try again");
                                goto addFull;
                            }
                            else
                            {
                                employeeModel.FullName = fullName;
                            }

                        addBirth:
                            Write("Birth Date : ");
                            DateTime inputBirthDate;
                            if (DateTime.TryParse(ReadLine(), out inputBirthDate))
                            {
                                employeeModel.BirtDate = inputBirthDate;
                            }
                            else
                            {
                                WriteLine("empty or incorrect value, please try again");
                                goto addBirth;
                            }

                            var dataExist = listEmployees.Where(x => x.EmployeeId.Equals(employeeId)).FirstOrDefault();
                            if (dataExist != null)
                            {
                                WriteLine("duplicate employee ID, please try again");
                                goto addEmpid;
                            }


                            listEmployees.Add(employeeModel);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                    
                    WriteLine("Add Employee Success");
                    goto menu;
                case 2:
                    //show list                    
                    WriteLine("Show List of Employee\n");
                    var table = new ConsoleTable("EmployeeID", "FullName", "BirtDate");
                    foreach (var data in listEmployees)
                    {
                        table.AddRow(data.EmployeeId, data.FullName, data.BirtDate.ToString("dd-MMM-yyyy"));
                    }
                    table.Write();
                    WriteLine();
                    goto menu;
                case 3:
                    //delete
                    delete:
                    WriteLine("Delete Employee\n=============\n");
                    Write("Employee ID : ");
                    string id = ReadLine();

                    var itemToRemove = listEmployees.SingleOrDefault(x => x.EmployeeId == id);
                    if (itemToRemove != null)
                    {
                        listEmployees.Remove(itemToRemove);
                    }
                    else
                    {
                        WriteLine("Employee ID not found");
                        goto delete;
                    }
                    WriteLine("Delete Employee Success");
                    goto menu;
                case 4:
                    //clear
                    Clear();
                    goto title;
                case 5:
                    //exit
                    WriteLine("program close....");
                    break;
                default:
                    WriteLine("Please enter the valid menu");
                    goto start;
            }
        }

    }
}
