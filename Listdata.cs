using System;
class ListData
{
<<<<<<< HEAD
    private List<Reserve>listroom;
    private List<Room>listroominfo; 

    public ListData()
    {
        this.listroom= new List<Reserve>();
        this.listroominfo= new List<Room>();
    }
    public void RoomAdd(Reserve reserve)
    {
        this.listroom.Add(reserve);
    }
    public void RoomInfoAdd(Room room)
    {
        this.listroominfo.Add(room);
    }
    public void RoomDete(int choose)
    {
       listroom.RemoveAt(choose);
    }
    public void ReserveRoom()
   {
    int count = 0;
    if(listroom.Count == 0)
    {
        Console.WriteLine("Not have any reserve!!");
    }
    else if(listroom.Count > 0)
    {
        foreach(Reserve reserveroom in listroom)
        {
            count++;
            if(reserveroom is Room room)
            {
                Console.WriteLine("{0}. {1} {2} | Reserve: {3} | Amount: {4} \n   Activity: {5}",count,reserveroom.GetName(),reserveroom.GetSurname(),reserveroom.GetRoomname(),reserveroom.GetAmount(),reserveroom.GetActivity());
            }
        }
    } 
   }
   public bool RoomAmountcheck(string name,int amount )
   {
        foreach(Room room in listroominfo)
        {
            if(amount > room.GetAmount()&& name.Equals(room.GetRoomname()))
            {
                return false;
            }
            else if(amount <= room.GetAmount()&& name.Equals(room.GetRoomname()))
=======
    private List<Person> peoplelist;
    public ListData()
    {
        this.peoplelist = new List<Person>();
        this.listroom= new List<Reserve>();
        this.listroominfo= new List<Room>();
    
    }
    public void PeopleAdd(Person person)
    {
       this.peoplelist.Add(person);
    }
    //ตัวเช็คนักเรียนหรือครู
   public bool CheckRegis(string name , string surname)
   {
    
     
        foreach(Person person in peoplelist)
        {
             if(person is Teacher teacher)
             {
                if(teacher.GetName().Equals(name)&& teacher.GetSurname().Equals(surname))
                {
                    return false;
                }
             }
              else if(person is Student student)
              {
                if(student.GetName().Equals(name)&& student.GetSurname().Equals(surname))
                {
                    return false;
                }
              }
     }
     return true ;
   }
   //ส่วนlogin
   public bool LoginCheck(string id , string password)
   {
    if(peoplelist.Count ==0)
    {
        return false;
    }
     
     else if(peoplelist.Count > 0)
     {
        foreach(Person person in peoplelist)
     {
        if(person is Teacher teacher)
        {
            if(id.Equals(teacher.GetId())&&(password.Equals(teacher.GetPassword())))
>>>>>>> RegisterLogin
            {
                return true;
            }
        }
<<<<<<< HEAD
        return RoomAmountcheck(name,amount);  
    }
    //deletefunti
    public bool CheckDelete()
    {
        if(listroom.Count == 0 )
        {
            return false;
        }
        else if(listroom.Count >0)
        {
            return true;
        }
        else if(listroom.Count == null)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
    //checkว่าคือใคร
   public void WHoisthat(string id , string password)
   {
    foreach(Person person in peoplelist)
    {
        if(person is Teacher teacher)
        {
            if(id.Equals(teacher.GetId())&&password.Equals(teacher.GetPassword()))
            {
                Console.WriteLine("{0} {1}",teacher.GetName(),teacher.GetSurname());
            }
        }
        else if (person is Student student)
        {
             if(id.Equals(student.GetID())&&password.Equals(student.GetPassword()))
            {
                Console.WriteLine("{0} {1}",student.GetName(),student.GetSurname());
            }
        }
    } 
   }
 //CheckROomAgain()
    public bool CheckRoomSUm(string roomname,string name, string surname)
    {
        foreach(Reserve reserve in listroom)
        {
             if(name.Equals(reserve.GetName())&&roomname.Equals(reserve.GetRoomname())&&surname.Equals(reserve.GetSurname()))
                {
                    return false;
                } 
        }
        return true;
 
    }
}
=======
        else if(person is Student student)
        {
            if(id.Equals(student.GetID())&&password.Equals(student.GetPassword()))
            {
                return true;
            }
        }
        
     }
     }
     return false;
   }
   //check สำหรับส่วนMenuว่าเปนจารย์หรือนักเรียน(Admin)
   public bool Adminchecker(string id, string password)
   {
    foreach(Person person in peoplelist)
    {
     if(person is Teacher teacher)
     {
          if(id.Equals(teacher.GetId())&&(password.Equals(teacher.GetPassword())))
            {
                return true;
            }
     }
    else if(person is Student student)
    {
            if(id.Equals(student.GetID())&&password.Equals(student.GetPassword()))
            {
                return false;
            }
    }
    
   }
   return Adminchecker(id,password);
}
   //ส่วนที่เป็นสำหรับนำข้อมูลมาโชว์ออกมาFetch
   public void FetchData()
   {
    int count = 0;
    foreach(Person person in peoplelist)
    {       
            count++;
            if(person is Student student)
            {
              Console.WriteLine("{0}. {1} {2} Class: {3} ",count, student.GetName(),student.GetSurname(),student.GetClassYear());
            }
    }     
   }
   
}    
>>>>>>> RegisterLogin
