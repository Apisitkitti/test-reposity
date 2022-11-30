using System;
//ส่วนMenu
enum MainMenu
{
    Register = 1,
    Login,
    CheckRoomm
}
enum RegisterMenu
{
    Student = 1,
    Teacher,
    Back
}
class Program
{
   static ListData data; 
    public static void Main()
    {
        PersonListLoad();
        ChooseMenu();
    }
    //Menu ตัวเลือก login หรือ register
    static void ChooseMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Welcome to the room reservation system.");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1.Register\n2.Login\n3.Check ReserveRoom");
        Console.WriteLine("---------------------------------------");
        ChooseMenuFromKeyboard();
    } 
    static void ChooseMenuFromKeyboard()
    {
       Console.Write("please choose your Menu : ");
       MainMenu menu = (MainMenu)(int.Parse(Console.ReadLine()));
       DisplayMenu(menu);
    }
    //registermenu   
     static void ChooseRegisterMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("         Register.        ");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1.Student\n2.Teacher\n3.Back");
        Console.WriteLine("--------------------------");
        ChooseRegisterMenuFromKeyboard();
    }
    
     static void ChooseRegisterMenuFromKeyboard()
    {
        Console.Write("please choose your Menu : ");
       RegisterMenu menu = (RegisterMenu)(int.Parse(Console.ReadLine()));
       DisplayRegisterMenu(menu);
    }
    static void DisplayMenu(MainMenu menu)
    {
        switch(menu)
        {
            case MainMenu.Register: ChooseRegisterMenu();
            break;
            case MainMenu.Login: LoginFromKeyboard();
            break;
            case MainMenu.CheckRoomm: CheckReserveRoom();
            break;
        }
    }
   
    static void DisplayRegisterMenu(RegisterMenu menu)
    {
        switch(menu)
        {
            case RegisterMenu.Student: NewStudent();
            break;
            case RegisterMenu.Teacher: NewTeacher();
            break;
            case RegisterMenu.Back: BackToMainMemu();
            break;
        }
    }
    static void NewStudent()
    {
        Console.Clear();
        string name = InputName();
        string surname = InputSurname();
        Student student = new Student(name,surname,InputID(),InputClass_Year(),Password());
        
        bool checkdata = data.CheckRegis(name,surname);
        if(checkdata == true)
        {
            Program.data.PeopleAdd(student);
            ChooseMenu();
        }
        else if(checkdata == false)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("This user already register!!");
            Console.WriteLine("----------------------------");
            Console.ReadLine();
            NewStudent();
        }
     }
        
    static void NewTeacher()
     {
        Console.Clear();
        string name = InputName();
        string surname = InputSurname();
        Teacher teacher = new Teacher(name,surname,InputCitizenId(),Password());
        bool checkdata = data.CheckRegis(name,surname);
        if(checkdata == true)
        {
         Program.data.PeopleAdd(teacher);
        ChooseMenu();
        }
        else if(checkdata == false)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("This user already register!!");
            Console.WriteLine("----------------------------");
            Console.ReadLine();
            NewTeacher();
        }  

    }
    //จบ regisster
    
    //Login
    static void LoginFromKeyboard()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("           Login.         ");
        Console.WriteLine("--------------------------");
        Console.Write("ID: ");
        string ID = Console.ReadLine();
        Console.Write("Password: ");
        string Password = Console.ReadLine();
        if(data.LoginCheck(ID,Password) == true)
        {
            if(data.Adminchecker(ID,Password) == true )
            {
                TeacherAccept(ID,Password);
            }
            else if(data.Adminchecker(ID,Password) == false)
            {
                StudentReserve(ID,Password);
            }
        }
         else if(data.LoginCheck(ID,Password) == false)
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("  Invalid ID/Password");
            Console.WriteLine("   !Please login again!");
            Console.WriteLine("--------------------------");
            PressToContinue();
        } 
    }
    //เตรียมตัวเพื่อโหลดข้อมูล่วงหน้าจะได้ไม่บึ้ม
    static void PersonListLoad()
    {
        Program.data = new ListData();
    }
     //ส่วนการจะใช้กกรอกข้อมูล
    public static string InputName()
    {
        Console.Write("please input your name : ");
        return Console.ReadLine();
    }
    public static string InputSurname()
    {
        Console.Write("please input your Surname : ");
        return Console.ReadLine();
    }
    public static string InputID()
    {
        Console.Write("please input your ID : ");
        return Console.ReadLine();
    }
    public static string InputClass_Year()
    {
        Console.Write("please Input class year : ");
        return Console.ReadLine();
    }
    public static string InputCitizenId()
    {
        Console.Write("please input yor CitizenID : ");
        return Console.ReadLine();
    }
    public static string Password()
    {
      Console.Write("please input your Password : ");
      return Console.ReadLine();
    }
}