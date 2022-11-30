using System;
//ส่วนMenu
enum StudentMenu
{
    Reserve = 1,
    CheckRoomm,
    TLoguot
}
enum TeacherMenu
{
    Accept = 1,
    CheckRoomm,
    Check,
    TLoguot
}
 class Program
 {
    static ListData data;
    public static void Main()
    {
        PersonListLoad();
        Room(); 
    }
      //ส่วนMenuloginอาจารย์
    static void TeacherAccept(string id , string password)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("                Welcome.               ");
        Console.WriteLine("---------------------------------------");
        data.WHoisthat(id,password);
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Choose Menu\n1.Accept room\n2.Check ReserveRoom\n3.Check Student\n4.Logout");
        Console.WriteLine("---------------------------------------");
        Console.Write("please choose your Menu : ");
        TeacherMenu menu = (TeacherMenu)(int.Parse(Console.ReadLine()));
        SwitchTeacherMenu(menu);

    }
    static void SwitchTeacherMenu(TeacherMenu menu)
    {
        switch(menu)
        {
            case TeacherMenu.Accept: AdminConfirm();
            break; 
            case TeacherMenu.CheckRoomm: CheckReserveRoom();
            break;
            case TeacherMenu.Check: Display_Student_CheckList();
            break;
            case TeacherMenu.TLoguot: BackToMainMemu();
            break;
        }
    } 
    static void Display_Student_CheckList()
    {
        Console.Clear();
        data.FetchData();
        Console.WriteLine("");
        PressToContinue();
    }  
    static void AdminConfirm()
    {
        Console.Clear();
        if(data.CheckDelete()== false)
        {
            Console.WriteLine("You dont have any reserve room!!");
            Console.ReadLine();
            BackToMainMemu();
        }
        else if(data.CheckDelete()== true)
        {
            data.ReserveRoom();
            Console.WriteLine("--------------------------------------");
            Console.Write("please Choose Info to reject room (Input -1 to for back to main menu ) : ");
            int choose = InputChoice();
        
        if(choose == -1)
        {
            BackToMainMemu();
        }
            else
            {
              data.RoomDete(choose-1);
              PressToContinue();
            }

        }
    }
    //เตรียมตัวเพื่อโหลดข้อมูล่วงหน้าจะได้ไม่บึ้ม
    static void PersonListLoad()
    {
        Program.data = new ListData();
    }
    //ส่วนเช็คห้อง
        static void CheckReserveRoom()
        {
        Console.Clear();

        Program.data.ReserveRoom();
        Console.WriteLine("");
        PressToContinue();
        }

    //ส่วนจอง
    static void Reserve()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("            Room List           ");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1.room 403 | Max size 30 people\n2.room 604 | Max size 40 people\n3.Gym      | Max size 150 people\n4.Theater  | Max size 100 people");
        Console.WriteLine("--------------------------------");
        Console.Write("please choose your room : ");
        int roomNum = int.Parse(Console.ReadLine());
        Console.WriteLine("--------------------------------");
            if(roomNum == 1)
            {
                string name = InputName();
                string surname = InputSurname(); 
                string Roomname = "403" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 2)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "604" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 3)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "Gym" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);   
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 4)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "Theater" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);   
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
    }
        //Methodaddlistเข้าห้อง
        public static void AddRoom(ref string Roomname,ref int amount,ref string name, ref string surname, ref Reserve reserve)
        {
            if(data.CheckRoomSUm(Roomname,name,surname) == true)
            {
                if(data.RoomAmountcheck(Roomname,amount)  == true)
                {
                    Program.data.RoomAdd(reserve);
                    ChooseMenu();
                 
                }
                else if(data.RoomAmountcheck(Roomname,amount)  == false)
                {
                     Console.Clear();
                    Console.WriteLine("Your student is more than room capacity!!");
                    Console.WriteLine("");
                    PressToContinue();
                }
                        
            }   
            else if(data.CheckRoomSUm(Roomname,name,surname) == false)
            {
                Console.Clear();
                Console.WriteLine("ํYou already reserve this room!!");
                Console.WriteLine("");
                PressToContinue();
            }
               
        }
        //ห้อง
        static void Room()
        {
            Room room1 = new Room("403",30);
            Room room2 = new Room("604",40);
            Room room3 = new Room("Gym",150);
            Room room4 = new Room("Theater",100);
            data.RoomInfoAdd(room1);
            data.RoomInfoAdd(room2);
            data.RoomInfoAdd(room3);
            data.RoomInfoAdd(room4);
        }
        //กลับสู่ main เมนู
        static void BackToMainMemu()
        {
            ChooseMenu();
        }
         static void PressToContinue()
        {
            Console.Write("Press enter to continue");
            string enter = Console.ReadLine();
            if (enter == "")
            {
                ChooseMenu();
            }
        }
        public static int InputAmount()
    {
        Console.Write("please input amount of your student : ");
        return int.Parse(Console.ReadLine());
    }
    public static string InputActivity()
    {
        Console.Write("please input your activity to do in this room : ");
        return Console.ReadLine();
    }


    
}
 