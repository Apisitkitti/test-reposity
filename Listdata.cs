using System;
class ListData
{
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
            {
                return true;
            }
        }
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